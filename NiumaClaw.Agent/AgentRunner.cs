using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace NiumaClaw.Agent;

internal sealed class AgentRunner
{
    internal const string AgentVersion = "1.0.8";

    private readonly AgentConfig _config;
    private readonly HttpClient _http = new();

    public AgentRunner(AgentConfig config)
    {
        _config = config;
    }

    public event Action<string>? Log;
    public event Action<string>? StatusChanged;

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        Directory.CreateDirectory(_config.Workspace);
        Status("连接中");
        LogLine($"NiumaClaw Agent {_config.DeviceName}");
        LogLine($"Server: {_config.Server}");
        LogLine($"Node: {_config.NodeId}");
        LogLine($"Adapter: {_config.Adapter}");
        LogLine($"Workspace: {_config.Workspace}");

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                await PostJsonAsync("/api/agent-nodes/heartbeat", new
                AgentHeartbeatRequest(
                    Environment.OSVersion.Platform.ToString(),
                    AgentVersion,
                    Capabilities()),
                    AgentJsonContext.Default.AgentHeartbeatRequest,
                    cancellationToken);

                Status("已连接，待命中");
                JsonDocument polled = await PostJsonAsync(
                    "/api/agent-nodes/jobs/poll",
                    new AgentPollRequest(25000, Capabilities()),
                    AgentJsonContext.Default.AgentPollRequest,
                    cancellationToken,
                    timeoutSeconds: 40);

                if (!polled.RootElement.TryGetProperty("job", out JsonElement job)
                    || job.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined)
                {
                    continue;
                }

                await HandleJobAsync(job, cancellationToken);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                break;
            }
            catch (Exception ex)
            {
                Status("连接异常");
                LogLine("Runner error: " + ex.Message);
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken).ConfigureAwait(false);
            }
        }

        Status("已停止");
        LogLine("Agent stopped.");
    }

    private async Task HandleJobAsync(JsonElement job, CancellationToken cancellationToken)
    {
        long jobId = job.GetProperty("id").GetInt64();
        string employee = GetString(job, "employeeName", "agent");
        string prompt = GetString(job, "prompt", string.Empty);
        Status("执行任务");
        LogLine($"[job {jobId}] {employee}: {Trim(prompt, 180)}");

        await PostJsonAsync(
            $"/api/agent-nodes/jobs/{jobId}/start",
            new AgentJobStartRequest("started"),
            AgentJsonContext.Default.AgentJobStartRequest,
            cancellationToken,
            timeoutSeconds: 15);
        (bool ok, string output, string? error) = await RunCommandAsync(prompt, cancellationToken);

        await PostJsonAsync(
            $"/api/agent-nodes/jobs/{jobId}/finish",
            new AgentJobFinishRequest(
                ok,
                Trim(output, 120000),
                error,
                new AgentJobMetadata(_config.Adapter, _config.Workspace, "NiumaClaw.Agent")),
            AgentJsonContext.Default.AgentJobFinishRequest,
            cancellationToken,
            timeoutSeconds: 30);

        LogLine($"[job {jobId}] {(ok ? "done" : "failed")}");
        if (!string.IsNullOrWhiteSpace(error)) LogLine(error);
    }

    private async Task<(bool Ok, string Output, string? Error)> RunCommandAsync(string prompt, CancellationToken cancellationToken)
    {
        if (_config.Adapter.Equals("echo", StringComparison.OrdinalIgnoreCase))
        {
            return (true, "[echo runner]\n" + prompt, null);
        }

        string command = BuildCommand(prompt);
        if (string.IsNullOrWhiteSpace(command))
        {
            return (false, string.Empty, "当前适配器没有配置可执行命令，请重新下载客户端或配置 NIUMACLAW_RUNNER_COMMAND_TEMPLATE。");
        }

        LogLine("$ " + command);
        using CancellationTokenSource timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeoutCts.CancelAfter(TimeSpan.FromMinutes(30));

        ProcessStartInfo psi = BuildShellStartInfo(command, _config.Workspace);
        StringBuilder output = new();

        using Process process = new() { StartInfo = psi, EnableRaisingEvents = true };
        process.OutputDataReceived += (_, e) => AppendProcessLine(output, e.Data);
        process.ErrorDataReceived += (_, e) => AppendProcessLine(output, e.Data);

        try
        {
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            await process.WaitForExitAsync(timeoutCts.Token).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            TryKill(process);
            return (false, output.ToString(), HumanizeCommandError("Command timed out after 30 minutes.", output.ToString()));
        }
        catch (Exception ex)
        {
            return (false, output.ToString(), HumanizeCommandError(ex.Message, output.ToString()));
        }

        string text = output.ToString().Trim();
        return process.ExitCode == 0
            ? (true, string.IsNullOrWhiteSpace(text) ? "Command completed without output." : text, null)
            : (false, text, HumanizeCommandError("Command exited with code " + process.ExitCode + ".", text));
    }

    private string HumanizeCommandError(string rawError, string output)
    {
        string commandName = RequiredCommandName(_config.Adapter);
        string combined = (rawError + "\n" + output).ToLowerInvariant();
        if (combined.Contains("timed out", StringComparison.Ordinal))
        {
            return "任务超过 30 分钟未完成，已自动停止。请缩小任务范围或拆成更小的步骤后重试。";
        }

        if (combined.Contains("401", StringComparison.Ordinal) || combined.Contains("403", StringComparison.Ordinal)
            || combined.Contains("unauthorized", StringComparison.Ordinal) || combined.Contains("forbidden", StringComparison.Ordinal))
        {
            return "服务器拒绝了客户端连接，请从网页重新下载当前账号专属桌面客户端。";
        }

        if (combined.Contains("command not found", StringComparison.Ordinal)
            || combined.Contains("not recognized as an internal or external command", StringComparison.Ordinal)
            || (combined.Contains("no such file or directory", StringComparison.Ordinal) && combined.Contains(commandName, StringComparison.Ordinal)))
        {
            return CommandMissingMessage(commandName);
        }

        if (combined.Contains("permission denied", StringComparison.Ordinal) || combined.Contains("access is denied", StringComparison.Ordinal))
        {
            return "本机命令没有足够权限执行。请检查工作区权限，或把工作区换到用户目录下的 NiumaClawWorkspace。";
        }

        if (rawError.StartsWith("Command exited with code ", StringComparison.OrdinalIgnoreCase))
        {
            return rawError + " 常见原因是 CLI 未登录、模型/网络权限不足，或任务里的命令执行失败。请查看运行详情里的终端输出。";
        }

        return string.IsNullOrWhiteSpace(rawError) ? "任务执行失败，请查看运行详情里的终端输出。" : rawError.Trim();
    }

    private static string CommandMissingMessage(string commandName)
    {
        return commandName.ToLowerInvariant() switch
        {
            "codex" => "找不到 codex 命令。请先安装并登录 Codex CLI，安装后重新打开 NiumaClaw Agent。",
            "claude" => "找不到 claude 命令。请先安装并登录 Claude Code CLI，安装后重新打开 NiumaClaw Agent。",
            "hermes" => "找不到 hermes 命令。请先安装 Hermes CLI，或用 NIUMACLAW_RUNNER_COMMAND_TEMPLATE 配置完整命令。",
            _ => $"找不到 {commandName} 命令。请先安装该 CLI，或用 NIUMACLAW_RUNNER_COMMAND_TEMPLATE 配置完整命令。"
        };
    }

    private void AppendProcessLine(StringBuilder output, string? line)
    {
        if (line == null) return;
        output.AppendLine(line);
        LogLine(line);
    }

    private string BuildCommand(string prompt)
    {
        string? template = Environment.GetEnvironmentVariable("NIUMACLAW_RUNNER_COMMAND_TEMPLATE");
        if (string.IsNullOrWhiteSpace(template))
        {
            template = _config.Adapter.ToLowerInvariant() switch
            {
                "hermes" => "hermes {prompt}",
                "claude" => "claude -p {prompt}",
                _ => "codex exec --skip-git-repo-check --cd {workspace} {prompt}"
            };
        }

        return template
            .Replace("{workspace}", QuoteArgument(_config.Workspace), StringComparison.Ordinal)
            .Replace("{prompt}", QuoteArgument(prompt), StringComparison.Ordinal);
    }

    private static ProcessStartInfo BuildShellStartInfo(string command, string workspace)
    {
        if (OperatingSystem.IsWindows())
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };
            psi.ArgumentList.Add("/d");
            psi.ArgumentList.Add("/s");
            psi.ArgumentList.Add("/c");
            psi.ArgumentList.Add(command);
            ApplyWorkingDirectory(psi, workspace);
            ApplyRunnerEnvironment(psi);
            return psi;
        }

        ProcessStartInfo unixPsi = new ProcessStartInfo("/bin/bash")
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8
        };
        unixPsi.ArgumentList.Add("-lc");
        unixPsi.ArgumentList.Add(command);
        ApplyWorkingDirectory(unixPsi, workspace);
        ApplyRunnerEnvironment(unixPsi);
        return unixPsi;
    }

    private static void ApplyRunnerEnvironment(ProcessStartInfo psi)
    {
        string currentPath = psi.Environment.TryGetValue("PATH", out string? existingPath)
            ? existingPath ?? string.Empty
            : Environment.GetEnvironmentVariable("PATH") ?? string.Empty;
        psi.Environment["PATH"] = BuildEffectivePath(currentPath);
    }

    internal static string BuildEffectivePath(string? currentPath = null)
    {
        char separator = OperatingSystem.IsWindows() ? ';' : ':';
        return string.Join(separator, BuildEffectivePathEntries(currentPath));
    }

    internal static IReadOnlyList<string> BuildEffectivePathEntries(string? currentPath = null)
    {
        char separator = OperatingSystem.IsWindows() ? ';' : ':';
        StringComparer comparer = OperatingSystem.IsWindows() ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;
        string pathValue = currentPath ?? Environment.GetEnvironmentVariable("PATH") ?? string.Empty;
        List<string> parts = new();
        HashSet<string> seen = new(comparer);
        foreach (string path in GetPreferredPathEntries())
        {
            AddPathPart(path);
        }

        foreach (string path in pathValue.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            AddPathPart(path);
        }

        return parts;

        void AddPathPart(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;
            string expanded = Environment.ExpandEnvironmentVariables(value);
            if (string.IsNullOrWhiteSpace(expanded)) return;
            if (seen.Add(expanded)) parts.Add(expanded);
        }
    }

    internal static string RequiredCommandName(string adapter)
    {
        return adapter.Trim().ToLowerInvariant() switch
        {
            "hermes" => "hermes",
            "claude" => "claude",
            "echo" => "echo",
            _ => "codex"
        };
    }

    internal static IEnumerable<string> GetPreferredPathEntries()
    {
        if (OperatingSystem.IsWindows())
        {
            string profile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            if (!string.IsNullOrWhiteSpace(appData)) yield return Path.Combine(appData, "npm");
            if (!string.IsNullOrWhiteSpace(localAppData))
            {
                yield return Path.Combine(localAppData, "Programs", "Microsoft VS Code", "bin");
                yield return Path.Combine(localAppData, "Programs", "Cursor", "resources", "app", "bin");
            }

            if (!string.IsNullOrWhiteSpace(profile))
            {
                yield return Path.Combine(profile, ".local", "bin");
                yield return Path.Combine(profile, ".cargo", "bin");
            }

            yield break;
        }

        string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        if (!string.IsNullOrWhiteSpace(home))
        {
            yield return Path.Combine(home, ".local", "bin");
            yield return Path.Combine(home, ".cargo", "bin");
            yield return Path.Combine(home, ".npm-global", "bin");
            yield return Path.Combine(home, ".volta", "bin");
            yield return Path.Combine(home, ".asdf", "shims");
            yield return Path.Combine(home, ".local", "share", "mise", "shims");
            yield return Path.Combine(home, ".nvm", "current", "bin");
            foreach (string nvmBin in EnumerateNvmNodeBins(home))
            {
                yield return nvmBin;
            }
            yield return Path.Combine(home, ".bun", "bin");
            yield return Path.Combine(home, ".deno", "bin");
            yield return Path.Combine(home, ".codex", "bin");
        }

        yield return "/Applications/Codex.app/Contents/Resources";
        yield return "/Applications/Codex.app/Contents/MacOS";
        yield return "/Applications/Hermes.app/Contents/Resources/app/bin";
        yield return "/Applications/Claude.app/Contents/Resources/app/bin";
        yield return "/Applications/Claude Code.app/Contents/Resources/app/bin";
        yield return "/Applications/Cursor.app/Contents/Resources/app/bin";
        yield return "/Applications/Visual Studio Code.app/Contents/Resources/app/bin";
        yield return "/opt/homebrew/bin";
        yield return "/opt/homebrew/sbin";
        yield return "/usr/local/bin";
        yield return "/usr/local/sbin";
        yield return "/usr/bin";
        yield return "/bin";
        yield return "/usr/sbin";
        yield return "/sbin";
    }

    private static IEnumerable<string> EnumerateNvmNodeBins(string home)
    {
        string nvmVersions = Path.Combine(home, ".nvm", "versions", "node");
        if (!Directory.Exists(nvmVersions)) yield break;

        IEnumerable<DirectoryInfo> versions;
        try
        {
            versions = new DirectoryInfo(nvmVersions)
                .EnumerateDirectories()
                .OrderByDescending(dir => dir.LastWriteTimeUtc)
                .Take(8)
                .ToArray();
        }
        catch
        {
            yield break;
        }

        foreach (DirectoryInfo version in versions)
        {
            yield return Path.Combine(version.FullName, "bin");
        }
    }

    private static void ApplyWorkingDirectory(ProcessStartInfo psi, string workspace)
    {
        if (string.IsNullOrWhiteSpace(workspace)) return;
        try
        {
            Directory.CreateDirectory(workspace);
            psi.WorkingDirectory = workspace;
        }
        catch
        {
            // Keep the runner alive; the command itself will report a clearer error if needed.
        }
    }

    private static string QuoteArgument(string value)
    {
        return OperatingSystem.IsWindows() ? QuoteWindows(value) : QuoteUnix(value);
    }

    private static string QuoteWindows(string value)
    {
        return "\"" + value.Replace("\\", "\\\\", StringComparison.Ordinal).Replace("\"", "\\\"", StringComparison.Ordinal) + "\"";
    }

    private static string QuoteUnix(string value)
    {
        return "'" + value.Replace("'", "'\"'\"'", StringComparison.Ordinal) + "'";
    }

    private async Task<JsonDocument> PostJsonAsync<TPayload>(
        string path,
        TPayload payload,
        JsonTypeInfo<TPayload> jsonTypeInfo,
        CancellationToken cancellationToken,
        int timeoutSeconds = 35)
    {
        using CancellationTokenSource timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeoutCts.CancelAfter(TimeSpan.FromSeconds(timeoutSeconds));

        string url = _config.Server.TrimEnd('/') + path;
        using HttpRequestMessage req = new(HttpMethod.Post, url);
        req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _config.Token);
        req.Headers.UserAgent.ParseAdd("NiumaClaw-Agent/" + AgentVersion);
        req.Content = new StringContent(JsonSerializer.Serialize(payload, jsonTypeInfo), Encoding.UTF8, "application/json");

        using HttpResponseMessage res = await _http.SendAsync(req, timeoutCts.Token).ConfigureAwait(false);
        string body = await res.Content.ReadAsStringAsync(timeoutCts.Token).ConfigureAwait(false);
        if (!res.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"HTTP {(int)res.StatusCode}: {body}");
        }

        return string.IsNullOrWhiteSpace(body) ? JsonDocument.Parse("{}") : JsonDocument.Parse(body);
    }

    private AgentCapabilities Capabilities()
    {
        return new AgentCapabilities(
            _config.Adapter,
            _config.AdapterType,
            _config.Workspace,
            Environment.MachineName,
            Environment.OSVersion.Platform.ToString(),
            new[] { "chat", "tasks", "terminal", "files", "code", "runner", "desktop-ui" });
    }

    private static string GetString(JsonElement root, string name, string fallback)
    {
        return root.TryGetProperty(name, out JsonElement value) && value.ValueKind == JsonValueKind.String
            ? value.GetString() ?? fallback
            : fallback;
    }

    private static string Trim(string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value) || value.Length <= maxLength) return value;
        return value[..maxLength] + "\n...[truncated]";
    }

    private static void TryKill(Process process)
    {
        try
        {
            if (!process.HasExited) process.Kill(entireProcessTree: true);
        }
        catch
        {
            // Best effort cleanup after a command timeout.
        }
    }

    private void LogLine(string message)
    {
        Log?.Invoke($"[{DateTime.Now:HH:mm:ss}] {message}");
    }

    private void Status(string status)
    {
        StatusChanged?.Invoke(status);
    }
}

internal sealed record AgentCapabilities(
    string Adapter,
    string AdapterType,
    string Workspace,
    string Host,
    string Platform,
    string[] Supports);

internal sealed record AgentHeartbeatRequest(string Platform, string Version, AgentCapabilities Capabilities);

internal sealed record AgentPollRequest(int TimeoutMs, AgentCapabilities Capabilities);

internal sealed record AgentJobStartRequest(string Message);

internal sealed record AgentJobMetadata(string Adapter, string Workspace, string DesktopClient);

internal sealed record AgentJobFinishRequest(bool Ok, string Output, string? Error, AgentJobMetadata Metadata);

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(AgentHeartbeatRequest))]
[JsonSerializable(typeof(AgentPollRequest))]
[JsonSerializable(typeof(AgentJobStartRequest))]
[JsonSerializable(typeof(AgentJobFinishRequest))]
internal sealed partial class AgentJsonContext : JsonSerializerContext
{
}

using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace NiumaClaw.Agent;

internal enum AgentDiagnosticLevel
{
    Pass,
    Warning,
    Fail
}

internal sealed record AgentDiagnosticItem(
    string Name,
    AgentDiagnosticLevel Level,
    string Message,
    string Details = "");

internal sealed class AgentDiagnosticsReport
{
    public AgentDiagnosticsReport(IReadOnlyList<AgentDiagnosticItem> items)
    {
        Items = items;
    }

    public IReadOnlyList<AgentDiagnosticItem> Items { get; }

    public bool HasBlockingFailures => Items.Any(item => item.Level == AgentDiagnosticLevel.Fail);

    public string ToNextActionText()
    {
        AgentDiagnosticItem? firstFailure = Items.FirstOrDefault(item => item.Level == AgentDiagnosticLevel.Fail);
        if (firstFailure != null)
        {
            string details = string.IsNullOrWhiteSpace(firstFailure.Details) ? string.Empty : Environment.NewLine + firstFailure.Details.Trim();
            return $"下一步：先处理「{firstFailure.Name}」。{firstFailure.Message}{details}";
        }

        int warningCount = Items.Count(item => item.Level == AgentDiagnosticLevel.Warning);
        if (warningCount > 0)
        {
            return $"可以启动 Agent。当前有 {warningCount} 个非阻塞提醒，编码/构建类任务前建议补齐这些工具。";
        }

        return "环境诊断通过。保持本窗口打开，然后回到网页端给已绑定员工派任务。";
    }

    public string ToDisplayText()
    {
        StringBuilder sb = new();
        foreach (AgentDiagnosticItem item in Items)
        {
            sb.Append('[').Append(LevelLabel(item.Level)).Append("] ");
            sb.Append(item.Name).Append(": ").Append(item.Message);
            if (!string.IsNullOrWhiteSpace(item.Details))
            {
                sb.AppendLine();
                sb.Append("    ").Append(item.Details.Replace("\n", "\n    ", StringComparison.Ordinal));
            }
            sb.AppendLine();
        }
        return sb.ToString().TrimEnd();
    }

    private static string LevelLabel(AgentDiagnosticLevel level)
    {
        return level switch
        {
            AgentDiagnosticLevel.Pass => "OK",
            AgentDiagnosticLevel.Warning => "WARN",
            _ => "FAIL"
        };
    }
}

internal static class AgentDiagnostics
{
    public static async Task<AgentDiagnosticsReport> RunAsync(AgentConfig config, CancellationToken cancellationToken)
    {
        List<AgentDiagnosticItem> items = new();

        items.Add(CheckConfig(config));
        items.Add(CheckPlatform());
        items.Add(CheckWorkspace(config.Workspace));
        items.Add(await CheckServerAsync(config, cancellationToken).ConfigureAwait(false));
        items.Add(CheckAdapterCommand(config.Adapter));
        items.Add(CheckOptionalTool("git", "Git"));
        items.Add(CheckOptionalTool("node", "Node.js"));
        items.Add(CheckOptionalTool(OperatingSystem.IsWindows() ? "python" : "python3", "Python"));
        items.Add(CheckEffectivePath());

        return new AgentDiagnosticsReport(items);
    }

    private static AgentDiagnosticItem CheckConfig(AgentConfig config)
    {
        if (string.IsNullOrWhiteSpace(config.Server))
        {
            return Fail("客户端配置", "缺少服务器地址，请重新下载客户端。");
        }
        if (string.IsNullOrWhiteSpace(config.Token))
        {
            return Fail("客户端配置", "缺少节点 token，请重新下载客户端。");
        }
        if (config.NodeId <= 0)
        {
            return Fail("客户端配置", "缺少节点 ID，请重新下载客户端。");
        }
        if (!Uri.TryCreate(config.Server, UriKind.Absolute, out Uri? uri)
            || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            return Fail("客户端配置", "服务器地址格式不正确。", config.Server);
        }

        return Pass("客户端配置", $"节点 {config.NodeId} / {config.Adapter} / {config.DeviceName}");
    }

    private static AgentDiagnosticItem CheckPlatform()
    {
        string platform = OperatingSystem.IsWindows()
            ? "Windows"
            : OperatingSystem.IsMacOS()
                ? "macOS"
                : Environment.OSVersion.Platform.ToString();
        return Pass("系统环境", $"{platform} / {Environment.OSVersion.VersionString}");
    }

    private static AgentDiagnosticItem CheckWorkspace(string workspace)
    {
        try
        {
            Directory.CreateDirectory(workspace);
            string testFile = Path.Combine(workspace, ".niumaclaw-write-test");
            File.WriteAllText(testFile, DateTimeOffset.UtcNow.ToString("O"), Encoding.UTF8);
            File.Delete(testFile);
            return Pass("工作区", "可创建、可读写。", workspace);
        }
        catch (Exception ex)
        {
            return Fail("工作区", "无法读写工作区，请换一个本机目录。", $"{workspace}\n{ex.Message}");
        }
    }

    private static async Task<AgentDiagnosticItem> CheckServerAsync(AgentConfig config, CancellationToken cancellationToken)
    {
        try
        {
            using HttpClient http = new() { Timeout = TimeSpan.FromSeconds(8) };
            using HttpRequestMessage req = new(HttpMethod.Post, config.Server.TrimEnd('/') + "/api/agent-nodes/heartbeat");
            req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", config.Token);
            req.Headers.UserAgent.ParseAdd("NiumaClaw-Agent/" + AgentRunner.AgentVersion);
            req.Content = new StringContent(
                JsonSerializer.Serialize(
                    new AgentHeartbeatRequest(
                        Environment.OSVersion.Platform.ToString(),
                        AgentRunner.AgentVersion,
                        BuildCapabilities(config)),
                    AgentJsonContext.Default.AgentHeartbeatRequest),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage res = await http.SendAsync(req, cancellationToken).ConfigureAwait(false);
            string body = await res.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            if (res.IsSuccessStatusCode)
            {
                return Pass("服务器连接", "节点 token 可用，服务器已接受心跳。");
            }

            return Fail("服务器连接", $"服务器返回 HTTP {(int)res.StatusCode}。", Trim(body, 500));
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            return Fail("服务器连接", "无法连接服务器，请检查网络或服务器地址。", ex.Message);
        }
    }

    private static AgentDiagnosticItem CheckAdapterCommand(string adapter)
    {
        string? template = Environment.GetEnvironmentVariable("NIUMACLAW_RUNNER_COMMAND_TEMPLATE");
        string commandName = string.IsNullOrWhiteSpace(template)
            ? AgentRunner.RequiredCommandName(adapter)
            : ExtractCommandName(template) ?? AgentRunner.RequiredCommandName(adapter);

        if (string.Equals(commandName, "echo", StringComparison.OrdinalIgnoreCase))
        {
            return Pass("Agent 命令", "Echo 测试适配器无需外部命令。");
        }

        string? executable = FindExecutable(commandName);
        if (string.IsNullOrWhiteSpace(executable))
        {
            string installHint = commandName.ToLowerInvariant() switch
            {
                "codex" => "请先在终端确认 `codex --version` 可用并已登录。若终端可用但桌面端找不到，重新打开客户端，或用 NIUMACLAW_RUNNER_COMMAND_TEMPLATE 配置完整 codex 路径。",
                "claude" => "请先在终端确认 `claude --version` 可用并已登录。若终端可用但桌面端找不到，重新打开客户端，或用 NIUMACLAW_RUNNER_COMMAND_TEMPLATE 配置完整 claude 路径。",
                "hermes" => "请先安装 Hermes CLI，或在 NIUMACLAW_RUNNER_COMMAND_TEMPLATE 中配置完整命令。",
                _ => "请先安装该 CLI，或通过 NIUMACLAW_RUNNER_COMMAND_TEMPLATE 配置完整命令。"
            };
            return Fail("Agent 命令", $"找不到 `{commandName}`，启动后无法执行任务。", installHint);
        }

        string version = TryReadCommandVersion(executable);
        string message = string.IsNullOrWhiteSpace(template)
            ? $"已找到 `{commandName}`。"
            : $"已找到自定义模板命令 `{commandName}`。";
        return Pass("Agent 命令", message, string.IsNullOrWhiteSpace(version) ? executable : $"{executable}\n{version}");
    }

    private static AgentDiagnosticItem CheckOptionalTool(string commandName, string label)
    {
        string? executable = FindExecutable(commandName);
        if (string.IsNullOrWhiteSpace(executable))
        {
            return Warning(label, $"未找到 {label}，部分任务可能用不到，但编码/构建类任务可能受影响。");
        }

        string version = TryReadCommandVersion(executable);
        return Pass(label, "已找到。", string.IsNullOrWhiteSpace(version) ? executable : $"{executable}\n{version}");
    }

    private static AgentDiagnosticItem CheckEffectivePath()
    {
        IReadOnlyList<string> entries = AgentRunner.BuildEffectivePathEntries();
        string preview = string.Join(Environment.NewLine, entries.Take(12));
        if (entries.Count > 12)
        {
            preview += Environment.NewLine + $"... 共 {entries.Count} 项";
        }
        return Pass("PATH", "已合并桌面 App 常见 CLI 路径。", preview);
    }

    private static AgentCapabilities BuildCapabilities(AgentConfig config)
    {
        return new AgentCapabilities(
            config.Adapter,
            config.AdapterType,
            config.Workspace,
            Environment.MachineName,
            Environment.OSVersion.Platform.ToString(),
            new[] { "chat", "tasks", "terminal", "files", "code", "runner", "desktop-ui", "diagnostics" });
    }

    private static string? ExtractCommandName(string template)
    {
        string value = template.Trim();
        if (string.IsNullOrWhiteSpace(value)) return null;
        if (value[0] == '"' || value[0] == '\'')
        {
            char quote = value[0];
            int end = value.IndexOf(quote, 1);
            return end > 1 ? value[1..end] : null;
        }

        int space = value.IndexOfAny(new[] { ' ', '\t', '\r', '\n' });
        return space > 0 ? value[..space] : value;
    }

    private static string? FindExecutable(string commandName)
    {
        if (string.IsNullOrWhiteSpace(commandName)) return null;

        if (Path.IsPathRooted(commandName) && File.Exists(commandName))
        {
            return commandName;
        }

        foreach (string entry in AgentRunner.BuildEffectivePathEntries())
        {
            foreach (string candidateName in CandidateExecutableNames(commandName))
            {
                string candidate = Path.Combine(entry, candidateName);
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }
        }

        return null;
    }

    private static IEnumerable<string> CandidateExecutableNames(string commandName)
    {
        if (!OperatingSystem.IsWindows())
        {
            yield return commandName;
            yield break;
        }

        string extension = Path.GetExtension(commandName);
        if (!string.IsNullOrWhiteSpace(extension))
        {
            yield return commandName;
            yield break;
        }

        string pathExt = Environment.GetEnvironmentVariable("PATHEXT") ?? ".EXE;.CMD;.BAT;.COM";
        foreach (string ext in pathExt.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            yield return commandName + ext.ToLowerInvariant();
            yield return commandName + ext.ToUpperInvariant();
        }
    }

    private static string TryReadCommandVersion(string executable)
    {
        try
        {
            using CancellationTokenSource cts = new(TimeSpan.FromSeconds(5));
            using Process process = new()
            {
                StartInfo = new ProcessStartInfo(executable)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8
                }
            };
            process.StartInfo.ArgumentList.Add("--version");
            process.StartInfo.Environment["PATH"] = AgentRunner.BuildEffectivePath();
            process.Start();
            Task<string> outputTask = process.StandardOutput.ReadToEndAsync(cts.Token);
            Task<string> errorTask = process.StandardError.ReadToEndAsync(cts.Token);
            try
            {
                process.WaitForExitAsync(cts.Token).GetAwaiter().GetResult();
            }
            catch (OperationCanceledException)
            {
                TryKill(process);
                return string.Empty;
            }
            string output = outputTask.GetAwaiter().GetResult();
            string error = errorTask.GetAwaiter().GetResult();
            return Trim(string.IsNullOrWhiteSpace(output) ? error : output, 240);
        }
        catch
        {
            return string.Empty;
        }
    }

    private static void TryKill(Process process)
    {
        try
        {
            if (!process.HasExited) process.Kill(entireProcessTree: true);
        }
        catch
        {
            // Best effort only; this is a diagnostics helper.
        }
    }

    private static AgentDiagnosticItem Pass(string name, string message, string details = "")
    {
        return new AgentDiagnosticItem(name, AgentDiagnosticLevel.Pass, message, details);
    }

    private static AgentDiagnosticItem Warning(string name, string message, string details = "")
    {
        return new AgentDiagnosticItem(name, AgentDiagnosticLevel.Warning, message, details);
    }

    private static AgentDiagnosticItem Fail(string name, string message, string details = "")
    {
        return new AgentDiagnosticItem(name, AgentDiagnosticLevel.Fail, message, details);
    }

    private static string Trim(string value, int maxLength)
    {
        string text = value.Trim();
        if (text.Length <= maxLength) return text;
        return text[..maxLength] + "...";
    }
}

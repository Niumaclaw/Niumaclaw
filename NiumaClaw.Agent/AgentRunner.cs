using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace NiumaClaw.Agent;

internal sealed class AgentRunner
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);
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
                {
                    platform = Environment.OSVersion.Platform.ToString(),
                    version = "1.0.0",
                    capabilities = Capabilities()
                }, cancellationToken);

                Status("待命中");
                JsonDocument polled = await PostJsonAsync("/api/agent-nodes/jobs/poll", new
                {
                    timeoutMs = 25000,
                    capabilities = Capabilities()
                }, cancellationToken, timeoutSeconds: 40);

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

        await PostJsonAsync($"/api/agent-nodes/jobs/{jobId}/start", new { message = "started" }, cancellationToken, timeoutSeconds: 15);
        (bool ok, string output, string? error) = await RunCommandAsync(prompt, cancellationToken);

        await PostJsonAsync($"/api/agent-nodes/jobs/{jobId}/finish", new
        {
            ok,
            output = Trim(output, 120000),
            error,
            metadata = new
            {
                adapter = _config.Adapter,
                workspace = _config.Workspace,
                desktopClient = "NiumaClaw.Agent"
            }
        }, cancellationToken, timeoutSeconds: 30);

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
            return (false, string.Empty, "No command configured for this adapter.");
        }

        LogLine("$ " + command);
        using CancellationTokenSource timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeoutCts.CancelAfter(TimeSpan.FromMinutes(30));

        ProcessStartInfo psi = BuildShellStartInfo(command);
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
            return (false, output.ToString(), "Command timed out after 30 minutes.");
        }
        catch (Exception ex)
        {
            return (false, output.ToString(), ex.Message);
        }

        string text = output.ToString().Trim();
        return process.ExitCode == 0
            ? (true, string.IsNullOrWhiteSpace(text) ? "Command completed without output." : text, null)
            : (false, text, "Command exited with code " + process.ExitCode + ".");
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
                _ => "codex exec {prompt}"
            };
        }

        return template.Contains("{prompt}", StringComparison.Ordinal)
            ? template.Replace("{prompt}", QuoteArgument(prompt), StringComparison.Ordinal)
            : template;
    }

    private static ProcessStartInfo BuildShellStartInfo(string command)
    {
        if (OperatingSystem.IsWindows())
        {
            return new ProcessStartInfo("cmd.exe", "/c " + command)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };
        }

        return new ProcessStartInfo("/bin/bash", "-lc " + QuoteUnix(command))
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8
        };
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

    private async Task<JsonDocument> PostJsonAsync(string path, object payload, CancellationToken cancellationToken, int timeoutSeconds = 35)
    {
        using CancellationTokenSource timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeoutCts.CancelAfter(TimeSpan.FromSeconds(timeoutSeconds));

        string url = _config.Server.TrimEnd('/') + path;
        using HttpRequestMessage req = new(HttpMethod.Post, url);
        req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _config.Token);
        req.Headers.UserAgent.ParseAdd("NiumaClaw-Agent/1.0.0");
        req.Content = new StringContent(JsonSerializer.Serialize(payload, JsonOptions), Encoding.UTF8, "application/json");

        using HttpResponseMessage res = await _http.SendAsync(req, timeoutCts.Token).ConfigureAwait(false);
        string body = await res.Content.ReadAsStringAsync(timeoutCts.Token).ConfigureAwait(false);
        if (!res.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"HTTP {(int)res.StatusCode}: {body}");
        }

        return string.IsNullOrWhiteSpace(body) ? JsonDocument.Parse("{}") : JsonDocument.Parse(body);
    }

    private object Capabilities()
    {
        return new
        {
            adapter = _config.Adapter,
            adapterType = _config.AdapterType,
            workspace = _config.Workspace,
            host = Environment.MachineName,
            platform = Environment.OSVersion.Platform.ToString(),
            supports = new[] { "chat", "tasks", "terminal", "files", "code", "runner", "desktop-ui" }
        };
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

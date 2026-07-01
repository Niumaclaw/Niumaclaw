using System.Text;
using System.Text.Json;

namespace NiumaClaw.Agent;

internal sealed record AgentConfig(
    string Server,
    string Token,
    long NodeId,
    string Adapter,
    string AdapterType,
    string DeviceName,
    string Workspace)
{
    private const string MacConfigStart = "__NIUMACLAW_CONFIG_B64_START__";
    private const string MacConfigEnd = "__NIUMACLAW_CONFIG_B64_END__";
    private const string NativeConfigStart = "__NIUMACLAW_AGENT_CONFIG_B64_START__";
    private const string NativeConfigEnd = "__NIUMACLAW_AGENT_CONFIG_B64_END__";

    public static bool TryLoad(out AgentConfig? config, out string error)
    {
        config = null;
        error = string.Empty;

        try
        {
            string? json = LoadJsonFromEnvironment()
                ?? LoadJsonFromKnownFiles()
                ?? LoadJsonFromExecutableTail();

            if (string.IsNullOrWhiteSpace(json))
            {
                error = "没有找到客户端配置。请从牛马网页重新下载当前账号专属客户端。";
                return false;
            }

            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;
            string server = RequiredString(root, "server");
            string token = RequiredString(root, "token");
            long nodeId = root.TryGetProperty("nodeId", out JsonElement nodeEl) && nodeEl.TryGetInt64(out long id) ? id : 0;
            string adapter = OptionalString(root, "adapter", "codex");
            string adapterType = OptionalString(root, "adapterType", adapter + "_runner");
            string deviceName = OptionalString(root, "deviceName", "NiumaClaw Agent");
            string workspace = OptionalString(root, "workspace", string.Empty);

            if (nodeId <= 0)
            {
                error = "客户端配置缺少节点 ID。请重新下载。";
                return false;
            }

            config = new AgentConfig(server, token, nodeId, adapter, adapterType, deviceName, ExpandWorkspace(workspace));
            PersistConfigJson(json);
            return true;
        }
        catch (Exception ex)
        {
            error = "读取客户端配置失败：" + ex.Message;
            return false;
        }
    }

    private static string? LoadJsonFromEnvironment()
    {
        string? raw = Environment.GetEnvironmentVariable("NIUMACLAW_AGENT_CONFIG_B64");
        return string.IsNullOrWhiteSpace(raw) ? null : DecodeBase64Payload(raw);
    }

    private static string? LoadJsonFromKnownFiles()
    {
        foreach (string path in KnownConfigPaths())
        {
            if (!File.Exists(path)) continue;
            string text = File.ReadAllText(path, Encoding.UTF8).Trim();
            if (string.IsNullOrWhiteSpace(text)) continue;
            if (text.StartsWith("{", StringComparison.Ordinal)) return text;
            return DecodeBase64Payload(text);
        }

        return null;
    }

    private static IEnumerable<string> KnownConfigPaths()
    {
        string baseDir = AppContext.BaseDirectory;
        yield return Path.Combine(baseDir, "client.json");
        yield return Path.Combine(baseDir, "NiumaClaw Agent.config.b64");
        yield return Path.GetFullPath(Path.Combine(baseDir, "..", "Resources", "NiumaClaw Agent.config.b64"));
        yield return Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "client.json"));
        yield return Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "NiumaClaw Agent.config.b64"));

        foreach (string path in MountedVolumeConfigPaths())
        {
            yield return path;
        }

        yield return AppDataConfigPath();
    }

    private static IEnumerable<string> MountedVolumeConfigPaths()
    {
        if (!OperatingSystem.IsMacOS()) yield break;
        const string volumesRoot = "/Volumes";
        if (!Directory.Exists(volumesRoot)) yield break;

        IEnumerable<DirectoryInfo> volumes;
        try
        {
            volumes = new DirectoryInfo(volumesRoot)
                .EnumerateDirectories("NiumaClaw Agent*")
                .OrderByDescending(d => d.LastWriteTimeUtc)
                .ToArray();
        }
        catch
        {
            yield break;
        }

        foreach (DirectoryInfo volume in volumes)
        {
            yield return Path.Combine(volume.FullName, "client.json");
            yield return Path.Combine(volume.FullName, "NiumaClaw Agent.config.b64");
        }
    }

    private static void PersistConfigJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json)) return;
        try
        {
            string path = AppDataConfigPath();
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllText(path, json, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        }
        catch
        {
            // A mounted DMG config is enough to run; persistence is best effort.
        }
    }

    private static string AppDataConfigPath()
    {
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NiumaClawAgent", "client.json");
    }

    private static string? LoadJsonFromExecutableTail()
    {
        string? processPath = Environment.ProcessPath;
        if (string.IsNullOrWhiteSpace(processPath) || !File.Exists(processPath)) return null;

        byte[] bytes = File.ReadAllBytes(processPath);
        string? payload = ExtractMarkedPayload(bytes, NativeConfigStart, NativeConfigEnd);
        return string.IsNullOrWhiteSpace(payload) ? null : DecodeBase64Payload(payload);
    }

    private static string? ExtractMarkedPayload(byte[] bytes, string startMarker, string endMarker)
    {
        byte[] start = Encoding.ASCII.GetBytes(startMarker);
        byte[] end = Encoding.ASCII.GetBytes(endMarker);
        int startIndex = IndexOf(bytes, start, 0);
        if (startIndex < 0) return null;
        int payloadStart = startIndex + start.Length;
        int endIndex = IndexOf(bytes, end, payloadStart);
        if (endIndex < 0 || endIndex <= payloadStart) return null;
        return Encoding.ASCII.GetString(bytes, payloadStart, endIndex - payloadStart);
    }

    private static int IndexOf(byte[] source, byte[] value, int startIndex)
    {
        for (int i = Math.Max(0, startIndex); i <= source.Length - value.Length; i++)
        {
            int j = 0;
            while (j < value.Length && source[i + j] == value[j]) j++;
            if (j == value.Length) return i;
        }
        return -1;
    }

    private static string DecodeBase64Payload(string raw)
    {
        string value = raw.Trim()
            .Replace(MacConfigStart, string.Empty, StringComparison.Ordinal)
            .Replace(MacConfigEnd, string.Empty, StringComparison.Ordinal)
            .Replace(NativeConfigStart, string.Empty, StringComparison.Ordinal)
            .Replace(NativeConfigEnd, string.Empty, StringComparison.Ordinal);
        int paddingIndex = value.IndexOf('#', StringComparison.Ordinal);
        if (paddingIndex >= 0) value = value[..paddingIndex];
        value = new string(value.Where(c => !char.IsWhiteSpace(c)).ToArray());
        return Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }

    private static string RequiredString(JsonElement root, string name)
    {
        string? value = OptionalString(root, name, null);
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidOperationException("缺少配置项 " + name);
        return value;
    }

    private static string OptionalString(JsonElement root, string name, string? fallback)
    {
        return root.TryGetProperty(name, out JsonElement value) && value.ValueKind == JsonValueKind.String
            ? value.GetString() ?? fallback ?? string.Empty
            : fallback ?? string.Empty;
    }

    private static string ExpandWorkspace(string workspace)
    {
        string fallback = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "NiumaClawWorkspace");
        string value = string.IsNullOrWhiteSpace(workspace) ? fallback : workspace.Trim();
        if (value.StartsWith("~/", StringComparison.Ordinal))
        {
            value = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), value[2..]);
        }
        return Environment.ExpandEnvironmentVariables(value);
    }
}

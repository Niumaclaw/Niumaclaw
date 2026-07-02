using System.Diagnostics;
using System.Text;

namespace NiumaClaw.Agent;

internal sealed record WindowsSelfInstallResult(
    bool Relaunched,
    bool AlreadyInstalled,
    string Message,
    string? InstallPath = null);

internal static class WindowsSelfInstaller
{
    private const string InstalledExeName = "NiumaClaw Agent.exe";

    public static async Task<WindowsSelfInstallResult> EnsureInstalledAsync(CancellationToken cancellationToken)
    {
        if (!OperatingSystem.IsWindows())
        {
            return new WindowsSelfInstallResult(false, true, "非 Windows 系统无需自安装。");
        }

        string? currentExe = Environment.ProcessPath;
        if (string.IsNullOrWhiteSpace(currentExe) || !File.Exists(currentExe))
        {
            return new WindowsSelfInstallResult(false, true, "无法识别当前客户端路径，已跳过自安装。");
        }

        string installRoot = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "NiumaClawAgent");
        string targetExe = Path.Combine(installRoot, InstalledExeName);

        if (PathsEqual(currentExe, targetExe))
        {
            string shortcutMessage = await EnsureShortcutsAsync(targetExe, cancellationToken).ConfigureAwait(false);
            return new WindowsSelfInstallResult(
                false,
                true,
                string.IsNullOrWhiteSpace(shortcutMessage)
                    ? "Windows 客户端已安装。"
                    : "Windows 客户端已安装。" + Environment.NewLine + shortcutMessage,
                targetExe);
        }

        Directory.CreateDirectory(installRoot);
        try
        {
            File.Copy(currentExe, targetExe, overwrite: true);
        }
        catch (IOException) when (File.Exists(targetExe))
        {
            // A previous installed copy may already be running. Relaunch it instead of blocking the user.
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            return new WindowsSelfInstallResult(
                false,
                true,
                "Windows 自安装失败，已继续使用当前客户端窗口。原因：" + ex.Message,
                targetExe);
        }

        string shortcuts = await EnsureShortcutsAsync(targetExe, cancellationToken).ConfigureAwait(false);
        try
        {
            LaunchInstalledClient(targetExe);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            return new WindowsSelfInstallResult(
                false,
                true,
                "Windows 客户端已复制到 " + targetExe + "，但启动已安装版本失败：" + ex.Message,
                targetExe);
        }

        string message = "Windows 客户端已安装到 " + targetExe + "，正在切换到已安装版本。";
        if (!string.IsNullOrWhiteSpace(shortcuts))
        {
            message += Environment.NewLine + shortcuts;
        }

        return new WindowsSelfInstallResult(true, false, message, targetExe);
    }

    private static async Task<string> EnsureShortcutsAsync(string targetExe, CancellationToken cancellationToken)
    {
        string script = @"
$ErrorActionPreference = 'Stop'
$target = __TARGET__
$working = Split-Path -Parent $target
$shell = New-Object -ComObject WScript.Shell
$desktop = [Environment]::GetFolderPath('DesktopDirectory')
if (-not [string]::IsNullOrWhiteSpace($desktop)) {
  $shortcut = $shell.CreateShortcut((Join-Path $desktop 'NiumaClaw Agent.lnk'))
  $shortcut.TargetPath = $target
  $shortcut.WorkingDirectory = $working
  $shortcut.IconLocation = $target + ',0'
  $shortcut.Save()
}
$programs = [Environment]::GetFolderPath('Programs')
if (-not [string]::IsNullOrWhiteSpace($programs)) {
  $startMenuDir = Join-Path $programs 'NiumaClaw'
  New-Item -ItemType Directory -Path $startMenuDir -Force | Out-Null
  $shortcut = $shell.CreateShortcut((Join-Path $startMenuDir 'NiumaClaw Agent.lnk'))
  $shortcut.TargetPath = $target
  $shortcut.WorkingDirectory = $working
  $shortcut.IconLocation = $target + ',0'
  $shortcut.Save()
}
".Replace("__TARGET__", PsSingleQuote(targetExe), StringComparison.Ordinal);

        ProcessStartInfo psi = new("powershell.exe")
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8
        };
        psi.ArgumentList.Add("-NoProfile");
        psi.ArgumentList.Add("-ExecutionPolicy");
        psi.ArgumentList.Add("Bypass");
        psi.ArgumentList.Add("-EncodedCommand");
        psi.ArgumentList.Add(Convert.ToBase64String(Encoding.Unicode.GetBytes(script)));

        try
        {
            using Process process = new() { StartInfo = psi };
            process.Start();
            string stdout = await process.StandardOutput.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
            string stderr = await process.StandardError.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
            await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
            if (process.ExitCode == 0)
            {
                return "已创建桌面和开始菜单快捷方式。";
            }

            string detail = string.IsNullOrWhiteSpace(stderr) ? stdout : stderr;
            return "快捷方式创建失败，但客户端仍可从安装目录启动：" + detail.Trim();
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            return "快捷方式创建失败，但客户端仍可从安装目录启动：" + ex.Message;
        }
    }

    private static void LaunchInstalledClient(string targetExe)
    {
        ProcessStartInfo psi = new(targetExe)
        {
            UseShellExecute = true,
            WorkingDirectory = Path.GetDirectoryName(targetExe) ?? string.Empty
        };
        Process.Start(psi);
    }

    private static bool PathsEqual(string left, string right)
    {
        return string.Equals(
            Path.GetFullPath(left).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
            Path.GetFullPath(right).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
            StringComparison.OrdinalIgnoreCase);
    }

    private static string PsSingleQuote(string value)
    {
        return "'" + value.Replace("'", "''", StringComparison.Ordinal) + "'";
    }
}

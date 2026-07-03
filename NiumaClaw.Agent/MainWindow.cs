using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Threading;

namespace NiumaClaw.Agent;

internal sealed class MainWindow : Window
{
    private readonly TextBlock _statusText;
    private readonly TextBlock _metaText;
    private readonly TextBlock _wizardText;
    private readonly TextBlock _nextActionText;
    private readonly TextBlock _diagnosticsText;
    private readonly TextBox _logBox;
    private readonly Button _startButton;
    private readonly Button _stopButton;
    private readonly Button _diagnosticsButton;
    private readonly Button _openWorkspaceButton;
    private CancellationTokenSource? _runnerCts;
    private CancellationTokenSource? _diagnosticsCts;
    private AgentRunner? _runner;
    private AgentConfig? _config;
    private bool _lastDiagnosticsPassed;
    private bool _isDiagnosing;

    public MainWindow()
    {
        Title = "NiumaClaw Agent";
        Width = 760;
        Height = 560;
        MinWidth = 620;
        MinHeight = 460;
        Background = new SolidColorBrush(Color.FromRgb(246, 248, 252));

        _statusText = new TextBlock
        {
            Text = "初始化",
            FontSize = 24,
            FontWeight = FontWeight.Bold,
            Foreground = new SolidColorBrush(Color.FromRgb(15, 118, 110))
        };
        _metaText = new TextBlock
        {
            TextWrapping = TextWrapping.Wrap,
            Foreground = new SolidColorBrush(Color.FromRgb(71, 85, 105))
        };
        _wizardText = new TextBlock
        {
            Text = BuildWizardText("等待读取客户端配置", configOk: false, diagnosticsOk: false, runnerOk: false),
            TextWrapping = TextWrapping.Wrap,
            FontSize = 13,
            FontWeight = FontWeight.SemiBold,
            Foreground = new SolidColorBrush(Color.FromRgb(30, 41, 59))
        };
        _nextActionText = new TextBlock
        {
            Text = "下一步：正在读取账号专属客户端配置。",
            TextWrapping = TextWrapping.Wrap,
            Foreground = new SolidColorBrush(Color.FromRgb(30, 64, 175))
        };
        _diagnosticsText = new TextBlock
        {
            Text = "等待环境诊断...",
            TextWrapping = TextWrapping.Wrap,
            FontFamily = FontFamily.Parse("Menlo, Consolas, monospace"),
            FontSize = 12,
            Foreground = new SolidColorBrush(Color.FromRgb(51, 65, 85))
        };
        _logBox = new TextBox
        {
            IsReadOnly = true,
            AcceptsReturn = true,
            TextWrapping = TextWrapping.Wrap,
            FontFamily = FontFamily.Parse("Menlo, Consolas, monospace"),
            FontSize = 12,
            Background = Brushes.White,
            Foreground = new SolidColorBrush(Color.FromRgb(15, 23, 42)),
            BorderBrush = new SolidColorBrush(Color.FromRgb(203, 213, 225)),
            MinHeight = 260
        };
        _startButton = new Button
        {
            Content = "启动 Agent",
            Padding = new Thickness(16, 9),
            Background = new SolidColorBrush(Color.FromRgb(15, 118, 110)),
            Foreground = Brushes.White,
            FontWeight = FontWeight.Bold
        };
        _diagnosticsButton = new Button
        {
            Content = "重新诊断",
            Padding = new Thickness(16, 9)
        };
        _openWorkspaceButton = new Button
        {
            Content = "打开工作区",
            Padding = new Thickness(16, 9),
            IsEnabled = false
        };
        _stopButton = new Button
        {
            Content = "停止",
            Padding = new Thickness(16, 9),
            IsEnabled = false
        };

        _startButton.Click += async (_, _) => await StartRunnerFromButtonAsync();
        _diagnosticsButton.Click += async (_, _) => await RunDiagnosticsAsync(startWhenOk: false);
        _openWorkspaceButton.Click += (_, _) => OpenWorkspace();
        _stopButton.Click += (_, _) => StopRunner();
        Closed += (_, _) =>
        {
            _diagnosticsCts?.Cancel();
            StopRunner();
        };

        Content = BuildLayout();
    }

    protected override async void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        if (!AgentConfig.TryLoad(out _config, out string error) || _config == null)
        {
            _statusText.Text = "缺少配置";
            _metaText.Text = error;
            _wizardText.Text = BuildWizardText("客户端配置缺失", configOk: false, diagnosticsOk: false, runnerOk: false);
            _nextActionText.Text = "下一步：回到网页端重新下载当前账号专属客户端。";
            _diagnosticsText.Text = "[FAIL] 客户端配置: " + error;
            AppendLog(error);
            SetRunnerButtons(isRunning: false, canStart: false, blockedReason: "需重新下载客户端");
            return;
        }

        _metaText.Text = $"{_config.DeviceName} / 节点 {_config.NodeId} / Agent v{AgentRunner.AgentVersion}\n{_config.Server}\n工作区：{_config.Workspace}";
        _wizardText.Text = BuildWizardText("已读取账号专属配置", configOk: true, diagnosticsOk: false, runnerOk: false);
        _nextActionText.Text = "下一步：自动检查服务器、工作区和本机 Agent 命令。";
        _openWorkspaceButton.IsEnabled = true;
        WindowsSelfInstallResult installResult = await WindowsSelfInstaller.EnsureInstalledAsync(CancellationToken.None);
        if (!string.IsNullOrWhiteSpace(installResult.Message) && OperatingSystem.IsWindows())
        {
            AppendLog(installResult.Message);
        }
        if (installResult.Relaunched)
        {
            _statusText.Text = "已安装";
            _wizardText.Text = BuildWizardText("已安装到本机应用目录", configOk: true, diagnosticsOk: false, runnerOk: false);
            _nextActionText.Text = "下一步：等待安装后的 NiumaClaw Agent 自动启动。";
            _diagnosticsText.Text = "已安装到本机应用目录，并正在启动安装后的 NiumaClaw Agent。这个临时下载窗口可以关闭。";
            SetRunnerButtons(isRunning: false, canStart: false, blockedReason: "正在启动安装版");
            await Task.Delay(800);
            Close();
            return;
        }

        await RunDiagnosticsAsync(startWhenOk: true);
    }

    private Control BuildLayout()
    {
        Grid root = new()
        {
            RowDefinitions = new RowDefinitions("Auto,Auto,Auto,Auto,*,Auto"),
            Margin = new Thickness(24),
            RowSpacing = 12
        };

        StackPanel header = new()
        {
            Spacing = 6,
            Children =
            {
                new TextBlock
                {
                    Text = "NiumaClaw 桌面 Agent",
                    FontSize = 14,
                    FontWeight = FontWeight.Bold,
                    Foreground = new SolidColorBrush(Color.FromRgb(100, 116, 139))
                },
                _statusText,
                _metaText
            }
        };
        root.Children.Add(header);

        Border info = new()
        {
            [Grid.RowProperty] = 1,
            Padding = new Thickness(14),
            CornerRadius = new CornerRadius(8),
            Background = new SolidColorBrush(Color.FromRgb(239, 246, 255)),
            BorderBrush = new SolidColorBrush(Color.FromRgb(191, 219, 254)),
            BorderThickness = new Thickness(1),
            Child = new TextBlock
            {
                Text = "保持本窗口打开即可接收网页派发的任务。任务会在本机工作区运行 Codex、Hermes 或 Claude Code。",
                TextWrapping = TextWrapping.Wrap,
                Foreground = new SolidColorBrush(Color.FromRgb(30, 64, 175))
            }
        };
        root.Children.Add(info);

        Border wizardPanel = new()
        {
            [Grid.RowProperty] = 2,
            Padding = new Thickness(14),
            CornerRadius = new CornerRadius(8),
            Background = Brushes.White,
            BorderBrush = new SolidColorBrush(Color.FromRgb(191, 219, 254)),
            BorderThickness = new Thickness(1),
            Child = new StackPanel
            {
                Spacing = 8,
                Children =
                {
                    _wizardText,
                    _nextActionText
                }
            }
        };
        root.Children.Add(wizardPanel);

        Border diagnosticsPanel = new()
        {
            [Grid.RowProperty] = 3,
            Padding = new Thickness(12),
            CornerRadius = new CornerRadius(8),
            Background = new SolidColorBrush(Color.FromRgb(248, 250, 252)),
            BorderBrush = new SolidColorBrush(Color.FromRgb(203, 213, 225)),
            BorderThickness = new Thickness(1),
            Child = _diagnosticsText
        };
        root.Children.Add(diagnosticsPanel);

        Border logPanel = new()
        {
            [Grid.RowProperty] = 4,
            Padding = new Thickness(12),
            CornerRadius = new CornerRadius(8),
            Background = Brushes.White,
            BorderBrush = new SolidColorBrush(Color.FromRgb(226, 232, 240)),
            BorderThickness = new Thickness(1),
            Child = _logBox
        };
        root.Children.Add(logPanel);

        StackPanel buttons = new()
        {
            [Grid.RowProperty] = 5,
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Right,
            Spacing = 10,
            Children = { _openWorkspaceButton, _diagnosticsButton, _startButton, _stopButton }
        };
        root.Children.Add(buttons);

        return root;
    }

    private async Task StartRunnerFromButtonAsync()
    {
        if (_config == null || _runnerCts != null) return;
        if (!_lastDiagnosticsPassed)
        {
            await RunDiagnosticsAsync(startWhenOk: true);
            return;
        }

        StartRunner();
    }

    private async Task RunDiagnosticsAsync(bool startWhenOk)
    {
        if (_config == null || _runnerCts != null) return;

        _diagnosticsCts?.Cancel();
        _diagnosticsCts?.Dispose();
        _diagnosticsCts = new CancellationTokenSource();
        CancellationToken cancellationToken = _diagnosticsCts.Token;
        _isDiagnosing = true;

        SetRunnerButtons(isRunning: false, canStart: false, blockedReason: "正在诊断");
        _diagnosticsButton.IsEnabled = false;
        _statusText.Text = "诊断中";
        _wizardText.Text = BuildWizardText("正在检查运行环境", configOk: true, diagnosticsOk: false, runnerOk: false);
        _nextActionText.Text = "下一步：等待诊断完成。通过后会自动启动并等待网页派发任务。";
        _diagnosticsText.Text = "正在检查服务器、工作区、Agent 命令和本机工具...";
        AppendLog("开始环境诊断。");

        try
        {
            AgentDiagnosticsReport report = await AgentDiagnostics.RunAsync(_config, cancellationToken);
            _lastDiagnosticsPassed = !report.HasBlockingFailures;
            _diagnosticsText.Text = report.ToDisplayText();
            _nextActionText.Text = report.ToNextActionText();
            AppendLog("环境诊断完成：" + (_lastDiagnosticsPassed ? "通过" : "未通过"));

            if (!_lastDiagnosticsPassed)
            {
                _statusText.Text = "诊断未通过";
                _wizardText.Text = BuildWizardText("需要先修复环境问题", configOk: true, diagnosticsOk: false, runnerOk: false);
                SetRunnerButtons(isRunning: false, canStart: false, blockedReason: "先修复诊断");
                return;
            }

            _statusText.Text = "诊断通过";
            _wizardText.Text = BuildWizardText("环境已就绪", configOk: true, diagnosticsOk: true, runnerOk: false);
            SetRunnerButtons(isRunning: false, canStart: true);
            if (startWhenOk)
            {
                StartRunner();
            }
        }
        catch (OperationCanceledException)
        {
            AppendLog("环境诊断已取消。");
        }
        catch (Exception ex)
        {
            _lastDiagnosticsPassed = false;
            _statusText.Text = "诊断失败";
            _wizardText.Text = BuildWizardText("诊断执行失败", configOk: true, diagnosticsOk: false, runnerOk: false);
            _nextActionText.Text = "下一步：检查网络、客户端配置和本机权限，然后点击“重新诊断”。";
            _diagnosticsText.Text = "[FAIL] 环境诊断: " + ex.Message;
            AppendLog("环境诊断失败：" + ex.Message);
            SetRunnerButtons(isRunning: false, canStart: false, blockedReason: "重新诊断");
        }
        finally
        {
            _isDiagnosing = false;
            _diagnosticsButton.IsEnabled = _config != null;
        }
    }

    private void StartRunner()
    {
        if (_config == null || _runnerCts != null) return;
        _runnerCts = new CancellationTokenSource();
        _runner = new AgentRunner(_config);
        _runner.Log += AppendLog;
        _runner.StatusChanged += SetStatus;
        SetRunnerButtons(isRunning: true, canStart: false);
        _statusText.Text = "启动中";
        _wizardText.Text = BuildWizardText("正在连接服务器", configOk: true, diagnosticsOk: true, runnerOk: false);
        _nextActionText.Text = "下一步：保持窗口打开，客户端会自动注册并等待网页任务。";
        AppendLog("Agent 已启动，正在等待网页派发任务。");
        _ = Task.Run(async () =>
        {
            try
            {
                await _runner.RunAsync(_runnerCts.Token).ConfigureAwait(false);
            }
            finally
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    _runnerCts?.Dispose();
                    _runnerCts = null;
                    _runner = null;
                    SetRunnerButtons(isRunning: false, canStart: _config != null && _lastDiagnosticsPassed);
                    _statusText.Text = "已停止";
                    _wizardText.Text = BuildWizardText("Agent 已停止", configOk: _config != null, diagnosticsOk: _lastDiagnosticsPassed, runnerOk: false);
                    _nextActionText.Text = _lastDiagnosticsPassed ? "下一步：点击“启动 Agent”重新连接并等待网页任务。" : "下一步：点击“重新诊断”检查环境。";
                });
            }
        });
    }

    private void StopRunner()
    {
        if (_runnerCts == null) return;
        _statusText.Text = "正在停止";
        _nextActionText.Text = "下一步：等待当前连接停止。";
        _runnerCts?.Cancel();
    }

    private void SetRunnerButtons(bool isRunning, bool canStart, string? blockedReason = null)
    {
        _startButton.Content = isRunning ? "Agent 已运行" : (canStart ? "启动 Agent" : (blockedReason ?? (_isDiagnosing ? "正在诊断" : "暂不可启动")));
        _startButton.IsEnabled = canStart;
        _stopButton.IsEnabled = isRunning;
    }

    private void SetStatus(string status)
    {
        Dispatcher.UIThread.Post(() =>
        {
            _statusText.Text = status;
            if (status == "已连接，待命中")
            {
                _wizardText.Text = BuildWizardText("已连接，等待网页派工", configOk: true, diagnosticsOk: true, runnerOk: true);
                _nextActionText.Text = "下一步：回到网页端，给绑定到该节点的员工派发任务。";
            }
            else if (status == "执行任务")
            {
                _wizardText.Text = BuildWizardText("正在执行网页派发的任务", configOk: true, diagnosticsOk: true, runnerOk: true);
                _nextActionText.Text = "下一步：等待任务完成，结果会回传到网页端工作日志。";
            }
            else if (status == "连接异常")
            {
                _wizardText.Text = BuildWizardText("连接异常，正在自动重试", configOk: true, diagnosticsOk: true, runnerOk: false);
                _nextActionText.Text = "下一步：保持窗口打开。若持续异常，请检查网络、服务器地址或重新下载客户端。";
            }
        });
    }

    private void AppendLog(string line)
    {
        Dispatcher.UIThread.Post(() =>
        {
            string current = _logBox.Text ?? string.Empty;
            _logBox.Text = string.IsNullOrEmpty(current) ? line : current + Environment.NewLine + line;
            _logBox.CaretIndex = _logBox.Text.Length;
        });
    }

    private void OpenWorkspace()
    {
        if (_config == null) return;
        try
        {
            Directory.CreateDirectory(_config.Workspace);
            if (OperatingSystem.IsWindows())
            {
                Process.Start(new ProcessStartInfo(_config.Workspace) { UseShellExecute = true });
            }
            else if (OperatingSystem.IsMacOS())
            {
                Process.Start("open", _config.Workspace);
            }
            else
            {
                Process.Start("xdg-open", _config.Workspace);
            }
            AppendLog("已打开工作区：" + _config.Workspace);
        }
        catch (Exception ex)
        {
            AppendLog("打开工作区失败：" + ex.Message);
            _nextActionText.Text = "下一步：请检查工作区路径是否存在且当前用户有权限。";
        }
    }

    private static string BuildWizardText(string current, bool configOk, bool diagnosticsOk, bool runnerOk)
    {
        return "首次启动向导\n"
            + $"{StepLabel(configOk)} 1. 读取账号专属配置\n"
            + $"{StepLabel(diagnosticsOk)} 2. 检查服务器、工作区和本机 CLI\n"
            + $"{StepLabel(runnerOk)} 3. 连接服务器并等待网页任务\n"
            + $"当前：{current}";
    }

    private static string StepLabel(bool ok)
    {
        return ok ? "[OK]" : "[WAIT]";
    }
}

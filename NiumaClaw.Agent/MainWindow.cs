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
    private readonly TextBlock _diagnosticsText;
    private readonly TextBox _logBox;
    private readonly Button _startButton;
    private readonly Button _stopButton;
    private readonly Button _diagnosticsButton;
    private CancellationTokenSource? _runnerCts;
    private CancellationTokenSource? _diagnosticsCts;
    private AgentRunner? _runner;
    private AgentConfig? _config;
    private bool _lastDiagnosticsPassed;

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
        _stopButton = new Button
        {
            Content = "停止",
            Padding = new Thickness(16, 9),
            IsEnabled = false
        };

        _startButton.Click += async (_, _) => await StartRunnerFromButtonAsync();
        _diagnosticsButton.Click += async (_, _) => await RunDiagnosticsAsync(startWhenOk: false);
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
            _diagnosticsText.Text = "[FAIL] 客户端配置: " + error;
            AppendLog(error);
            SetRunnerButtons(isRunning: false, canStart: false);
            return;
        }

        _metaText.Text = $"{_config.DeviceName} / 节点 {_config.NodeId}\n{_config.Server}\n工作区：{_config.Workspace}";
        WindowsSelfInstallResult installResult = await WindowsSelfInstaller.EnsureInstalledAsync(CancellationToken.None);
        if (!string.IsNullOrWhiteSpace(installResult.Message) && OperatingSystem.IsWindows())
        {
            AppendLog(installResult.Message);
        }
        if (installResult.Relaunched)
        {
            _statusText.Text = "已安装";
            _diagnosticsText.Text = "已安装到本机应用目录，并正在启动安装后的 NiumaClaw Agent。这个临时下载窗口可以关闭。";
            SetRunnerButtons(isRunning: false, canStart: false);
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
            RowDefinitions = new RowDefinitions("Auto,Auto,Auto,*,Auto"),
            Margin = new Thickness(24),
            RowSpacing = 16
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

        Border diagnosticsPanel = new()
        {
            [Grid.RowProperty] = 2,
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
            [Grid.RowProperty] = 3,
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
            [Grid.RowProperty] = 4,
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Right,
            Spacing = 10,
            Children = { _diagnosticsButton, _startButton, _stopButton }
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

        SetRunnerButtons(isRunning: false, canStart: false);
        _diagnosticsButton.IsEnabled = false;
        _statusText.Text = "诊断中";
        _diagnosticsText.Text = "正在检查服务器、工作区、Agent 命令和本机工具...";
        AppendLog("开始环境诊断。");

        try
        {
            AgentDiagnosticsReport report = await AgentDiagnostics.RunAsync(_config, cancellationToken);
            _lastDiagnosticsPassed = !report.HasBlockingFailures;
            _diagnosticsText.Text = report.ToDisplayText();
            AppendLog("环境诊断完成：" + (_lastDiagnosticsPassed ? "通过" : "未通过"));

            if (!_lastDiagnosticsPassed)
            {
                _statusText.Text = "诊断未通过";
                SetRunnerButtons(isRunning: false, canStart: false);
                return;
            }

            _statusText.Text = "诊断通过";
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
            _diagnosticsText.Text = "[FAIL] 环境诊断: " + ex.Message;
            AppendLog("环境诊断失败：" + ex.Message);
            SetRunnerButtons(isRunning: false, canStart: false);
        }
        finally
        {
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
                });
            }
        });
    }

    private void StopRunner()
    {
        if (_runnerCts == null) return;
        _statusText.Text = "正在停止";
        _runnerCts?.Cancel();
    }

    private void SetRunnerButtons(bool isRunning, bool canStart)
    {
        _startButton.Content = isRunning ? "Agent 已运行" : "启动 Agent";
        _startButton.IsEnabled = canStart;
        _stopButton.IsEnabled = isRunning;
    }

    private void SetStatus(string status)
    {
        Dispatcher.UIThread.Post(() => _statusText.Text = status);
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
}

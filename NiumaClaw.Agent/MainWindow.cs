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
    private readonly TextBox _logBox;
    private readonly Button _startButton;
    private readonly Button _stopButton;
    private CancellationTokenSource? _runnerCts;
    private AgentRunner? _runner;
    private AgentConfig? _config;

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
        _stopButton = new Button
        {
            Content = "停止",
            Padding = new Thickness(16, 9),
            IsEnabled = false
        };

        _startButton.Click += (_, _) => StartRunner();
        _stopButton.Click += (_, _) => StopRunner();
        Closed += (_, _) => StopRunner();

        Content = BuildLayout();
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        if (!AgentConfig.TryLoad(out _config, out string error) || _config == null)
        {
            _statusText.Text = "缺少配置";
            _metaText.Text = error;
            AppendLog(error);
            _startButton.IsEnabled = false;
            return;
        }

        _metaText.Text = $"{_config.DeviceName} / 节点 {_config.NodeId}\n{_config.Server}\n工作区：{_config.Workspace}";
        StartRunner();
    }

    private Control BuildLayout()
    {
        Grid root = new()
        {
            RowDefinitions = new RowDefinitions("Auto,Auto,*,Auto"),
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

        Border logPanel = new()
        {
            [Grid.RowProperty] = 2,
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
            [Grid.RowProperty] = 3,
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Right,
            Spacing = 10,
            Children = { _startButton, _stopButton }
        };
        root.Children.Add(buttons);

        return root;
    }

    private void StartRunner()
    {
        if (_config == null || _runnerCts != null) return;
        _runnerCts = new CancellationTokenSource();
        _runner = new AgentRunner(_config);
        _runner.Log += AppendLog;
        _runner.StatusChanged += SetStatus;
        _startButton.IsEnabled = false;
        _stopButton.IsEnabled = true;
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
                    _startButton.IsEnabled = _config != null;
                    _stopButton.IsEnabled = false;
                });
            }
        });
    }

    private void StopRunner()
    {
        _runnerCts?.Cancel();
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

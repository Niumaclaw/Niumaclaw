using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;

namespace NiumaClaw.Agent;

public sealed class App : Application
{
    public override void OnFrameworkInitializationCompleted()
    {
        Styles.Add(new FluentTheme());

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}

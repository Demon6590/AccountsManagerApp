using AccountsManagerApp.Desktop.Windows.RegistrationWindow;
using AccountsManagerApp.Desktop.Windows.RestoringAccessWindows;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace AccountsManagerApp.Desktop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new AuthWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}
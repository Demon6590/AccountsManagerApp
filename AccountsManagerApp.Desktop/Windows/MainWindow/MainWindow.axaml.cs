using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AccountsManagerApp.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Exit_OnClick(object? sender, RoutedEventArgs e)
    {
        var Window = new AuthWindow();
        Window.Show();
        this.Close();
    }
}
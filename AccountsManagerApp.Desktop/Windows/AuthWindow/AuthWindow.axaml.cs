using System;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

using MsBox.Avalonia;

namespace AccountsManagerApp.Desktop;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
    }

    private async void Button_Login_OnClick(object? sender, RoutedEventArgs e)
    {
        var login = Input_Login.Value;
        var password = Input_Password.Value;

        var title = Application.Current?.Resources["Title"]?.ToString();
        var message = $"{login}, {password}.";
        
        await MessageBoxManager
            .GetMessageBoxStandard(title, message)
            .ShowAsync();
    }

    private void Button_Cancel_OnClick(object? sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }
}
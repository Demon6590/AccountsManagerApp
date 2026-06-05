using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using MsBox.Avalonia;

namespace AccountsManagerApp.Desktop.Windows.RegistrationWindow;

public partial class RegistrationWindow : Window
{
    public RegistrationWindow()
    {
        InitializeComponent();
    }

    private void Button_Cancel_OnClick(object? sender, RoutedEventArgs e)
    {
        var Window = new AuthWindow();
        Window.Show();
        this.Close();

    }

    private async void Button_Login_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Input_Password_Confirm.Value != Input_Password.Value)
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Повторный пароль не соответствует паролю")
                .ShowAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using AccountsManagerApp.Desktop.Data;
using AccountsManagerApp.Desktop.Windows.RegistrationWindow;
using AccountsManagerApp.Desktop.Windows.RestoringAccessWindows;

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
        
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Поля почты и пароля не могут быть пустыми")
                .ShowAsync();
            return;
        }
        if (Input_Login.HasErrors || Input_Password.HasErrors)
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Пожалуйста, исправьте ошибки в полях ввода перед регистрацией.")
                .ShowAsync();
            return;
        }



        string filePath = Path.Combine("Data", "users.json");
        List<UserAccount> usersList = new();
        if (File.Exists(filePath))
        {
            string existingJson = await File.ReadAllTextAsync(filePath);
            if (!string.IsNullOrWhiteSpace(existingJson))
            {
                usersList = JsonSerializer.Deserialize<List<UserAccount>>(existingJson) ?? new List<UserAccount>();
            }
        }
        if (!usersList.Any(u => string.Equals(u.Email, login, StringComparison.OrdinalIgnoreCase)))
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка авторизаций", "Пользователь с такой почтой не зарегистрирован")
                .ShowAsync();
            return;
        }
        var Window = new MainWindow();
        Window.Show();
        this.Close();
    }

    private void Button_Cancel_OnClick(object? sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    private void Open_RegistrationWindow_OnClick(object? sender, RoutedEventArgs e)
    {
        var authWindow = new RegistrationWindow();
        authWindow.Show();
        this.Close();
    }

    private void Open_RestoringAccessWindow_OnClick(object? sender, RoutedEventArgs e)
    {
        var authWindow = new RestoringAccessWindow();
        authWindow.Show();
        this.Close();
    }
}
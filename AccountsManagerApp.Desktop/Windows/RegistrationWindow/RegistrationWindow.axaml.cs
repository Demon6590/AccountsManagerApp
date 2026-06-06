using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using AccountsManagerApp.Desktop.Data;
using AccountsManagerApp.Desktop.Windows.RestoringAccessWindows;

using Avalonia.Controls;
using Avalonia.Interactivity;

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
        if (string.IsNullOrWhiteSpace(Input_Mail.Value) || string.IsNullOrWhiteSpace(Input_Password.Value))
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Поля почты и пароля не могут быть пустыми")
                .ShowAsync();
            return;
        }

        if (Input_Mail.HasErrors || Input_Password.HasErrors)
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Пожалуйста, исправьте ошибки в полях ввода перед регистрацией.")
                .ShowAsync();
            return;
        }

        if (Input_Password_Confirm.Value != Input_Password.Value)
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Повторный пароль не соответствует паролю")
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

        if (usersList.Any(u => string.Equals(u.Email, Input_Mail.Value)))
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка регистрации", "Пользователь с такой почтой уже зарегистрирован")
                .ShowAsync();
            return;
        }

        var newUser = new UserAccount(Input_Mail.Value, Input_Password.Value);
        usersList.Add(newUser);

        string updatedJson = JsonSerializer.Serialize(usersList);
        await File.WriteAllTextAsync(filePath, updatedJson);

        await MessageBoxManager
            .GetMessageBoxStandard("Успех", "Регистрация успешно завершена!")
            .ShowAsync();
        var Window = new AuthWindow();
        Window.Show();
        this.Close();
    }

    private void Open_AuthWindow_OnClick(object? sender, RoutedEventArgs e)
    {
        var authWindow = new AuthWindow();
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
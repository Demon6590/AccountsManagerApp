using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using AccountsManagerApp.Desktop.Data;

using Avalonia.Controls;
using Avalonia.Interactivity;

using MsBox.Avalonia;

namespace AccountsManagerApp.Desktop.Windows.RestoringAccessWindows;

public partial class RestoringAccessWindow : Window
{
    public RestoringAccessWindow()
    {
        InitializeComponent();
    }

    private void Button_Back_OnClick(object? sender, RoutedEventArgs e)
    {
        var authWindow = new AuthWindow();
        authWindow.Show();
        this.Close();
    }

    private async void Button_Recover_OnClick(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Input_Mail.Value))
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Поле электронной почты не может быть пустым")
                .ShowAsync();
            return;
        }

        if (Input_Mail.HasErrors)
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Пожалуйста, исправьте ошибки в поле ввода перед восстановлением.")
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

        var user = usersList.FirstOrDefault(u => string.Equals(u.Email, Input_Mail.Value));

        if (user == null)
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка восстановления", "E-mail не найден в системе")
                .ShowAsync();
            return;
        }

        usersList.Remove(user);
        var updatedUser = user with { Password = "Temp1234" };
        usersList.Add(updatedUser);
        string updatedJson = JsonSerializer.Serialize(usersList);
        await File.WriteAllTextAsync(filePath, updatedJson);
        await MessageBoxManager
            .GetMessageBoxStandard("Успех",
                "Временный пароль отправлен на вашу почту. Проверьте папку «Входящие» и «Спам»")
            .ShowAsync();

        var authWindow = new AuthWindow();
        authWindow.Show();
        this.Close();
    }
}
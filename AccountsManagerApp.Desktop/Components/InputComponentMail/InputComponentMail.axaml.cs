using System;
using System.Text.RegularExpressions;

using Avalonia;
using Avalonia.Controls;


namespace AccountsManagerApp.Desktop.Components;

public partial class InputComponentMail : UserControl
{
    public static readonly StyledProperty<object> LabelProperty =
        AvaloniaProperty.Register<InputComponentMail, object>(nameof(Label));

    public object Label
    {
        get => GetValue(InputComponentMail.LabelProperty);
        set => SetValue(InputComponentMail.LabelProperty, value);
    }

    public static readonly StyledProperty<string?> ValueProperty =
        AvaloniaProperty.Register<InputComponentMail, string?>(nameof(Value));

    public string? Value
    {
        get => this.GetValue<string?>(InputComponentMail.ValueProperty);
        set => this.SetValue(InputComponentMail.ValueProperty, value);
    }

    public static readonly StyledProperty<string?> PlaceholderProperty =
        AvaloniaProperty.Register<InputComponentMail, string?>(nameof(Placeholder));

    public string? Placeholder
    {
        get => this.GetValue<string?>(InputComponentMail.PlaceholderProperty);
        set => this.SetValue(InputComponentMail.PlaceholderProperty, value);
    }

    public InputComponentMail()
    {
        InitializeComponent();
    }

    private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == ValueProperty)
        {
            ValidateEmail(change.NewValue as string);
        }
    }

    public void ValidateEmail(string? text)
    {
        var textBox = this.FindControl<TextBox>("Input");
        if (textBox == null) return;


        if (string.IsNullOrWhiteSpace(text))
        {
            DataValidationErrors.SetError(textBox, new Exception("E-mail не может быть пустым"));
            return;
        }


        if (!EmailRegex.IsMatch(text))
        {
            DataValidationErrors.SetError(textBox,
                new Exception("Некорректный формат e-mail (пример: user@example.com)"));
            return;
        }


        DataValidationErrors.ClearErrors(textBox);
    }

    public bool HasErrors => DataValidationErrors.GetHasErrors(this.FindControl<TextBox>("Input"));
}
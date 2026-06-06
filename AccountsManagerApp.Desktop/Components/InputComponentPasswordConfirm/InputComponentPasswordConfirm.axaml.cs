using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AccountsManagerApp.Desktop.Components;

public partial class InputComponentPasswordConfirm : UserControl
{
    public static readonly StyledProperty<object> LabelProperty =
        AvaloniaProperty.Register<InputComponentPasswordConfirm, object>(nameof(Label));

    public object Label
    {
        get => GetValue(InputComponentPasswordConfirm.LabelProperty);
        set => SetValue(InputComponentPasswordConfirm.LabelProperty, value);
    }

    public static readonly StyledProperty<string?> ValueProperty =
        AvaloniaProperty.Register<InputComponentPasswordConfirm, string?>(nameof(Value));

    public string? Value
    {
        get => this.GetValue<string?>(InputComponentPasswordConfirm.ValueProperty);
        set => this.SetValue(InputComponentPasswordConfirm.ValueProperty, value);
    }

    public static readonly StyledProperty<string?> PlaceholderProperty =
        AvaloniaProperty.Register<InputComponentPasswordConfirm
            , string?>(nameof(Placeholder));

    public string? Placeholder
    {
        get => this.GetValue<string?>(InputComponentPasswordConfirm
            .PlaceholderProperty);
        set => this.SetValue(InputComponentPasswordConfirm
            .PlaceholderProperty, value);
    }

    public InputComponentPasswordConfirm()
    {
        InitializeComponent();
    }
}
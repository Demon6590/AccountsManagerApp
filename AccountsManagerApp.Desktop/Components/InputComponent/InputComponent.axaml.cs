using Avalonia;
using Avalonia.Controls;

namespace AccountsManagerApp.Desktop.Components;

public partial class InputComponent : UserControl
{
    public static readonly StyledProperty<object> LabelProperty =
        AvaloniaProperty.Register<InputComponent, object>(nameof(Label));

    public object Label
    {
        get => GetValue(InputComponent.LabelProperty);
        set => SetValue(InputComponent.LabelProperty, value);
    }

    public static readonly StyledProperty<string?> ValueProperty =
        AvaloniaProperty.Register<InputComponent, string?>(nameof(Value));

    public string? Value
    {
        get => this.GetValue<string?>(InputComponent.ValueProperty);
        set => this.SetValue(InputComponent.ValueProperty, value);
    }

    public static readonly StyledProperty<string?> PlaceholderProperty =
        AvaloniaProperty.Register<InputComponent, string?>(nameof(Placeholder));

    public string? Placeholder
    {
        get => this.GetValue<string?>(InputComponent.PlaceholderProperty);
        set => this.SetValue(InputComponent.PlaceholderProperty, value);
    }

    public InputComponent()
    {
        InitializeComponent();
    }
}
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using LenovoLegionToolkit.Lib.Automation.Steps;
using Wpf.Ui.Common;
using TextBox = Wpf.Ui.Controls.TextBox;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class SuspendProcessAutomationStepControl : AbstractAutomationStepControl<SuspendProcessAutomationStep>
{
    private readonly TextBox _processNameTextBox = new()
    {
        Margin = new(16, 0, 16, 0),
        MinWidth = 200,
        HorizontalAlignment = HorizontalAlignment.Left,
        PlaceholderText = "Process Name (e.g. Discord)"
    };

    private readonly StackPanel _stackPanel = new()
    {
        Orientation = Orientation.Horizontal
    };

    public SuspendProcessAutomationStepControl(SuspendProcessAutomationStep step) : base(step)
    {
        Title = "Suspend Process (Game Boost)";
        Subtitle = "Pauses a process to free up resources";
        Icon = SymbolRegular.Pause24;

        AutomationProperties.SetName(_processNameTextBox, "Process Name");
    }

    public override IAutomationStep CreateAutomationStep() => new SuspendProcessAutomationStep(_processNameTextBox.Text);

    protected override UIElement GetCustomControl()
    {
        _processNameTextBox.TextChanged += (_, _) =>
        {
            if (_processNameTextBox.Text != AutomationStep.ProcessName)
                RaiseChanged();
        };

        _stackPanel.Children.Add(_processNameTextBox);

        return _stackPanel;
    }

    protected override void OnFinishedLoading() { }

    protected override Task RefreshAsync()
    {
        _processNameTextBox.Text = AutomationStep.ProcessName ?? string.Empty;
        return Task.CompletedTask;
    }
}

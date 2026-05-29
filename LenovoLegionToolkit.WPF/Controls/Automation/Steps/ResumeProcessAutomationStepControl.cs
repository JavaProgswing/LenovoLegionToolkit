using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using LenovoLegionToolkit.Lib.Automation.Steps;
using Wpf.Ui.Common;
using TextBox = Wpf.Ui.Controls.TextBox;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class ResumeProcessAutomationStepControl : AbstractAutomationStepControl<ResumeProcessAutomationStep>
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

    public ResumeProcessAutomationStepControl(ResumeProcessAutomationStep step) : base(step)
    {
        Title = "Resume Process (Game Boost)";
        Subtitle = "Resumes a paused process";
        Icon = SymbolRegular.Play24;

        AutomationProperties.SetName(_processNameTextBox, "Process Name");
    }

    public override IAutomationStep CreateAutomationStep() => new ResumeProcessAutomationStep(_processNameTextBox.Text);

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

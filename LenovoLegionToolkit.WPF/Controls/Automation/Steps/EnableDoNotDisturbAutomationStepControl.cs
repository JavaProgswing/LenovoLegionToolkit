using System.Threading.Tasks;
using System.Windows;
using LenovoLegionToolkit.Lib.Automation.Steps;
using LenovoLegionToolkit.WPF.Resources;
using Wpf.Ui.Common;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class EnableDoNotDisturbAutomationStepControl : AbstractAutomationStepControl
{
    public EnableDoNotDisturbAutomationStepControl(EnableDoNotDisturbAutomationStep automationStep) : base(automationStep)
    {
        Icon = SymbolRegular.AlertOff24;
        Title = Resource.EnableDoNotDisturbAutomationStepControl_Title;
    }

    public override IAutomationStep CreateAutomationStep() => new EnableDoNotDisturbAutomationStep();

    protected override UIElement? GetCustomControl() => null;

    protected override void OnFinishedLoading() { }

    protected override Task RefreshAsync() => Task.CompletedTask;
}

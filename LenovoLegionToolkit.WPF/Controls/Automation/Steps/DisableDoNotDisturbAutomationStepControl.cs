using System.Threading.Tasks;
using System.Windows;
using LenovoLegionToolkit.Lib.Automation.Steps;
using LenovoLegionToolkit.WPF.Resources;
using Wpf.Ui.Common;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class DisableDoNotDisturbAutomationStepControl : AbstractAutomationStepControl
{
    public DisableDoNotDisturbAutomationStepControl(DisableDoNotDisturbAutomationStep automationStep) : base(automationStep)
    {
        Icon = SymbolRegular.Alert24;
        Title = Resource.DisableDoNotDisturbAutomationStepControl_Title;
    }

    public override IAutomationStep CreateAutomationStep() => new DisableDoNotDisturbAutomationStep();

    protected override UIElement? GetCustomControl() => null;

    protected override void OnFinishedLoading() { }

    protected override Task RefreshAsync() => Task.CompletedTask;
}

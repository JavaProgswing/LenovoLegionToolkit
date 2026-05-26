using System.Threading.Tasks;
using System.Windows;
using LenovoLegionToolkit.Lib.Automation.Steps;
using LenovoLegionToolkit.WPF.Resources;
using Wpf.Ui.Common;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class TurnOnNightLightAutomationStepControl : AbstractAutomationStepControl
{
    public TurnOnNightLightAutomationStepControl(TurnOnNightLightAutomationStep automationStep) : base(automationStep)
    {
        Icon = SymbolRegular.WeatherMoon24;
        Title = Resource.TurnOnNightLightAutomationStepControl_Title;
    }

    public override IAutomationStep CreateAutomationStep() => new TurnOnNightLightAutomationStep();

    protected override UIElement? GetCustomControl() => null;

    protected override void OnFinishedLoading() { }

    protected override Task RefreshAsync() => Task.CompletedTask;
}

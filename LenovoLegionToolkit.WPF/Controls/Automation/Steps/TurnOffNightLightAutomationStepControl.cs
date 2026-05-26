using System.Threading.Tasks;
using System.Windows;
using LenovoLegionToolkit.Lib.Automation.Steps;
using LenovoLegionToolkit.WPF.Resources;
using Wpf.Ui.Common;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class TurnOffNightLightAutomationStepControl : AbstractAutomationStepControl
{
    public TurnOffNightLightAutomationStepControl(TurnOffNightLightAutomationStep automationStep) : base(automationStep)
    {
        Icon = SymbolRegular.WeatherMoonOff24;
        Title = Resource.TurnOffNightLightAutomationStepControl_Title;
    }

    public override IAutomationStep CreateAutomationStep() => new TurnOffNightLightAutomationStep();

    protected override UIElement? GetCustomControl() => null;

    protected override void OnFinishedLoading() { }

    protected override Task RefreshAsync() => Task.CompletedTask;
}

using System.Threading.Tasks;
using System.Windows;
using LenovoLegionToolkit.Lib.Automation.Steps;
using LenovoLegionToolkit.WPF.Resources;
using Wpf.Ui.Common;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class UnmuteSystemVolumeAutomationStepControl : AbstractAutomationStepControl
{
    public UnmuteSystemVolumeAutomationStepControl(UnmuteSystemVolumeAutomationStep automationStep) : base(automationStep)
    {
        Icon = SymbolRegular.Speaker224;
        Title = Resource.UnmuteSystemVolumeAutomationStepControl_Title;
    }

    public override IAutomationStep CreateAutomationStep() => new UnmuteSystemVolumeAutomationStep();

    protected override UIElement? GetCustomControl() => null;

    protected override void OnFinishedLoading() { }

    protected override Task RefreshAsync() => Task.CompletedTask;
}

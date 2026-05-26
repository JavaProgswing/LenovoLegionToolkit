using System.Threading.Tasks;
using System.Windows;
using LenovoLegionToolkit.Lib.Automation.Steps;
using LenovoLegionToolkit.WPF.Resources;
using Wpf.Ui.Common;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class MuteSystemVolumeAutomationStepControl : AbstractAutomationStepControl
{
    public MuteSystemVolumeAutomationStepControl(MuteSystemVolumeAutomationStep automationStep) : base(automationStep)
    {
        Icon = SymbolRegular.SpeakerMute24;
        Title = Resource.MuteSystemVolumeAutomationStepControl_Title;
    }

    public override IAutomationStep CreateAutomationStep() => new MuteSystemVolumeAutomationStep();

    protected override UIElement? GetCustomControl() => null;

    protected override void OnFinishedLoading() { }

    protected override Task RefreshAsync() => Task.CompletedTask;
}

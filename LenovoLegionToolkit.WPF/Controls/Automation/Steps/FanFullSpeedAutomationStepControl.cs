using LenovoLegionToolkit.Lib;
using LenovoLegionToolkit.Lib.Automation.Steps;
using LenovoLegionToolkit.WPF.Resources;
using Wpf.Ui.Common;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class FanFullSpeedAutomationStepControl : AbstractComboBoxAutomationStepCardControl<FanFullSpeedState>
{
    public FanFullSpeedAutomationStepControl(IAutomationStep<FanFullSpeedState> step) : base(step)
    {
        Icon = SymbolRegular.Flash24;
        Title = Resource.FanFullSpeedAutomationStepControl_Title;
        Subtitle = Resource.FanFullSpeedAutomationStepControl_Message;
    }
}

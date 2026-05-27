using LenovoLegionToolkit.Lib;
using LenovoLegionToolkit.Lib.Automation.Steps;
using LenovoLegionToolkit.WPF.Resources;
using Wpf.Ui.Common;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class GSyncAutomationStepControl : AbstractComboBoxAutomationStepCardControl<GSyncState>
{
    public GSyncAutomationStepControl(IAutomationStep<GSyncState> step) : base(step)
    {
        Icon = SymbolRegular.DesktopPulse24;
        Title = Resource.GSyncAutomationStepControl_Title;
        Subtitle = Resource.GSyncAutomationStepControl_Message;
    }
}

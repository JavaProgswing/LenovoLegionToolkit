using System.Threading.Tasks;
using System.Windows;
using LenovoLegionToolkit.Lib.Automation.Steps;
using LenovoLegionToolkit.WPF.Resources;
using Wpf.Ui.Common;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class TurnOffBluetoothAutomationStepControl : AbstractAutomationStepControl
{
    public TurnOffBluetoothAutomationStepControl(TurnOffBluetoothAutomationStep automationStep) : base(automationStep)
    {
        Icon = SymbolRegular.BluetoothDisabled24;
        Title = Resource.TurnOffBluetoothAutomationStepControl_Title;
    }

    public override IAutomationStep CreateAutomationStep() => new TurnOffBluetoothAutomationStep();

    protected override UIElement? GetCustomControl() => null;

    protected override void OnFinishedLoading() { }

    protected override Task RefreshAsync() => Task.CompletedTask;
}

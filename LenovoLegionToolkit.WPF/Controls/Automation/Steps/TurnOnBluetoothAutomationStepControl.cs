using System.Threading.Tasks;
using System.Windows;
using LenovoLegionToolkit.Lib.Automation.Steps;
using LenovoLegionToolkit.WPF.Resources;
using Wpf.Ui.Common;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class TurnOnBluetoothAutomationStepControl : AbstractAutomationStepControl
{
    public TurnOnBluetoothAutomationStepControl(TurnOnBluetoothAutomationStep automationStep) : base(automationStep)
    {
        Icon = SymbolRegular.Bluetooth24;
        Title = Resource.TurnOnBluetoothAutomationStepControl_Title;
    }

    public override IAutomationStep CreateAutomationStep() => new TurnOnBluetoothAutomationStep();

    protected override UIElement? GetCustomControl() => null;

    protected override void OnFinishedLoading() { }

    protected override Task RefreshAsync() => Task.CompletedTask;
}

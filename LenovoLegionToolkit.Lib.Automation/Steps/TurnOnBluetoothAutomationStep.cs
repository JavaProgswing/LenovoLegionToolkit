using System.Threading;
using System.Threading.Tasks;
using LenovoLegionToolkit.Lib.System;

namespace LenovoLegionToolkit.Lib.Automation.Steps;

public class TurnOnBluetoothAutomationStep : IAutomationStep
{
    public Task<bool> IsSupportedAsync() => Task.FromResult(Bluetooth.IsPresent());

    public Task RunAsync(AutomationContext context, AutomationEnvironment environment, CancellationToken token)
    {
        Bluetooth.TurnOn();
        return Task.CompletedTask;
    }

    public IAutomationStep DeepCopy() => new TurnOnBluetoothAutomationStep();
}

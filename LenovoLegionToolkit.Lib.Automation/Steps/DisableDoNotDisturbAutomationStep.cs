using System.Threading;
using System.Threading.Tasks;
using LenovoLegionToolkit.Lib.System;

namespace LenovoLegionToolkit.Lib.Automation.Steps;

public class DisableDoNotDisturbAutomationStep : IAutomationStep
{
    public Task<bool> IsSupportedAsync() => Task.FromResult(true);

    public Task RunAsync(AutomationContext context, AutomationEnvironment environment, CancellationToken token)
    {
        FocusAssist.Disable();
        return Task.CompletedTask;
    }

    public IAutomationStep DeepCopy() => new DisableDoNotDisturbAutomationStep();
}

using System.Threading;
using System.Threading.Tasks;
using LenovoLegionToolkit.Lib.System;

namespace LenovoLegionToolkit.Lib.Automation.Steps;

public class UnmuteSystemVolumeAutomationStep : IAutomationStep
{
    public Task<bool> IsSupportedAsync() => Task.FromResult(SystemVolume.IsPresent());

    public Task RunAsync(AutomationContext context, AutomationEnvironment environment, CancellationToken token)
    {
        SystemVolume.Unmute();
        return Task.CompletedTask;
    }

    public IAutomationStep DeepCopy() => new UnmuteSystemVolumeAutomationStep();
}

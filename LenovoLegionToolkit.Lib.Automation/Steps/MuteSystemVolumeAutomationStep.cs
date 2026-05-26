using System.Threading;
using System.Threading.Tasks;
using LenovoLegionToolkit.Lib.System;

namespace LenovoLegionToolkit.Lib.Automation.Steps;

public class MuteSystemVolumeAutomationStep : IAutomationStep
{
    public Task<bool> IsSupportedAsync() => Task.FromResult(SystemVolume.IsPresent());

    public Task RunAsync(AutomationContext context, AutomationEnvironment environment, CancellationToken token)
    {
        SystemVolume.Mute();
        return Task.CompletedTask;
    }

    public IAutomationStep DeepCopy() => new MuteSystemVolumeAutomationStep();
}

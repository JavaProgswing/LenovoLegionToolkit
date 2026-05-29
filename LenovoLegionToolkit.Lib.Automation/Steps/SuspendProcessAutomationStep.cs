using System.Threading;
using System.Threading.Tasks;
using LenovoLegionToolkit.Lib.System;
using Newtonsoft.Json;

namespace LenovoLegionToolkit.Lib.Automation.Steps;

[method: JsonConstructor]
public class SuspendProcessAutomationStep(string? processName)
    : IAutomationStep
{
    public string? ProcessName { get; } = processName;

    public Task<bool> IsSupportedAsync() => Task.FromResult(true);

    public Task RunAsync(AutomationContext context, AutomationEnvironment environment, CancellationToken token)
    {
        if (!string.IsNullOrWhiteSpace(ProcessName))
        {
            ProcessUtils.SuspendProcess(ProcessName);
        }

        return Task.CompletedTask;
    }

    IAutomationStep IAutomationStep.DeepCopy() => new SuspendProcessAutomationStep(ProcessName);
}

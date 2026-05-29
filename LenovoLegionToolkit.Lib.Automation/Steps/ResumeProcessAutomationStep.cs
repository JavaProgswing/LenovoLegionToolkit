using System.Threading;
using System.Threading.Tasks;
using LenovoLegionToolkit.Lib.System;
using Newtonsoft.Json;

namespace LenovoLegionToolkit.Lib.Automation.Steps;

[method: JsonConstructor]
public class ResumeProcessAutomationStep(string? processName)
    : IAutomationStep
{
    public string? ProcessName { get; } = processName;

    public Task<bool> IsSupportedAsync() => Task.FromResult(true);

    public Task RunAsync(AutomationContext context, AutomationEnvironment environment, CancellationToken token)
    {
        if (!string.IsNullOrWhiteSpace(ProcessName))
        {
            ProcessUtils.ResumeProcess(ProcessName);
        }

        return Task.CompletedTask;
    }

    IAutomationStep IAutomationStep.DeepCopy() => new ResumeProcessAutomationStep(ProcessName);
}

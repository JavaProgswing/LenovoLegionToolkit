using Newtonsoft.Json;

namespace LenovoLegionToolkit.Lib.Automation.Steps;

[method: JsonConstructor]
public class GSyncAutomationStep(GSyncState state)
    : AbstractFeatureAutomationStep<GSyncState>(state)
{
    public override IAutomationStep DeepCopy() => new GSyncAutomationStep(State);
}

using Newtonsoft.Json;

namespace LenovoLegionToolkit.Lib.Automation.Steps;

[method: JsonConstructor]
public class FanFullSpeedAutomationStep(FanFullSpeedState state)
    : AbstractFeatureAutomationStep<FanFullSpeedState>(state)
{
    public override IAutomationStep DeepCopy() => new FanFullSpeedAutomationStep(State);
}

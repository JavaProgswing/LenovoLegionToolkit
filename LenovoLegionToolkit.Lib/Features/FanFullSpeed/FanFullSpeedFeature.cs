namespace LenovoLegionToolkit.Lib.Features.FanFullSpeed;

// Composite: tries capability (V2) first, falls back to WMI FanMethod (V1)
public class FanFullSpeedFeature(FanFullSpeedCapabilityFeature capabilityFeature, FanFullSpeedWmiFeature wmiFeature)
    : AbstractCompositeFeature<FanFullSpeedState>(capabilityFeature, wmiFeature);

namespace LenovoLegionToolkit.Lib.Features.FanFullSpeed;

// Used on hardware that exposes FanFullSpeed via LenovoOtherMethod capability data (V2 controllers)
public class FanFullSpeedCapabilityFeature()
    : AbstractCapabilityFeature<FanFullSpeedState>(CapabilityID.FanFullSpeed);

using System.Threading.Tasks;
using LenovoLegionToolkit.Lib.System.Management;

namespace LenovoLegionToolkit.Lib.Features.FanFullSpeed;

// Used on hardware that exposes FanFullSpeed via LenovoFanMethod WMI calls (V1 controllers)
public class FanFullSpeedWmiFeature()
    : AbstractWmiFeature<FanFullSpeedState>(GetAsync, SetAsync, CheckSupportedAsync)
{
    private static async Task<int> GetAsync() =>
        await WMI.LenovoFanMethod.FanGetFullSpeedAsync().ConfigureAwait(false) ? 1 : 0;

    private static Task SetAsync(int value) =>
        WMI.LenovoFanMethod.FanSetFullSpeedAsync(value);

    private static async Task<int> CheckSupportedAsync()
    {
        try
        {
            await WMI.LenovoFanMethod.FanGetFullSpeedAsync().ConfigureAwait(false);
            return 1;
        }
        catch
        {
            return 0;
        }
    }
}

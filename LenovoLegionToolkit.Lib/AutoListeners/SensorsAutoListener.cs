using System;
using System.Threading.Tasks;
using System.Timers;
using LenovoLegionToolkit.Lib.Controllers.Sensors;
using LenovoLegionToolkit.Lib.Utils;

namespace LenovoLegionToolkit.Lib.AutoListeners;

public class SensorsAutoListener(ISensorsController sensorsController) : AbstractAutoListener<SensorsAutoListener.ChangedEventArgs>
{
    public class ChangedEventArgs(SensorsData data) : EventArgs
    {
        public SensorsData Data { get; } = data;
    }

    private readonly Timer _timer = new(5000) { AutoReset = true };
    private bool _isPrepared;

    protected override async Task StartAsync()
    {
        if (!_isPrepared)
        {
            if (await sensorsController.IsSupportedAsync().ConfigureAwait(false))
            {
                await sensorsController.PrepareAsync().ConfigureAwait(false);
                _isPrepared = true;
            }
        }

        if (_isPrepared)
        {
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }
    }

    protected override Task StopAsync()
    {
        _timer.Stop();
        _timer.Elapsed -= Timer_Elapsed;
        return Task.CompletedTask;
    }

    private async void Timer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        try
        {
            var data = await sensorsController.GetDataAsync().ConfigureAwait(false);
            RaiseChanged(new ChangedEventArgs(data));
        }
        catch (Exception ex)
        {
            Log.Instance.Trace($"Failed to read sensors data in auto listener.", ex);
        }
    }
}

using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LenovoLegionToolkit.Lib.Automation.Pipeline.Triggers;

[method: JsonConstructor]
public class CpuTemperatureTrigger(int temperatureThreshold, bool isGreaterThan) : ISensorAutomationPipelineTrigger
{
    public string DisplayName => "CPU Temperature";

    public int TemperatureThreshold { get; } = temperatureThreshold;
    public bool IsGreaterThan { get; } = isGreaterThan;

    public Task<bool> IsMatchingEvent(IAutomationEvent automationEvent)
    {
        if (automationEvent is not SensorAutomationEvent sensorEvent)
            return Task.FromResult(false);

        var temp = sensorEvent.SensorsData.CPU.Temperature;
        if (temp < 0) return Task.FromResult(false); // Sensor not available

        return Task.FromResult(IsGreaterThan ? temp > TemperatureThreshold : temp < TemperatureThreshold);
    }

    public Task<bool> IsMatchingState() => Task.FromResult(false); // Difficult to synchronously fetch temp here without blocking

    public IAutomationPipelineTrigger DeepCopy() => new CpuTemperatureTrigger(TemperatureThreshold, IsGreaterThan);

    public void UpdateEnvironment(AutomationEnvironment environment) { }
}

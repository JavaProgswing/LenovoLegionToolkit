using System.Windows.Controls;
using LenovoLegionToolkit.Lib.Automation.Pipeline.Triggers;
using Wpf.Ui.Controls;

namespace LenovoLegionToolkit.WPF.Windows.Automation.TabItemContent;

public class SensorAutomationPipelineTriggerTabItemContent : UserControl, IAutomationPipelineTriggerTabItemContent<ISensorAutomationPipelineTrigger>
{
    private readonly ISensorAutomationPipelineTrigger _trigger;
    private readonly NumberBox _thresholdNumberBox;
    private readonly CheckBox _isGreaterThanCheckBox;

    public SensorAutomationPipelineTriggerTabItemContent(ISensorAutomationPipelineTrigger trigger)
    {
        _trigger = trigger;

        _thresholdNumberBox = new NumberBox
        {
            Value = trigger.TemperatureThreshold == 0 ? 80 : trigger.TemperatureThreshold, // default 80
            PlaceholderText = "Temperature Threshold (°C)",
            Margin = new(0, 0, 0, 8),
            Width = 200,
            HorizontalAlignment = System.Windows.HorizontalAlignment.Left
        };

        _isGreaterThanCheckBox = new CheckBox
        {
            IsChecked = trigger.IsGreaterThan,
            Content = "Trigger when temperature goes ABOVE threshold",
            Margin = new(0, 0, 0, 8)
        };

        Content = new StackPanel
        {
            Margin = new(16),
            Children =
            {
                new TextBlock { Text = "Set the threshold condition for the sensor:", Margin = new(0,0,0,8) },
                _thresholdNumberBox,
                _isGreaterThanCheckBox
            }
        };
    }

    public ISensorAutomationPipelineTrigger GetTrigger()
    {
        var threshold = (int)(_thresholdNumberBox.Value ?? 80);
        var isGreaterThan = _isGreaterThanCheckBox.IsChecked ?? true;

        if (_trigger is CpuTemperatureTrigger cpu)
            return new CpuTemperatureTrigger(threshold, isGreaterThan);
        
        if (_trigger is GpuTemperatureTrigger gpu)
            return new GpuTemperatureTrigger(threshold, isGreaterThan);

        return _trigger; // Fallback
    }
}

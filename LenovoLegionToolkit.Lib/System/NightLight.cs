using System;
using LenovoLegionToolkit.Lib.Utils;
using WinRegistry = Microsoft.Win32.Registry;
using Microsoft.Win32;

namespace LenovoLegionToolkit.Lib.System;

public static class NightLight
{
    // CloudStore key for Windows Night Light (blue light filter)
    private const string RegistryKeyPath =
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\CloudStore\Store\DefaultAccount\Current\" +
        @"default$windows.data.bluelightreduction.bluelightreductionstate\" +
        @"windows.data.bluelightreduction.bluelightreductionstate";

    // Byte offset within the Data binary value that holds the enabled flag
    private const int EnableByteOffset = 18;
    private const byte EnabledValue = 0x13;
    private const byte DisabledValue = 0x00;

    public static void TurnOn()
    {
        try
        {
            SetState(enabled: true);
        }
        catch (Exception ex)
        {
            if (Log.Instance.IsTraceEnabled)
                Log.Instance.Trace($"Failed to turn on Night Light.", ex);
        }
    }

    public static void TurnOff()
    {
        try
        {
            SetState(enabled: false);
        }
        catch (Exception ex)
        {
            if (Log.Instance.IsTraceEnabled)
                Log.Instance.Trace($"Failed to turn off Night Light.", ex);
        }
    }

    private static void SetState(bool enabled)
    {
        using var key = WinRegistry.CurrentUser.OpenSubKey(RegistryKeyPath, writable: true);
        if (key is null)
            return;

        var data = key.GetValue("Data") as byte[];
        if (data is null || data.Length <= EnableByteOffset)
            return;

        data[EnableByteOffset] = enabled ? EnabledValue : DisabledValue;

        // Refresh the FILETIME timestamp so Windows picks up the change
        if (data.Length >= 12)
        {
            var timestamp = BitConverter.GetBytes(DateTime.UtcNow.ToFileTime());
            Array.Copy(timestamp, 0, data, 4, 8);
        }

        key.SetValue("Data", data, RegistryValueKind.Binary);
    }
}

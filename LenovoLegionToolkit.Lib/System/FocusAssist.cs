using System;
using LenovoLegionToolkit.Lib.Utils;
using WinRegistry = Microsoft.Win32.Registry;
using Microsoft.Win32;

namespace LenovoLegionToolkit.Lib.System;

public static class FocusAssist
{
    // CloudStore key for Windows 10 Focus Assist / Windows 11 Do Not Disturb
    private const string RegistryKeyPath =
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\CloudStore\Store\DefaultAccount\Current\" +
        @"default$windows.data.notifications.quietmodesettings\" +
        @"windows.data.notifications.quietmodesettings";

    public static void Enable()
    {
        try
        {
            using var key = WinRegistry.CurrentUser.CreateSubKey(RegistryKeyPath, writable: true);
            if (key is null)
                return;

            var timestamp = BitConverter.GetBytes(DateTime.UtcNow.ToFileTime());

            // Binary CloudStore payload that encodes "Do Not Disturb / Priority Only" mode.
            // Format: 4-byte header + 8-byte FILETIME + mode payload.
            var data = new byte[18];
            data[0] = 0x02;
            Array.Copy(timestamp, 0, data, 4, 8);
            data[12] = 0x00;
            data[13] = 0xC2;
            data[14] = 0x1A;
            data[15] = 0x00;
            data[16] = 0x00;
            data[17] = 0x00;

            key.SetValue("Data", data, RegistryValueKind.Binary);
        }
        catch (Exception ex)
        {
            if (Log.Instance.IsTraceEnabled)
                Log.Instance.Trace($"Failed to enable Focus Assist.", ex);
        }
    }

    public static void Disable()
    {
        try
        {
            using var key = WinRegistry.CurrentUser.OpenSubKey(RegistryKeyPath, writable: true);
            key?.DeleteValue("Data", throwOnMissingValue: false);
        }
        catch (Exception ex)
        {
            if (Log.Instance.IsTraceEnabled)
                Log.Instance.Trace($"Failed to disable Focus Assist.", ex);
        }
    }
}

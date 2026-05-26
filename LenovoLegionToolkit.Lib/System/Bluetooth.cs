using System;
using System.Runtime.InteropServices;
using LenovoLegionToolkit.Lib.Utils;
using Windows.Win32;
using Windows.Win32.Devices.DeviceAndDriverInstallation;
using Windows.Win32.Foundation;

namespace LenovoLegionToolkit.Lib.System;

public static class Bluetooth
{
    // Bluetooth Host Controller device class GUID
    private static readonly Guid BluetoothHostControllerGuid = new("{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}");

    public static bool IsPresent()
    {
        try
        {
            return EnumerateDevNodes(static _ => true);
        }
        catch
        {
            return false;
        }
    }

    public static void TurnOn()
    {
        try
        {
            EnumerateDevNodes(static devInst =>
            {
                PInvoke.CM_Enable_DevNode(devInst, 0);
                return false;
            });
        }
        catch (Exception ex)
        {
            if (Log.Instance.IsTraceEnabled)
                Log.Instance.Trace($"Failed to turn on Bluetooth.", ex);
        }
    }

    public static void TurnOff()
    {
        try
        {
            EnumerateDevNodes(static devInst =>
            {
                // CM_DISABLE_UI_NOT_OK (0x04) suppresses any confirmation prompt
                PInvoke.CM_Disable_DevNode(devInst, 4);
                return false;
            });
        }
        catch (Exception ex)
        {
            if (Log.Instance.IsTraceEnabled)
                Log.Instance.Trace($"Failed to turn off Bluetooth.", ex);
        }
    }

    private static bool EnumerateDevNodes(Func<uint, bool> action)
    {
        using var deviceInfoSet = PInvoke.SetupDiGetClassDevs(
            BluetoothHostControllerGuid,
            (string?)null,
            HWND.Null,
            SETUP_DI_GET_CLASS_DEVS_FLAGS.DIGCF_PRESENT);

        if (deviceInfoSet.IsInvalid)
            return false;

        var deviceInfoData = new SP_DEVINFO_DATA { cbSize = (uint)Marshal.SizeOf<SP_DEVINFO_DATA>() };
        uint index = 0;
        var found = false;

        while (PInvoke.SetupDiEnumDeviceInfo(deviceInfoSet, index++, ref deviceInfoData))
        {
            found = true;
            if (action(deviceInfoData.DevInst))
                return true;
        }

        return found;
    }
}

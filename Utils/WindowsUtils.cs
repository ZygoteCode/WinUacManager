using System;
using Microsoft.Win32;

public class WindowsUtils
{
    public static string GetWindowsFriendlyName()
    {
        string ProductName = GetHKEYLocalMachineString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
        string CSDVersion = GetHKEYLocalMachineString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");

        if (ProductName != "")
        {
            return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") +
                ProductName + (CSDVersion != "" ? " " + CSDVersion : "");
        }

        return "";
    }

    private static string GetHKEYLocalMachineString(string path, string key)
    {
        try
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(path);

            if (registryKey == null)
            {
                return "";
            }

            return (string)registryKey.GetValue(key);
        }
        catch
        {
            return "";
        }
    }

    public static void SetDWord(string keyPath, string valueName, int value)
    {
        try
        {
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(keyPath, true))
            {
                if (registryKey != null)
                {
                    registryKey.SetValue(valueName, value, RegistryValueKind.DWord);
                }
            }
        }
        catch
        {

        }

        try
        {
            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(keyPath, true))
            {
                if (registryKey != null)
                {
                    registryKey.SetValue(valueName, value, RegistryValueKind.DWord);
                }
            }
        }
        catch
        {

        }
    }
}
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

    public static void SetDWord(string key, string name, int value)
    {
        try
        {
            Registry.LocalMachine.CreateSubKey(key).SetValue(name, value.ToString(), RegistryValueKind.DWord);
        }
        catch
        {

        }

        try
        {
            Registry.CurrentUser.CreateSubKey(key).SetValue(name, value.ToString(), RegistryValueKind.DWord);
        }
        catch
        {

        }
    }
}
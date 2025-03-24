using System;

public class WinUacControl
{
    private const string UacRegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";

    public static void EnableUserAccountControl()
    {
        SetUacRegistryKey("EnableLUA", 1);
        SetUacRegistryKey("PromptOnSecureDesktop", 1);
        SetUacRegistryKey("ConsentPromptBehaviorAdmin", 5);
        SetUacRegistryKey("ConsentPromptBehaviorUser", 3);
        SetUacRegistryKey("EnableVirtualization", 1);
        SetUacRegistryKey("EnableInstallerDetection", 1);
        SetUacRegistryKey("FilterAdministratorToken", 0);
        SetUacRegistryKey("EnableAdminApprovalMode", 1);
        SetUacRegistryKey("ValidateAdminCodeSignatures", 1);
        SetUacRegistryKey("EnableSecureUIAPaths", 1);
        SetUacRegistryKey("EnableUIADesktopToggle", 0);
        SetUacRegistryKey("LocalAccountTokenFilterPolicy", 0);
        SetUacRegistryKey("EnableSwitchToRedesignedSafeDesktop", 1);
        SetUacRegistryKey("InteractiveLogonFirst", 0);
    }

    public static void DisableUserAccountControl()
    {
        SetUacRegistryKey("EnableLUA", 0);
        SetUacRegistryKey("PromptOnSecureDesktop", 0);
        SetUacRegistryKey("ConsentPromptBehaviorAdmin", 0);
        SetUacRegistryKey("ConsentPromptBehaviorUser", 0);
        SetUacRegistryKey("EnableVirtualization", 0);
        SetUacRegistryKey("EnableInstallerDetection", 0);
        SetUacRegistryKey("FilterAdministratorToken", 1);
        SetUacRegistryKey("EnableAdminApprovalMode", 0);
        SetUacRegistryKey("ValidateAdminCodeSignatures", 0);
        SetUacRegistryKey("EnableSecureUIAPaths", 0);
        SetUacRegistryKey("EnableUIADesktopToggle", 0);
        SetUacRegistryKey("LocalAccountTokenFilterPolicy", 1);
        SetUacRegistryKey("EnableSwitchToRedesignedSafeDesktop", 0);
        SetUacRegistryKey("InteractiveLogonFirst", 0);
    }

    private static void SetUacRegistryKey(string keyName, int value)
    {
        try
        {
            WindowsUtils.SetDWord(UacRegistryPath, keyName, value);
        }
        catch
        {

        }
    }
}
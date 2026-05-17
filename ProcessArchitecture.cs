using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Injector;

internal static class ProcessArchitecture
{
    private const uint ProcessQueryLimitedInformation = 0x1000;
    private const ushort ImageFileMachineUnknown = 0x0000;
    private const ushort ImageFileMachineI386 = 0x014c;
    private const ushort ImageFileMachineAmd64 = 0x8664;

    public static string GetArchitecture(uint processId)
    {
        var processHandle = OpenProcess(ProcessQueryLimitedInformation, false, processId);
        if (processHandle == 0)
        {
            return new Win32Exception(Marshal.GetLastWin32Error()).NativeErrorCode == 5
                ? "拒绝访问"
                : "未知";
        }

        try
        {
            return GetArchitectureFromHandle(processHandle);
        }
        finally
        {
            CloseHandle(processHandle);
        }
    }

    private static string GetArchitectureFromHandle(nint processHandle)
    {
        try
        {
            if (!IsWow64Process2(processHandle, out var processMachine, out var nativeMachine))
            {
                return new Win32Exception(Marshal.GetLastWin32Error()).NativeErrorCode == 5
                    ? "拒绝访问"
                    : "未知";
            }

            return processMachine == ImageFileMachineUnknown
                ? MachineToText(nativeMachine)
                : MachineToText(processMachine);
        }
        catch (EntryPointNotFoundException)
        {
            return "未知";
        }
    }

    private static string MachineToText(ushort machine) => machine switch
    {
        ImageFileMachineI386 => "x86",
        ImageFileMachineAmd64 => "x64",
        ImageFileMachineUnknown => "未知",
        _ => "未知"
    };

    [DllImport("kernel32", SetLastError = true)]
    private static extern nint OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

    [DllImport("kernel32", SetLastError = true)]
    private static extern bool CloseHandle(nint hObject);

    [DllImport("kernel32", SetLastError = true)]
    private static extern bool IsWow64Process2(nint hProcess, out ushort pProcessMachine, out ushort pNativeMachine);
}

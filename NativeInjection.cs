using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Injector;

internal sealed class NativeInjection : IDisposable
{
    private const int MaxPath = 260;
    private const int DllPathChars = MaxPath * 2;

    private readonly nint _moduleHandle;
    private readonly InjectADelegate _injectA;
    private readonly GetStateDelegate? _getSymbolState;
    private readonly GetStateDelegate? _getImportState;
    private readonly StartDownloadDelegate? _startDownload;
    private readonly GetDownloadProgressExDelegate? _getDownloadProgressEx;
    private bool _disposed;

    public NativeInjection(string modulePath)
    {
        if (!File.Exists(modulePath))
        {
            throw new FileNotFoundException("找不到 GH Injector DLL。", modulePath);
        }

        _moduleHandle = LoadLibrary(modulePath);
        if (_moduleHandle == 0)
        {
            throw new Win32Exception(Marshal.GetLastWin32Error(), "加载 GH Injector DLL 失败。请确认程序位数和 DLL 位数一致。");
        }

        _injectA = GetRequiredDelegate<InjectADelegate>("InjectA");
        _getSymbolState = GetOptionalDelegate<GetStateDelegate>("GetSymbolState");
        _getImportState = GetOptionalDelegate<GetStateDelegate>("GetImportState");
        _startDownload = GetOptionalDelegate<StartDownloadDelegate>("StartDownload");
        _getDownloadProgressEx = GetOptionalDelegate<GetDownloadProgressExDelegate>("GetDownloadProgressEx");
    }

    public bool SupportsSymbolDownload =>
        _startDownload is not null &&
        _getDownloadProgressEx is not null &&
        _getSymbolState is not null &&
        _getImportState is not null;

    public void StartDownload() => _startDownload?.Invoke();

    public float GetDownloadProgress(int index, bool wow64) =>
        _getDownloadProgressEx?.Invoke(index, wow64) ?? 1.0f;

    public uint GetSymbolState() => _getSymbolState?.Invoke() ?? 0;

    public uint GetImportState() => _getImportState?.Invoke() ?? 0;

    public InjectionResult Inject(InjectionRequest request)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        var data = new InjectionDataA
        {
            DllPath = request.DllPath,
            ProcessId = request.ProcessId,
            Mode = request.Mode,
            Method = request.Method,
            Flags = request.Flags,
            Timeout = request.Timeout,
            HandleValue = request.HandleValue,
            DllOut = 0,
            GenerateErrorLog = request.GenerateErrorLog
        };

        var errorCode = _injectA(ref data);
        return new InjectionResult(errorCode, data.DllOut);
    }

    private T GetRequiredDelegate<T>(string exportName) where T : Delegate
    {
        var address = GetProcAddress(_moduleHandle, exportName);
        if (address == 0)
        {
            throw new MissingMethodException($"GH Injector DLL 缺少导出函数：{exportName}");
        }

        return Marshal.GetDelegateForFunctionPointer<T>(address);
    }

    private T? GetOptionalDelegate<T>(string exportName) where T : Delegate
    {
        var address = GetProcAddress(_moduleHandle, exportName);
        return address == 0 ? null : Marshal.GetDelegateForFunctionPointer<T>(address);
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        if (_moduleHandle != 0)
        {
            FreeLibrary(_moduleHandle);
        }

        _disposed = true;
    }

    [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern nint LoadLibrary(string lpFileName);

    [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
    private static extern nint GetProcAddress(nint hModule, string lpProcName);

    [DllImport("kernel32", SetLastError = true)]
    private static extern bool FreeLibrary(nint hModule);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint InjectADelegate(ref InjectionDataA data);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint GetStateDelegate();

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate void StartDownloadDelegate();

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate float GetDownloadProgressExDelegate(int index, [MarshalAs(UnmanagedType.I1)] bool wow64);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    private struct InjectionDataA
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DllPathChars)]
        public string DllPath;

        public uint ProcessId;
        public InjectionMode Mode;
        public LaunchMethod Method;
        public uint Flags;
        public uint Timeout;
        public uint HandleValue;
        public nint DllOut;

        [MarshalAs(UnmanagedType.I1)]
        public bool GenerateErrorLog;
    }
}

internal sealed record InjectionRequest(
    string DllPath,
    uint ProcessId,
    InjectionMode Mode,
    LaunchMethod Method,
    uint Flags,
    uint Timeout,
    uint HandleValue,
    bool GenerateErrorLog);

internal sealed record InjectionResult(uint ErrorCode, nint DllBase);

internal enum InjectionMode
{
    LoadLibraryExW,
    LdrLoadDll,
    LdrpLoadDll,
    LdrpLoadDllInternal,
    ManualMap
}

internal enum LaunchMethod
{
    NtCreateThreadEx,
    HijackThread,
    SetWindowsHookEx,
    QueueUserAPC,
    KernelCallback,
    FakeVEH
}

[Flags]
internal enum InjectionFlags : uint
{
    None = 0,
    EraseHeader = 0x0001,
    FakeHeader = 0x0002,
    UnlinkFromPeb = 0x0004,
    ThreadCreateCloaked = 0x0008,
    ScrambleDllName = 0x0010,
    LoadDllCopy = 0x0020,
    HijackHandle = 0x0040,
    MmCleanDataDir = 0x00010000,
    MmResolveImports = 0x00020000,
    MmResolveDelayImports = 0x00040000,
    MmExecuteTls = 0x00080000,
    MmEnableExceptions = 0x00100000,
    MmSetPageProtections = 0x00200000,
    MmInitSecurityCookie = 0x00400000,
    MmRunDllMain = 0x00800000,
    MmRunUnderLdrLock = 0x01000000,
    MmShiftModuleBase = 0x02000000,
    MmDefault = MmResolveImports | MmResolveDelayImports | MmInitSecurityCookie | MmExecuteTls | MmEnableExceptions | MmRunDllMain | MmSetPageProtections
}

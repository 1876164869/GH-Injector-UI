using System.Runtime.InteropServices;

namespace Injector;

internal static class AppBuild
{
    public static string ArchitectureName => RuntimeInformation.ProcessArchitecture switch
    {
        Architecture.X64 => "x64",
        Architecture.X86 => "x86",
        Architecture.Arm64 => "ARM64",
        Architecture.Arm => "ARM",
        _ => RuntimeInformation.ProcessArchitecture.ToString()
    };

    public static string InjectorDllName => RuntimeInformation.ProcessArchitecture switch
    {
        Architecture.X64 => "GH Injector - x64.dll",
        Architecture.X86 => "GH Injector - x86.dll",
        _ => throw new PlatformNotSupportedException($"当前程序架构 {RuntimeInformation.ProcessArchitecture} 不支持 GH Injector。")
    };

    public static string InjectorDllPath => Path.Combine(AppContext.BaseDirectory, InjectorDllName);

    public static IReadOnlyList<string> RequiredNativeFiles => RuntimeInformation.ProcessArchitecture switch
    {
        Architecture.X64 => ["GH Injector - x64.dll", "GH Injector SM - x86.exe"],
        Architecture.X86 => ["GH Injector - x86.dll"],
        _ => [InjectorDllName]
    };
}

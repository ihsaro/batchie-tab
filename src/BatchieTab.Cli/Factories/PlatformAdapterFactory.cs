using BatchieTab.Cli.Adapters;

namespace BatchieTab.Cli.Factories;

public static class PlatformAdapterFactory
{
    public static IPlatformAdapter Create()
    {
        if (OperatingSystem.IsLinux()) return new LinuxPlatformAdapter();
        if (OperatingSystem.IsMacOS()) return new MacosPlatformAdapter();
        if (OperatingSystem.IsWindows()) return new WindowsPlatformAdapter();
        throw new PlatformNotSupportedException();
    }
}
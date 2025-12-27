using BatchieTab.Cli.Adapters;

namespace BatchieTab.Cli.Factories;

public static class BrowserPlatformAdapterFactory
{
    public static IBrowserPlatformAdapter Create()
    {
        if (OperatingSystem.IsLinux()) return new LinuxBrowserPlatformAdapter();
        if (OperatingSystem.IsMacOS()) return new MacosBrowserPlatformAdapter();
        if (OperatingSystem.IsWindows()) return new WindowsBrowserPlatformAdapter();
        throw new PlatformNotSupportedException();
    }
}
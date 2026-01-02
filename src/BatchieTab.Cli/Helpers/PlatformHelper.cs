using BatchieTab.Cli.Adapters;
using BatchieTab.Cli.Domain;
using BatchieTab.Cli.Factories;

namespace BatchieTab.Cli.Helpers;

public static class PlatformHelper
{
    private static readonly IPlatformAdapter PlatformAdapter = PlatformAdapterFactory.Create();

    public static bool CommandExists(string command) => PlatformAdapter.CommandExists(command);
    
    public static string? GetDefaultBrowser() => PlatformAdapter.GetDefaultBrowser();

    public static bool IsBrowserInstalled(string browser) => PlatformAdapter.IsBrowserInstalled(browser);
    
    public static string? GetOperatingSystem()
    {
        if (OperatingSystem.IsMacOS()) return OperatingSystemType.Macos;
        if (OperatingSystem.IsLinux()) return OperatingSystemType.Linux;
        if (OperatingSystem.IsWindows()) return OperatingSystemType.Windows;
        return null;
    }
}
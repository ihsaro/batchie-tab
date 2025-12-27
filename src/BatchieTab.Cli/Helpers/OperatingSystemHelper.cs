using BatchieTab.Cli.Domain;

namespace BatchieTab.Cli.Helpers;

public static class OperatingSystemHelper
{
    public static string? GetOperatingSystem()
    {
        if (OperatingSystem.IsMacOS()) return OperatingSystemType.Macos;
        if (OperatingSystem.IsLinux()) return OperatingSystemType.Linux;
        if (OperatingSystem.IsWindows()) return OperatingSystemType.Windows;
        return null;
    }
}
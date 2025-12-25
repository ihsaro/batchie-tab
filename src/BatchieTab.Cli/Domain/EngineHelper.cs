using System.Diagnostics;

namespace BatchieTab.Cli.Domain;

public static class EngineHelper
{
    public static string? GetDefaultBrowser()
    {
        return null;
    }

    public static bool IsBrowserInstalled(string browser)
    {
        if (OperatingSystem.IsLinux())
        {
            var command = browser;
            
            if (browser == EngineType.Chrome)
            {
                command = "google-chrome";
            }
            
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "which",
                    Arguments = command,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.WaitForExit();

            return process.ExitCode == 0;
        }
        if (OperatingSystem.IsMacOS())
        {
            return false;
        }
        if (OperatingSystem.IsWindows())
        {
            return false;
        }

        return false;
    }
}
using System.Diagnostics;
using BatchieTab.Cli.Domain;

namespace BatchieTab.Cli.Adapters;

public class LinuxBrowserPlatformAdapter : IBrowserPlatformAdapter
{
    public string? GetDefaultBrowser()
    {
        return "chrome";
    }

    public bool IsBrowserInstalled(string browser)
    {
        var commands = browser switch
        {
            EngineType.Chrome => new[]
            {
                "google-chrome",
                "google-chrome-stable"
            },
            EngineType.Chromium => new[]
            {
                "chromium",
                "chromium-browser"
            },
            EngineType.Firefox => new[]
            {
                "firefox"
            },
            EngineType.Brave => new[]
            {
                "brave-browser",
                "brave"
            },
            _ => Array.Empty<string>()
        };

        foreach (var cmd in commands)
        {
            if (RunCommand("which", cmd))
                return true;
        }

        var snapNames = browser switch
        {
            EngineType.Chrome => new[] { "google-chrome" },
            EngineType.Chromium => new[] { "chromium" },
            EngineType.Firefox => new[] { "firefox" },
            EngineType.Brave => new[] { "brave" },
            _ => Array.Empty<string>()
        };

        foreach (var snap in snapNames)
        {
            if (RunCommand("snap", $"list {snap}"))
                return true;
        }

        var flatpakIds = browser switch
        {
            EngineType.Chrome => new[] { "com.google.Chrome" },
            EngineType.Chromium => new[] { "org.chromium.Chromium" },
            EngineType.Firefox => new[] { "org.mozilla.firefox" },
            EngineType.Brave => new[] { "com.brave.Browser" },
            _ => Array.Empty<string>()
        };

        foreach (var id in flatpakIds)
        {
            if (RunCommand("flatpak", $"info {id}"))
                return true;
        }

        return false;
    }

    private static bool RunCommand(string fileName, string arguments)
    {
        try
        {
            using var process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            process.Start();
            process.WaitForExit();

            return process.ExitCode == 0;
        }
        catch
        {
            return false;
        }
    }
}

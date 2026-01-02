using System.Diagnostics;
using BatchieTab.Cli.Domain;

namespace BatchieTab.Cli.Adapters;

public class LinuxPlatformAdapter : IPlatformAdapter
{
    public string? GetDefaultBrowser()
    {
        var desktop =
            RunAndCapture("xdg-settings", "get default-web-browser") ??
            RunAndCapture("xdg-mime", "query default x-scheme-handler/http");

        if (string.IsNullOrWhiteSpace(desktop))
            return null;

        desktop = desktop.ToLowerInvariant();

        if (desktop.Contains("chrome"))
            return EngineType.Chrome;

        if (desktop.Contains("chromium"))
            return EngineType.Chromium;

        if (desktop.Contains("firefox"))
            return EngineType.Firefox;

        if (desktop.Contains("brave"))
            return EngineType.Brave;

        if (desktop.Contains("edge"))
            return EngineType.Edge;

        return null;
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
            EngineType.Edge => new[]
            {
                "microsoft-edge",
                "microsoft-edge-stable",
                "microsoft-edge-beta",
                "microsoft-edge-dev"
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
            EngineType.Edge => new[] { "com.microsoft.Edge" },
            _ => Array.Empty<string>()
        };

        foreach (var id in flatpakIds)
        {
            if (RunCommand("flatpak", $"info {id}"))
                return true;
        }

        return false;
    }

    public bool CommandExists(string command)
    {
        try
        {
            var process = Process.Start(new ProcessStartInfo
            {
                FileName = "bash",
                Arguments = $"-c \"command -v {command}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });

            process!.WaitForExit();
            return process.ExitCode == 0;
        }
        catch
        {
            return false;
        }
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
    
    private static string? RunAndCapture(string fileName, string arguments)
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
            var output = process.StandardOutput.ReadToEnd().Trim();
            process.WaitForExit();

            return process.ExitCode == 0 && !string.IsNullOrWhiteSpace(output)
                ? output
                : null;
        }
        catch
        {
            return null;
        }
    }
}

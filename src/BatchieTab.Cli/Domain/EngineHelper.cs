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
            return IsBrowserInstalledLinux(browser);
        }

        if (OperatingSystem.IsMacOS())
        {
            return IsBrowserInstalledMacOs(browser);
        }

        if (OperatingSystem.IsWindows())
        {
            return IsBrowserInstalledWindows(browser);
        }

        return false;
    }

    private static bool IsBrowserInstalledLinux(string browser)
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
            _ => Array.Empty<string>()
        };

        foreach (var id in flatpakIds)
        {
            if (RunCommand("flatpak", $"info {id}"))
                return true;
        }

        return false;
    }

    private static bool IsBrowserInstalledMacOs(string browser)
    {
        var appPaths = browser switch
        {
            EngineType.Chrome => new[]
            {
                "/Applications/Google Chrome.app"
            },
            EngineType.Chromium => new[]
            {
                "/Applications/Chromium.app"
            },
            EngineType.Firefox => new[]
            {
                "/Applications/Firefox.app"
            },
            _ => Array.Empty<string>()
        };

        foreach (var path in appPaths)
        {
            if (Directory.Exists(path))
                return true;
        }

        var brewBins = browser switch
        {
            EngineType.Chrome => new[]
            {
                "/usr/local/bin/google-chrome",
                "/opt/homebrew/bin/google-chrome"
            },
            EngineType.Chromium => new[]
            {
                "/usr/local/bin/chromium",
                "/opt/homebrew/bin/chromium"
            },
            EngineType.Firefox => new[]
            {
                "/usr/local/bin/firefox",
                "/opt/homebrew/bin/firefox"
            },
            _ => Array.Empty<string>()
        };

        foreach (var bin in brewBins)
        {
            if (File.Exists(bin))
                return true;
        }

        return false;
    }

    private static bool IsBrowserInstalledWindows(string browser)
    {
        var programFiles = new[]
        {
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
        };

        var paths = browser switch
        {
            EngineType.Chrome => programFiles.Select(p =>
                Path.Combine(p, "Google", "Chrome", "Application", "chrome.exe")),

            EngineType.Chromium => programFiles.Select(p =>
                Path.Combine(p, "Chromium", "Application", "chrome.exe")),

            EngineType.Firefox => programFiles.Select(p =>
                Path.Combine(p, "Mozilla Firefox", "firefox.exe")),

            _ => Enumerable.Empty<string>()
        };

        return paths.Any(File.Exists);
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
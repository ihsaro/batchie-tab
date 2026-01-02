using System.Diagnostics;
using BatchieTab.Cli.Domain;

namespace BatchieTab.Cli.Adapters;

public class MacosPlatformAdapter : IPlatformAdapter
{
    public string? GetDefaultBrowser()
    {
        if (!OperatingSystem.IsMacOS())
            return null;

        try
        {
            var output = RunAndCapture(
                "plutil",
                "-p ~/Library/Preferences/com.apple.LaunchServices/com.apple.launchservices.secure.plist");

            if (string.IsNullOrWhiteSpace(output))
                return null;

            output = output.ToLowerInvariant();

            if (output.Contains("com.apple.safari"))
                return EngineType.Safari;

            if (output.Contains("com.google.chrome"))
                return EngineType.Chrome;

            if (output.Contains("org.mozilla.firefox"))
                return EngineType.Firefox;

            if (output.Contains("com.brave.browser"))
                return EngineType.Brave;

            if (output.Contains("com.microsoft.edgemac"))
                return EngineType.Edge;

            if (output.Contains("org.chromium.chromium"))
                return EngineType.Chromium;

            return null;
        }
        catch
        {
            return null;
        }
    }

    public bool IsBrowserInstalled(string browser)
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
            EngineType.Safari => new[]
            {
                "/Applications/Safari.app"
            },
            EngineType.Edge => new[]
            {
                "/Applications/Microsoft Edge.app"
            },
            EngineType.Brave => new[]
            {
                "/Applications/Brave Browser.app"
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
            EngineType.Edge => new[]
            {
                "/usr/local/bin/microsoft-edge",
                "/opt/homebrew/bin/microsoft-edge"
            },
            EngineType.Brave => new[]
            {
                "/usr/local/bin/brave-browser",
                "/opt/homebrew/bin/brave-browser"
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

    /* Untested - Coded only for completion purposes */
    public bool CommandExists(string command)
    {
        if (!OperatingSystem.IsMacOS())
            return false;

        try
        {
            using var process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "bash",
                Arguments = $"-c \"command -v {command}\"",
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
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return process.ExitCode == 0 ? output : null;
        }
        catch
        {
            return null;
        }
    }
}

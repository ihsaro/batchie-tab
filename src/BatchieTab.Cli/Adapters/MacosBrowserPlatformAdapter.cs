using BatchieTab.Cli.Domain;

namespace BatchieTab.Cli.Adapters;

public class MacosBrowserPlatformAdapter : IBrowserPlatformAdapter
{
    public string? GetDefaultBrowser()
    {
        throw new NotImplementedException();
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
}
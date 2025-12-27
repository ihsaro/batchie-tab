using BatchieTab.Cli.Domain;

namespace BatchieTab.Cli.Adapters;

public class WindowsBrowserPlatformAdapter : IBrowserPlatformAdapter
{
    public string? GetDefaultBrowser()
    {
        throw new NotImplementedException();
    }

    public bool IsBrowserInstalled(string browser)
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
}
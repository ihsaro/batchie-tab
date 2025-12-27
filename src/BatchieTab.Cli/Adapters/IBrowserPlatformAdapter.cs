namespace BatchieTab.Cli.Adapters;

public interface IBrowserPlatformAdapter
{
    string? GetDefaultBrowser();
    bool IsBrowserInstalled(string browser);
}
namespace BatchieTab.Cli.Adapters;

public interface IPlatformAdapter
{
    string? GetDefaultBrowser();
    bool IsBrowserInstalled(string browser);
    bool CommandExists(string command);
}
using BatchieTab.Cli.Adapters;
using BatchieTab.Cli.Factories;

namespace BatchieTab.Cli.Helpers;

public static class EngineHelper
{
    private static readonly IBrowserPlatformAdapter BrowserPlatformAdapter = BrowserPlatformAdapterFactory.Create();

    public static string? GetDefaultBrowser() => BrowserPlatformAdapter.GetDefaultBrowser();

    public static bool IsBrowserInstalled(string browser) => BrowserPlatformAdapter.IsBrowserInstalled(browser);
}
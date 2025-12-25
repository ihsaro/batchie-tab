namespace BatchieTab.Cli.Engines;

public interface IBrowserEngine
{
    void Open(IEnumerable<string> urls);
    void OpenIncognito(IEnumerable<string> urls);
}
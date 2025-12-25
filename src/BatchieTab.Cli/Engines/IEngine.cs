namespace BatchieTab.Cli.Engines;

public interface IEngine
{
    void Open(IEnumerable<string> urls);
    void OpenIncognito(IEnumerable<string> urls);
}
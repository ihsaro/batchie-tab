using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class MacosChromeEngine : IEngine
{
    public void Open(IEnumerable<string> urls)
    {
        var args = BuildArgs("--new-window", urls);
        StartProcess(args);
    }

    public void OpenIncognito(IEnumerable<string> urls)
    {
        var args = BuildArgs("--new-window --incognito", urls);
        StartProcess(args);
    }

    private static string BuildArgs(string chromeArgs, IEnumerable<string> urls)
    {
        var urlArgs = string.Join(" ", urls.Select(u => $"\"{u}\""));
        return $"-a \"Google Chrome\" --args {chromeArgs} {urlArgs}";
    }

    private static void StartProcess(string args)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "open",
            Arguments = args,
            UseShellExecute = true
        });
    }
}
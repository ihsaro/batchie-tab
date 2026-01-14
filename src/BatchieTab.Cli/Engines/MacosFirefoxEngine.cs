using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class MacosFirefoxEngine : IEngine
{
    public void Open(IEnumerable<string> urls)
    {
        var urlList = urls.ToList();
        if (urlList.Count == 0) return;

        // Firefox's --new-window only accepts one URL, so we use -new-tab for the rest
        var firefoxArgs = $"--new-window \"{urlList[0]}\"";
        if (urlList.Count > 1)
        {
            firefoxArgs += " " + string.Join(" ", urlList.Skip(1).Select(u => $"-new-tab \"{u}\""));
        }

        var args = $"-na \"Firefox\" --args {firefoxArgs}";
        StartProcess(args);
    }

    public void OpenIncognito(IEnumerable<string> urls)
    {
        var urlList = urls.ToList();
        if (urlList.Count == 0) return;

        // Launch first URL to create the private window
        StartProcess($"-na \"Firefox\" --args -private-window \"{urlList[0]}\"");

        // Launch remaining URLs with a delay - Firefox will add them as tabs to the existing private window
        foreach (var url in urlList.Skip(1))
        {
            Thread.Sleep(500);
            StartProcess($"-na \"Firefox\" --args -private-window \"{url}\"");
        }
    }

    private static void StartProcess(string args)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "open",
            Arguments = args,
            UseShellExecute = false
        });
    }
}
using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class WindowsFirefoxEngine : IEngine
{
    public void Open(IEnumerable<string> urls)
    {
        var urlList = urls.ToList();
        if (urlList.Count == 0) return;

        // Firefox's --new-window only accepts one URL, so we use -new-tab for the rest
        var args = $"--new-window \"{urlList[0]}\"";
        if (urlList.Count > 1)
        {
            args += " " + string.Join(" ", urlList.Skip(1).Select(u => $"-new-tab \"{u}\""));
        }

        StartProcess(args);
    }

    public void OpenIncognito(IEnumerable<string> urls)
    {
        var urlList = urls.ToList();
        if (urlList.Count == 0) return;

        // Launch first URL to create the private window
        StartProcess($"-private-window \"{urlList[0]}\"");

        // Launch remaining URLs with a delay - Firefox will add them as tabs to the existing private window
        foreach (var url in urlList.Skip(1))
        {
            Thread.Sleep(500);
            StartProcess($"-private-window \"{url}\"");
        }
    }

    private static void StartProcess(string firefoxArgs)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = $"/c start firefox {firefoxArgs}",
            UseShellExecute = true,
            CreateNoWindow = true
        });
    }
}
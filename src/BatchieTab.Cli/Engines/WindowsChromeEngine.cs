using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class WindowsChromeEngine : IEngine
{
    public void Open(IEnumerable<string> urls)
    {
        var args = "--new-window " + string.Join(" ", urls.Select(u => $"\"{u}\""));
        StartProcess(args);
    }

    public void OpenIncognito(IEnumerable<string> urls)
    {
        var args = "--new-window --incognito " + string.Join(" ", urls.Select(u => $"\"{u}\""));
        StartProcess(args);
    }

    private static void StartProcess(string chromeArgs)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = $"/c start chrome {chromeArgs}",
            UseShellExecute = true,
            CreateNoWindow = true
        });
    }
}
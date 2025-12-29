using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class WindowsChromiumEngine : IEngine
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

    private static void StartProcess(string chromiumArgs)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = $"/c start chromium {chromiumArgs}",
            UseShellExecute = true,
            CreateNoWindow = true
        });
    }
}
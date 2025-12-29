using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class LinuxChromiumEngine : IEngine
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

    private static void StartProcess(string args)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "chromium",
            Arguments = args,
            UseShellExecute = true
        });
    }
}
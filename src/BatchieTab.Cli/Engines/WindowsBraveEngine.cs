using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class WindowsBraveEngine : IEngine
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

    private static void StartProcess(string braveArgs)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = $"/c start brave {braveArgs}",
            UseShellExecute = true,
            CreateNoWindow = true
        });
    }
}
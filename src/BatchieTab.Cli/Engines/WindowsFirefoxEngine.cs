using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class WindowsFirefoxEngine : IEngine
{
    public void Open(IEnumerable<string> urls)
    {
        var args = "--new-window " + string.Join(" ", urls.Select(u => $"\"{u}\""));
        StartProcess(args);
    }

    public void OpenIncognito(IEnumerable<string> urls)
    {
        var args = "-private-window " + string.Join(" ", urls.Select(u => $"\"{u}\""));
        StartProcess(args);
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
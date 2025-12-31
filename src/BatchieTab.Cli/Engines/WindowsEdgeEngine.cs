using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class WindowsEdgeEngine : IEngine
{
    public void Open(IEnumerable<string> urls)
    {
        var args = "--new-window " + string.Join(" ", urls.Select(u => $"\"{u}\""));
        StartProcess(args);
    }

    public void OpenIncognito(IEnumerable<string> urls)
    {
        var args = "--new-window --inprivate " + string.Join(" ", urls.Select(u => $"\"{u}\""));
        StartProcess(args);
    }

    private static void StartProcess(string edgeArgs)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = $"/c start msedge {edgeArgs}",
            UseShellExecute = true,
            CreateNoWindow = true
        });
    }
}
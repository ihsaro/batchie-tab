using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class MacosFirefoxEngine : IEngine
{
    public void Open(IEnumerable<string> urls)
    {
        var args =
            "-a \"Firefox\" " +
            string.Join(" ", urls.Select(u => $"\"{u}\""));

        StartProcess(args);
    }

    public void OpenIncognito(IEnumerable<string> urls)
    {
        var args =
            "-na \"Firefox\" --args -private-window " +
            string.Join(" ", urls.Select(u => $"\"{u}\""));

        StartProcess(args);
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
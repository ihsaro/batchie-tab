using System.Diagnostics;
using BatchieTab.Cli.Helpers;

namespace BatchieTab.Cli.Engines;

public class LinuxEdgeEngine : IEngine
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

    private static void StartProcess(string args)
    {
        var command =
            PlatformHelper.CommandExists("microsoft-edge") ? $"microsoft-edge {args}" :
            PlatformHelper.CommandExists("flatpak") ? $"flatpak run com.microsoft.Edge {args}" :
            throw new InvalidOperationException("Microsoft edge browser not found");

        Process.Start(new ProcessStartInfo
        {
            FileName = "bash",
            Arguments = $"-c \"{command} >/dev/null 2>&1 &\"",
            UseShellExecute = false,
            CreateNoWindow = true
        });
    }
}
using System.Diagnostics;
using BatchieTab.Cli.Helpers;

namespace BatchieTab.Cli.Engines;

public class LinuxBraveEngine : IEngine
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
        var command =
            PlatformHelper.CommandExists("brave-browser") ? $"brave-browser {args}" :
            PlatformHelper.CommandExists("brave") ? $"brave {args}" :
            PlatformHelper.CommandExists("flatpak") ? $"flatpak run com.brave.Browser {args}" :
            throw new InvalidOperationException("Brave browser not found");

        Process.Start(new ProcessStartInfo
        {
            FileName = "bash",
            Arguments = $"-c \"{command} >/dev/null 2>&1 &\"",
            UseShellExecute = false,
            CreateNoWindow = true
        });
    }
}
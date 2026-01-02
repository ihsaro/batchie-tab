using System.Diagnostics;
using BatchieTab.Cli.Helpers;

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
        var command =
            PlatformHelper.CommandExists("chromium-browser") ? $"chromium-browser {args}" :
            PlatformHelper.CommandExists("chromium") ? $"chromium {args}" :
            PlatformHelper.CommandExists("flatpak") ? $"flatpak run org.chromium.Chromium {args}" :
            throw new InvalidOperationException("Chromium browser not found");

        Process.Start(new ProcessStartInfo
        {
            FileName = "bash",
            Arguments = $"-c \"{command} >/dev/null 2>&1 &\"",
            UseShellExecute = false,
            CreateNoWindow = true
        });
    }
}
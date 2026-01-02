using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

/*
 * TODO
 * Fix issue in Open, whereby it opens in 2 windows: n - 1 urls in a window and 1 url in another window.
 * Fix issue is OpenIncognito, where it opens n - 1 urls but 1 random url is not opened, but instead is opened in a new tab in the same incognito window. 
 */
public class LinuxFirefoxEngine : IEngine
{
    public void Open(IEnumerable<string> urls)
    {
        var args = "--new-window " + string.Join(" ", urls.Select(u => $"\"{u}\""));

        StartProcess(args);
    }

    public void OpenIncognito(IEnumerable<string> urls)
    {
        foreach (var url in urls)
        {
            StartProcess($"--no-remote -private-window \"{url}\"");
        }
    }

    private static void StartProcess(string args)
    {
        var command =
            CommandExists("firefox") ? $"firefox {args}" :
            CommandExists("flatpak") ? $"flatpak run org.mozilla.firefox {args}" :
            throw new InvalidOperationException("Firefox browser not found");

        Process.Start(new ProcessStartInfo
        {
            FileName = "bash",
            Arguments = $"-c \"{command} >/dev/null 2>&1 &\"",
            UseShellExecute = false,
            CreateNoWindow = true
        });
    }
    
    private static bool CommandExists(string command)
    {
        try
        {
            var process = Process.Start(new ProcessStartInfo
            {
                FileName = "bash",
                Arguments = $"-c \"command -v {command}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });

            process!.WaitForExit();
            return process.ExitCode == 0;
        }
        catch
        {
            return false;
        }
    }
}
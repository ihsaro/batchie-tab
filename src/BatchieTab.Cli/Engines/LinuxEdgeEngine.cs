using System.Diagnostics;

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
            CommandExists("microsoft-edge") ? $"microsoft-edge {args}" :
            CommandExists("flatpak") ? $"flatpak run com.microsoft.Edge {args}" :
            throw new InvalidOperationException("Microsoft edge browser not found");

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
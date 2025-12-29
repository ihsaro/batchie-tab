using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class MacosSafariEngine : IEngine
{
    public void Open(IEnumerable<string> urls)
    {
        foreach (var url in urls)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "open",
                Arguments = $"-a Safari \"{url}\"",
                UseShellExecute = false
            });
        }
    }

    public void OpenIncognito(IEnumerable<string> urls)
    {
        var args = new List<string>
        {
            "-e", "tell application \"Safari\" to activate",
            "-e", "tell application \"System Events\"",
            "-e", "keystroke \"n\" using {shift down, command down}",
            "-e", "end tell"
        };

        foreach (var url in urls)
        {
            args.Add("-e");
            args.Add($"tell application \"Safari\" to make new tab at end of tabs of front window with properties {{URL:\"{url}\"}}");
        }

        Process.Start(new ProcessStartInfo
        {
            FileName = "osascript",
            Arguments = string.Join(" ", args.Select(Quote)),
            UseShellExecute = false
        });
    }

    private static string Quote(string value)
        => $"\"{value.Replace("\"", "\\\"")}\"";
}
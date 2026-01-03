using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class WindowsChromiumEngine : IEngine
{
    private static readonly string[] ChromiumPaths =
    {
        @"C:\Program Files\Chromium\Application\chrome.exe",
        @"C:\Program Files (x86)\Chromium\Application\chrome.exe"
    };

    public void Open(IEnumerable<string> urls)
    {
        StartProcess("--new-window", urls);
    }

    public void OpenIncognito(IEnumerable<string> urls)
    {
        StartProcess("--new-window --incognito", urls);
    }

    private static void StartProcess(string flags, IEnumerable<string> urls)
    {
        var chromiumExe = ChromiumPaths.FirstOrDefault(File.Exists);

        if (chromiumExe is null)
        {
            throw new InvalidOperationException("Chromium is not installed.");
        }

        var args =
            $"{flags} " +
            string.Join(" ", urls.Select(u => $"\"{u}\""));

        Process.Start(new ProcessStartInfo
        {
            FileName = chromiumExe,
            Arguments = args,
            UseShellExecute = false
        });
    }
}
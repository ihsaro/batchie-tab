using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class LinuxFirefoxEngine : IEngine
{
    public void Open(IEnumerable<string> urls)
    {
        
    }

    public void OpenIncognito(IEnumerable<string> urls)
    {
        var args = "-private-window " + string.Join(" ", urls.Select(u => $"\"{u}\""));
        StartProcess(args);
    }
    
    private static void StartProcess(string args)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "firefox",
            Arguments = args,
            UseShellExecute = true
        });
    }
}
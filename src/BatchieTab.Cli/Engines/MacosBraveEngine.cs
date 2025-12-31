using System.Diagnostics;

namespace BatchieTab.Cli.Engines;

public class MacosBraveEngine : IEngine
{
    public void Open(IEnumerable<string> urls)
        => StartProcess(urls, incognito: false);

    public void OpenIncognito(IEnumerable<string> urls)
        => StartProcess(urls, incognito: true);

    private static void StartProcess(IEnumerable<string> urls, bool incognito)
    {
        var urlList = string.Join(", ", urls.Select(u => $"\"{u}\""));

        var script = incognito
            ? $@"
tell application ""Brave Browser""
    activate
    set w to make new window with properties {{mode:""incognito""}}
    repeat with u in {{{urlList}}}
        make new tab at end of tabs of w with properties {{URL:u}}
    end repeat
end tell"
            : $@"
tell application ""Brave Browser""
    activate
    set w to make new window
    repeat with u in {{{urlList}}}
        make new tab at end of tabs of w with properties {{URL:u}}
    end repeat
end tell";

        Process.Start(new ProcessStartInfo
        {
            FileName = "osascript",
            Arguments = $"-e {Escape(script)}",
            UseShellExecute = false
        });
    }

    private static string Escape(string script)
    {
        return $"\"{script.Replace("\"", "\\\"")}\"";
    }
}
using System.Diagnostics;
using BatchieTab.Cli.Domain;
using Microsoft.Win32;

namespace BatchieTab.Cli.Adapters;

public class WindowsPlatformAdapter : IPlatformAdapter
{
    public string? GetDefaultBrowser()
    {
        if (!OperatingSystem.IsWindows())
        {
            return null;
        }
        
        try
        {
            using var key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice");

            var progId = key?.GetValue("ProgId") as string;
            if (string.IsNullOrWhiteSpace(progId))
                return null;

            progId = progId.ToLowerInvariant();

            if (progId.Contains("chrome"))
                return EngineType.Chrome;

            if (progId.Contains("firefox"))
                return EngineType.Firefox;

            if (progId.Contains("brave"))
                return EngineType.Brave;

            if (progId.Contains("edge"))
                return EngineType.Edge;

            if (progId.Contains("chromium"))
                return EngineType.Chromium;

            return null;
        }
        catch
        {
            return null;
        }
    }

    public bool IsBrowserInstalled(string browser)
    {
        var programFiles = new[]
        {
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
        };

        var paths = browser switch
        {
            EngineType.Chrome => programFiles.Select(p =>
                Path.Combine(p, "Google", "Chrome", "Application", "chrome.exe")),

            EngineType.Chromium => programFiles.Select(p =>
                Path.Combine(p, "Chromium", "Application", "chrome.exe")),

            EngineType.Firefox => programFiles.Select(p =>
                Path.Combine(p, "Mozilla Firefox", "firefox.exe")),

            EngineType.Brave => programFiles.Select(p =>
                Path.Combine(p, "BraveSoftware", "Brave-Browser", "Application", "brave.exe")),

            EngineType.Edge => programFiles.Select(p =>
                Path.Combine(p, "Microsoft", "Edge", "Application", "msedge.exe")),

            _ => []
        };

        return paths.Any(File.Exists);
    }

    /* Untested - Coded only for completion purposes */
    public bool CommandExists(string command)
    {
        try
        {
            using var process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "where",
                Arguments = command,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            process.Start();
            process.WaitForExit();

            return process.ExitCode == 0;
        }
        catch
        {
            return false;
        }
    }
}
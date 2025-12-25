namespace BatchieTab.Cli.Domain;

public static class EngineType
{
    public static string Chrome => "chrome";
    public static string Chromium => "chromium";
    public static string Firefox => "firefox";
    
    private static readonly HashSet<string> All =
    [
        Chrome,
        Chromium,
        Firefox,
    ];

    public static bool IsValid(string? value)
        => value is not null && All.Contains(value);
}
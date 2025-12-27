namespace BatchieTab.Cli.Domain;

public static class EngineType
{
    public const string Chrome = "chrome";
    public const string Chromium = "chromium";
    public const string Firefox = "firefox";
    
    private static readonly HashSet<string> All =
    [
        Chrome,
        Chromium,
        Firefox,
    ];

    public static bool IsValid(string? value)
        => value is not null && All.Contains(value);
}
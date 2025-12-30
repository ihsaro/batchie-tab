namespace BatchieTab.Cli.Domain;

public static class EngineType
{
    public const string Brave = "brave";
    public const string Chrome = "chrome";
    public const string Chromium = "chromium";
    public const string Firefox = "firefox";
    public const string Safari = "safari";
    
    private static readonly HashSet<string> All =
    [
        Brave,
        Chrome,
        Chromium,
        Firefox,
        Safari
    ];

    public static bool IsValid(string? value)
        => value is not null && All.Contains(value);
}
namespace BatchieTab.Cli.Domain;

public static class EngineType
{
    public const string Brave = "brave";
    public const string Chrome = "chrome";
    public const string Chromium = "chromium";
    public const string Edge = "edge";
    public const string Firefox = "firefox";
    public const string Safari = "safari";
    
    public static readonly HashSet<string> All =
    [
        Brave,
        Chrome,
        Chromium,
        Edge,
        Firefox,
        Safari
    ];

    public static bool IsValid(string? value)
        => value is not null && All.Contains(value);
}
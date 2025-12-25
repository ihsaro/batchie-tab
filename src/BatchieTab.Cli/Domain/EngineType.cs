namespace BatchieTab.Cli.Domain;

public static class EngineType
{
    public static string Chrome => "Chrome";
    public static string Firefox => "Firefox";
    
    private static readonly HashSet<string> All =
    [
        Chrome,
        Firefox,
    ];

    public static bool IsValid(string? value)
        => value is not null && All.Contains(value);
}
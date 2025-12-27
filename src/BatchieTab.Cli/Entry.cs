using BatchieTab.Cli.Domain;
using BatchieTab.Cli.Engines;
using BatchieTab.Cli.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace BatchieTab.Cli;

public class Entry(IServiceProvider serviceProvider)
{
    private const string BrowserArgumentName = "--browser";
    private const string PathArgumentName = "--path";
    
    public void Run(string[] args)
    {
        string? browser = null;
        var path = "./batchie-tab-file";
        
        List<string> urls = [];

        var os = OperatingSystemHelper.GetOperatingSystem();

        if (args.Length > 0)
        {
            if (args.Contains(PathArgumentName))
            {
                var filePathIndex = args.IndexOf(PathArgumentName);

                if (args.Length > filePathIndex + 1)
                {
                    path = args[filePathIndex + 1];
                }
            }
            
            if (args.Contains(BrowserArgumentName))
            {
                var browserIndex = args.IndexOf(BrowserArgumentName);

                if (args.Length > browserIndex + 1)
                {
                    browser = args[browserIndex + 1];

                    if (!EngineType.IsValid(browser))
                    {
                        Console.WriteLine($"Invalid {BrowserArgumentName} value, possible values are: {EngineType.Chrome}, {EngineType.Chromium}, {EngineType.Firefox}");
                        return;
                    }
                    if (!EngineHelper.IsBrowserInstalled(browser))
                    {
                        Console.WriteLine("Specified browser is not installed");
                        return;
                    }
                }
            }
            else
            {
                var defaultBrowser = EngineHelper.GetDefaultBrowser();

                if (defaultBrowser is null)
                {
                    Console.WriteLine($"Unsupported default browser, accepted browsers are: {EngineType.Chrome}, {EngineType.Chromium}, {EngineType.Firefox}");
                    return;
                }

                browser = defaultBrowser;
            }
        }
        
        try
        {
            using var reader = new StreamReader(path);

            while (reader.ReadLine() is { } line)
            {
                urls.Add(line);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{path}' not found.");
            return;
        }
        
        var engine = serviceProvider.GetRequiredKeyedService<IEngine>($"{os}-{browser}");

        if (args.Contains("--incognito"))
        {
            engine.OpenIncognito(urls);
        }
        else
        {
            engine.Open(urls);
        }
    }
}
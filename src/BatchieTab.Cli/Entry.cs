using BatchieTab.Cli.Domain;
using BatchieTab.Cli.Engines;
using BatchieTab.Cli.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace BatchieTab.Cli;

public class Entry(IServiceProvider serviceProvider)
{
    private const string BrowserArgumentName = "--browser";
    private const string HelpArgumentName = "--help";
    private const string PathArgumentName = "--path";
    
    public void Run(string[] args)
    {
        if (args.Contains(HelpArgumentName))
        {
            Console.WriteLine($"-- HOW TO --\n");
            Console.WriteLine($"Complete usage with all possible arguments : <batchie-tab-script-file-name> --path <path-to-urls-file> --browser <{string.Join("|", EngineType.All)}> --incognito\n");
            Console.WriteLine("-- ARGUMENTS --\n");
            Console.WriteLine("--path\t\tArgument to support a custom urls file location. If not specified, BatchieTab will attempt to look for a file called 'batchie-tab-file' in the same location as the running script.");
            Console.WriteLine($"--browser\tArgument to support choosing a specific browser. Values allowed are {string.Join(", ", EngineType.All)}.");
            Console.WriteLine("--incognito\tArgument to support opening the list of tabs in an incognito window. If not specified, tabs will open in a normal / regular window.");
            Console.WriteLine("--help\t\tDisplay this current help page. In case specified, all other arguments will not be considered and the help page will display while not opening any tab. Program would terminate after help page is displayed.");
            
            return;
        }
        
        string? browser = null;
        var path = "./batchie-tab-file";
        
        List<string> urls = [];

        var os = PlatformHelper.GetOperatingSystem();

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
                        Console.WriteLine($"Invalid {BrowserArgumentName} value, possible values are: {string.Join(", ", EngineType.All)}.");
                        return;
                    }
                    if (!PlatformHelper.IsBrowserInstalled(browser))
                    {
                        Console.WriteLine("Specified browser is not installed");
                        return;
                    }
                }
            }
            else
            {
                var defaultBrowser = PlatformHelper.GetDefaultBrowser();

                if (defaultBrowser is null)
                {
                    Console.WriteLine($"Unsupported default browser, accepted browsers are: {string.Join(", ", EngineType.All)}.");
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
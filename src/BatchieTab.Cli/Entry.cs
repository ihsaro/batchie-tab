using BatchieTab.Cli.Domain;
using BatchieTab.Cli.Engines;
using Microsoft.Extensions.DependencyInjection;

namespace BatchieTab.Cli;

public class Entry(IServiceProvider serviceProvider)
{
    public void Run(string[] args)
    {
        var path = "./batchie-tab-file";
        List<string> urls = [];

        if (args.Length > 0)
        {
            path = args[1];
            /*
            if (args is ["--file-path", _])
            {
                path = args[1];
            }
            else
            {
                Console.WriteLine(args is ["--file-path"]
                    ? "File path missing."
                    : "Invalid argument found.");
                return;
            }
            */
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
            Console.WriteLine("File not found.");
            return;
        }

        var engine = serviceProvider.GetRequiredKeyedService<IBrowserEngine>(EngineType.Firefox);

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
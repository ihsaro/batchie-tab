using BatchieTab.Cli;
using BatchieTab.Cli.Domain;
using BatchieTab.Cli.Engines;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddKeyedTransient<IEngine, ChromeEngine>(EngineType.Chrome);
        services.AddKeyedTransient<IEngine, ChromiumEngine>(EngineType.Chromium);
        services.AddKeyedTransient<IEngine, FirefoxEngine>(EngineType.Firefox);
        services.AddTransient<Entry>();
    })
    .Build();

new Entry(host.Services).Run(args);
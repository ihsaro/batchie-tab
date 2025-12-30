using BatchieTab.Cli;
using BatchieTab.Cli.Domain;
using BatchieTab.Cli.Engines;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddKeyedTransient<IEngine, LinuxBraveEngine>($"{OperatingSystemType.Linux}-{EngineType.Brave}");
        services.AddKeyedTransient<IEngine, LinuxChromeEngine>($"{OperatingSystemType.Linux}-{EngineType.Chrome}");
        services.AddKeyedTransient<IEngine, LinuxChromiumEngine>($"{OperatingSystemType.Linux}-{EngineType.Chromium}");
        services.AddKeyedTransient<IEngine, LinuxFirefoxEngine>($"{OperatingSystemType.Linux}-{EngineType.Firefox}");
        services.AddKeyedTransient<IEngine, MacosBraveEngine>($"{OperatingSystemType.Macos}-{EngineType.Brave}");
        services.AddKeyedTransient<IEngine, MacosChromeEngine>($"{OperatingSystemType.Macos}-{EngineType.Chrome}");
        services.AddKeyedTransient<IEngine, MacosChromiumEngine>($"{OperatingSystemType.Macos}-{EngineType.Chromium}");
        services.AddKeyedTransient<IEngine, MacosFirefoxEngine>($"{OperatingSystemType.Macos}-{EngineType.Firefox}");
        services.AddKeyedTransient<IEngine, MacosSafariEngine>($"{OperatingSystemType.Macos}-{EngineType.Safari}");
        services.AddKeyedTransient<IEngine, WindowsBraveEngine>($"{OperatingSystemType.Windows}-{EngineType.Brave}");
        services.AddKeyedTransient<IEngine, WindowsChromeEngine>($"{OperatingSystemType.Windows}-{EngineType.Chrome}");
        services.AddKeyedTransient<IEngine, WindowsChromiumEngine>($"{OperatingSystemType.Windows}-{EngineType.Chromium}");
        services.AddKeyedTransient<IEngine, WindowsFirefoxEngine>($"{OperatingSystemType.Windows}-{EngineType.Firefox}");
        services.AddTransient<Entry>();
    })
    .Build();

new Entry(host.Services).Run(args);
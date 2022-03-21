using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RechargeSharp.v2021_11.Configuration.DependencyInjection;
using RechargeSharp.v2021_11.ConsoleTester;
using Serilog;

var apiKey = "<insert-api-key>";

var hostBuilder = Host.CreateDefaultBuilder()
    .ConfigureServices(collection =>
    {
        collection.AddRechargeSharp2021_11(options => options.ApiKey = apiKey);
        collection.AddHostedService<ConsoleTesterLogic>();
    }).UseSerilog((context, configuration) => configuration.MinimumLevel.Debug().WriteTo.Console());

await hostBuilder.RunConsoleAsync();
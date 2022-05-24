// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RechargeSharp.v2021_11.Configuration.DependencyInjection;
using RechargeSharp.v2021_11.TestConsoleClient;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

var hostBuilder = Host
    .CreateDefaultBuilder()
    .ConfigureServices(collection =>
    {
        var apiKey = "<insert-api-key>";
        collection.AddRechargeSharp2021_11(options => options.ApiKey = apiKey);
        collection.AddHostedService<TestConsoleAppLogic>();
    })
    .UseSerilog()
    ;

await hostBuilder.RunConsoleAsync();

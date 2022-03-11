using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RechargeSharp.v2021_11.Endpoints.Addresses;
using RechargeSharp.v2021_11.Endpoints.Customers;
using RechargeSharp.v2021_11.Endpoints.PaymentMethods;
using RechargeSharp.v2021_11.Endpoints.Subscriptions;
using RechargeSharp.v2021_11.Utilities;

namespace RechargeSharp.v2021_11.Configuration.DependencyInjection;

public static class RechargeSharpDependencyInjection
{
    public static IServiceCollection AddRechargeSharp2021_11(this IServiceCollection services, Action<RechargeApiCallerOptions> options)
    {
        services
            .AddOptions<RechargeApiCallerOptions>()
            .Configure(options)
            .ValidateDataAnnotations();
        
        services.AddHttpClient("RechargeSharpClient", (services, opts) =>
        {
            opts.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            opts.BaseAddress = new Uri("https://api.rechargeapps.com/");
        }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() {MaxConnectionsPerServer = 256});

        services.AddTransient(x => options);
        services.AddLogging();

        services
            .AddScoped<IRechargeApiCaller, RechargeApiCaller>()
            .AddScoped<AddressService>()
            .AddScoped<CustomerService>()
            .AddScoped<SubscriptionService>()
            .AddScoped<PaymentMethodService>();

        return services;
    }
}
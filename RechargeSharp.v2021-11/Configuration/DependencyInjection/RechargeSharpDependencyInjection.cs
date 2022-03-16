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
    public const string RechargeSharpHttpClientKey = "RechargeSharpClient2021_11";
    
    public static IServiceCollection AddRechargeSharp2021_11(this IServiceCollection services, Action<RechargeApiCallerOptions> options)
    {
        services
            .AddOptions<RechargeApiCallerOptions>()
            .Configure(options)
            .ValidateDataAnnotations();
        
        services.AddHttpClient(RechargeSharpHttpClientKey, (_, opts) =>
        {
            opts.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            opts.BaseAddress = new Uri("https://api.rechargeapps.com/");
        }).AddHttpMessageHandler<LoggingHttpHandler>();

        services.AddTransient(x => options);
        services.AddLogging();

        services
            .AddTransient<IRechargeApiCaller, RechargeApiCaller>()
            .AddTransient<IAddressService,AddressService>()
            .AddTransient<ICustomerService, CustomerService>()
            .AddTransient<ISubscriptionService, SubscriptionService>()
            .AddTransient<IPaymentMethodService, PaymentMethodService>();

        return services;
    }
}
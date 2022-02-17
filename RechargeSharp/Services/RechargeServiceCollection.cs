using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using RechargeSharp.Services.Addresses;
using RechargeSharp.Services.Charges;
using RechargeSharp.Services.Checkouts;
using RechargeSharp.Services.Collections;
using RechargeSharp.Services.Customers;
using RechargeSharp.Services.Discounts;
using RechargeSharp.Services.Metafields;
using RechargeSharp.Services.Onetimes;
using RechargeSharp.Services.Orders;
using RechargeSharp.Services.Products;
using RechargeSharp.Services.Shops;
using RechargeSharp.Services.Subscriptions;
using RechargeSharp.Services.Webhooks;

namespace RechargeSharp.Services
{
    public static class RechargeServiceCollection
    {
        public static IServiceCollection AddRechargeSharp(this IServiceCollection services, Action<RechargeServiceOptions> options)
        {
            services.Configure(options);

            services.AddHttpClient("RechargeSharpClient", (services, opts) =>
            {
                opts.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                opts.BaseAddress = new Uri("https://api.rechargeapps.com/");
            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() {MaxConnectionsPerServer = 256});

            services.AddHttpClient("RechargeSharpWebhookClient", (services, opts) =>
            {
                opts.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                opts.BaseAddress = new Uri("https://api.rechargeapps.com/");
            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() { MaxConnectionsPerServer = 256 });

            services.AddTransient(x => options);
            services.AddLogging();

            services.AddTransient<AddressService>()
                .AddTransient<ChargeService>()
                .AddTransient<CheckoutService>()
                .AddTransient<CollectionService>()
                .AddTransient<CustomerService>()
                .AddTransient<DiscountService>()
                .AddTransient<MetafieldService>()
                .AddTransient<OnetimeService>()
                .AddTransient<OrderService>()
                .AddTransient<ProductService>()
                .AddTransient<ShopService>()
                .AddTransient<SubscriptionService>()
                .AddTransient<WebhookService>()
                .AddTransient<PaymentMethodService>();

            return services;
        }
    }
}

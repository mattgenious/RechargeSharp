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
using RechargeSharp.Services.PaymentMethods;
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

            services.AddTransient<IAddressService, AddressService>()
                .AddTransient<IChargeService, ChargeService>()
                .AddTransient<ICheckoutService, CheckoutService>()
                .AddTransient<ICollectionService, CollectionService>()
                .AddTransient<ICustomerService, CustomerService>()
                .AddTransient<IDiscountService, DiscountService>()
                .AddTransient<IMetafieldService, MetafieldService>()
                .AddTransient<IOnetimeService, OnetimeService>()
                .AddTransient<IOrderService, OrderService>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IShopService, ShopService>()
                .AddTransient<ISubscriptionService, SubscriptionService>()
                .AddTransient<IWebhookService, WebhookService>()
                .AddTransient<IPaymentMethodService, PaymentMethodService>();

            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RechargeSharp.Services;
using Stripe;

namespace RechargeSharp.Tests.Fixtures
{
    public class TestFixture
    {

        protected internal ServiceProvider ServiceProvider;
        protected internal ServiceCollection ServiceCollection;
        protected internal IConfiguration Configuration;
        protected internal IHostedService Service;


        public TestFixture()
        {

            ServiceCollection = new ServiceCollection();
            ServiceCollection.AddHostedService<TestService>();
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
            ServiceCollection.AddRechargeSharp(x =>
            {
                x.WebhookApiKey = Configuration["key"];
                x.ApiKeyArray = new string[] { Configuration["key"] };
            });
            ServiceCollection.AddTransient(x => new StripeClient(Configuration["StripeKey"]));
            ServiceCollection.AddTransient(x => new PaymentMethodService(x.GetRequiredService<StripeClient>()));
            ServiceCollection.AddTransient(x => new CustomerService(x.GetRequiredService<StripeClient>()));
            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Service = ServiceProvider.GetService<IHostedService>();
        }
    }
}

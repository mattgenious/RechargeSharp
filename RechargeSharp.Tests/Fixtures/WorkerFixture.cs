using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RechargeSharp.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

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
            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Service = ServiceProvider.GetService<IHostedService>();
        }
    }
    public class TestService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken).ConfigureAwait(false);
            }
        }
    }
}

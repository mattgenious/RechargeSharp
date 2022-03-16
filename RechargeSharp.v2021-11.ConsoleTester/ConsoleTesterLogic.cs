using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RechargeSharp.v2021_11.Endpoints.Customers;
using RechargeSharp.v2021_11.Endpoints.Subscriptions;

namespace RechargeSharp.v2021_11.ConsoleTester;

public class ConsoleTesterLogic : BackgroundService
{
    private readonly ILogger<ConsoleTesterLogic> _logger;
    private readonly ICustomerService _customerService;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;

    public ConsoleTesterLogic(ILogger<ConsoleTesterLogic> logger, ICustomerService customerService, IHostApplicationLifetime hostApplicationLifetime)
    {
        _logger = logger;
        _customerService = customerService;
        _hostApplicationLifetime = hostApplicationLifetime;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var response = await _customerService.GetCustomerAsync(80630241);
        _logger.LogInformation($"Customer: {response?.Customer}");
        _hostApplicationLifetime.StopApplication();
    }
}
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RechargeSharp.v2021_11.Endpoints.Customers;
using Serilog.Context;

namespace RechargeSharp.v2021_11.TestConsoleClient;

public class TestConsoleAppLogic : BackgroundService
{
    private readonly CustomerService _customerService;
    private readonly ILogger _logger;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;

    public TestConsoleAppLogic(CustomerService customerService, ILogger<TestConsoleAppLogic> logger, IHostApplicationLifetime hostApplicationLifetime)
    {
        _customerService = customerService;
        _logger = logger;
        _hostApplicationLifetime = hostApplicationLifetime;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int customerCount = 0;
        string? nextCursor = null;

        using (LogContext.PushProperty("CorrelationId", Guid.NewGuid().ToString()))
        {
            do
            {
                var response = await _customerService.ListCustomers(new CustomerService.ListCustomersTypes.Request()
                {
                    Cursor = nextCursor
                });
                nextCursor = response.NextCursor;
    
                foreach (var customer in response.Customers)
                {
                    customerCount++;
                    Console.WriteLine($"Customer {customerCount}: {customer.Id} - {customer.Email}");
                }
            } while (nextCursor != null);

            _logger.LogInformation($"Total customer count: {customerCount}");
            _hostApplicationLifetime.StopApplication();
        }
    }
}
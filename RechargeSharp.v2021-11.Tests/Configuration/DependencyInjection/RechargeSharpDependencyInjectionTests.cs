using System;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RechargeSharp.v2021_11.Configuration.DependencyInjection;
using RechargeSharp.v2021_11.Endpoints.Addresses;
using RechargeSharp.v2021_11.Endpoints.Customers;
using RechargeSharp.v2021_11.Endpoints.PaymentMethods;
using RechargeSharp.v2021_11.Endpoints.Subscriptions;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Configuration.DependencyInjection;

public class RechargeSharpDependencyInjectionTests
{
    [Theory]
    [InlineData(typeof(AddressService))]
    [InlineData(typeof(CustomerService))]
    [InlineData(typeof(SubscriptionService))]
    [InlineData(typeof(PaymentMethodService))]
    public void CanResolveRechargeSharpServicesAfterUsingTheDIHelper(Type serviceType)
    {
        // Arrange
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddRechargeSharp2021_11(options => options.ApiKey = "somekey");
        var serviceProvider = serviceCollection.BuildServiceProvider();
        
        // Act
        var service = serviceProvider.GetService(serviceType);
        
        // Assert
        service.Should().NotBeNull();
    }

    [Fact]
    public void ThrowsOnRechargerApiCallerOptionsWithMissingApiKey()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddRechargeSharp2021_11(options => options.ApiKey = string.Empty);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        
        // Act
        var act = () => serviceProvider.GetService<AddressService>();
        
        // Assert
        act.Should()
            .Throw<OptionsValidationException>()
            .WithMessage($"*{nameof(RechargeApiCallerOptions.ApiKey)}*", "an API key is missing");
    }
}
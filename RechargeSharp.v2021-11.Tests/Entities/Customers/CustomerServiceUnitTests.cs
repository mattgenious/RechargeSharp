using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RechargeSharp.v2021_11.Entities.Customers;
using RechargeSharp.v2021_11.Utilities;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Entities.Customers;

public class CustomerServiceUnitTests
{
    private readonly Fixture _fixture;

    public CustomerServiceUnitTests()
    {
        _fixture = new Fixture();
    }
    
    [Fact]
    public async Task CanListCustomers()
    {
        // Arrange
        var request = _fixture.Create<CustomerService.ListCustomersTypes.Request>();
        var response = _fixture.Create<CustomerService.ListCustomersTypes.Response>();
        var apiCallerMock = new Mock<IRechargeApiCaller>(MockBehavior.Strict);
        var uriToMock = "/customers";
        apiCallerMock.Setup(
            r => r.Get<CustomerService.ListCustomersTypes.Response>(It.Is<string>(s => s.StartsWith(uriToMock))))
            .ReturnsAsync(response)
            .Verifiable();
        
        var sut = CreateSut(apiCallerMock.Object);
        
        // Act
        var actualResponse = await sut.ListCustomers(request);

        // Assert
        apiCallerMock.Verify();
        actualResponse.Should().Be(response);
    }
    
    [Fact]
    public async Task CanGetCustomer()
    {
        // Arrange
        var response = _fixture.Create<CustomerService.GetCustomerTypes.Response>();
        var apiCallerMock = new Mock<IRechargeApiCaller>(MockBehavior.Strict);
        var customerId = 123;
        var uriToMock = $"/customers/{customerId}";
        apiCallerMock.Setup(
                r => r.Get<CustomerService.GetCustomerTypes.Response>(uriToMock))
            .ReturnsAsync(response)
            .Verifiable();
        
        var sut = CreateSut(apiCallerMock.Object);
    
        // Act
        var actualResponse = await sut.GetCustomer(customerId);

        // Assert
        apiCallerMock.Verify();
        actualResponse.Should().Be(response);
    }
    
    [Fact]
    public async Task CanUpdateCustomer()
    {
        // Arrange
        var request = _fixture.Create<CustomerService.UpdateCustomerTypes.Request>();
        var response = _fixture.Create<CustomerService.UpdateCustomerTypes.Response>();
        var apiCallerMock = new Mock<IRechargeApiCaller>(MockBehavior.Strict);
        var customerId = 123;
        var uriToMock = $"/customers/{customerId}";
        apiCallerMock.Setup(
                r => r.Put<CustomerService.UpdateCustomerTypes.Request, CustomerService.UpdateCustomerTypes.Response>(request,uriToMock))
            .ReturnsAsync(response)
            .Verifiable();
        
        var sut = CreateSut(apiCallerMock.Object);
    
        // Act
        var actualResponse = await sut.UpdateCustomer(customerId, request);

        // Assert
        apiCallerMock.Verify();
        actualResponse.Should().Be(response);
    }
    
    [Fact]
    public async Task CanDeleteCustomer()
    {
        var apiCallerMock = new Mock<IRechargeApiCaller>(MockBehavior.Strict);
        var customerId = 123;
        var uriToMock = $"/customers/{customerId}";
        apiCallerMock.Setup(
                r => r.Delete(uriToMock))
            .Returns(Task.CompletedTask)
            .Verifiable();
        
        var sut = CreateSut(apiCallerMock.Object);
    
        // Act
        await sut.DeleteCustomer(customerId);

        // Assert
        apiCallerMock.Verify();
    }    
    
    [Fact]
    public async Task CanCreateCustomer()
    {
        // Arrange
        var request = _fixture.Create<CustomerService.CreateCustomerTypes.Request>();
        var response = _fixture.Create<CustomerService.CreateCustomerTypes.Response>();
        var apiCallerMock = new Mock<IRechargeApiCaller>(MockBehavior.Strict);
        var customerId = 123;
        var uriToMock = $"/customers";
        apiCallerMock.Setup(
                r => r.Post<CustomerService.CreateCustomerTypes.Request, CustomerService.CreateCustomerTypes.Response>(request,uriToMock))
            .ReturnsAsync(response)
            .Verifiable();
        
        var sut = CreateSut(apiCallerMock.Object);
    
        // Act
        var actualResponse = await sut.CreateCustomer(request);

        // Assert
        apiCallerMock.Verify();
        actualResponse.Should().Be(response);
    }
    
    [Fact]
    public async Task CanGetCustomerDeliverySchedule()
    {
        // Arrange
        // var jsonReturnedByApi = "{\"deliverySchedule\":{\"customer\":{\"id\":73720164,\"email\":\"test@example.com\",\"first_name\":\"Aria\",\"last_name\":\"Beciu\"},\"deliveries\":[{\"date\":\"2022-02-07\",\"orders\":[{\"id\":null,\"address_id\":79342717,\"charge_id\":507503288,\"line_items\":[{\"subscription_id\":186930285,\"external_product_id\":{\"ecommerce\":null},\"external_variant_id\":{\"ecommerce\":null},\"images\":{},\"is_skippable\":false,\"plan_type\":null,\"product_title\":\"Organic coffee beans\",\"properties\":[],\"quantity\":1,\"subtotal_price\":\"0.00\",\"unit_price\":\"0.00\",\"variant_title\":\"Refill large\"}],\"payment_method\":{\"id\":769874,\"billing_address\":{\"address1\":\"90 avenue du Rouergue\",\"address2\":null,\"city\":\"Rodez\",\"company\":null,\"country_code\":\"FR\",\"first_name\":\"Diane\",\"last_name\":\"Albouy\",\"phone\":null,\"province\":null,\"zip\":\"12000\"},\"payment_details\":{}},\"shipping_address\":{\"address1\":\"149 Forest Avenue\",\"address2\":null,\"city\":\"New York City\",\"company\":null,\"country_code\":\"US\",\"first_name\":\"Aria\",\"last_name\":\"Beciu\",\"phone\":\"1234567890\",\"province\":\"New York\",\"zip\":\"10019\"}}]}]}}";
        var request = _fixture.Create<CustomerService.GetCustomerDeliveryScheduleTypes.Request>();
        var response = _fixture.Create<CustomerService.GetCustomerDeliveryScheduleTypes.Response>();
        var apiCallerMock = new Mock<IRechargeApiCaller>(MockBehavior.Strict);
        var customerId = 123;
        var uriToMock = $"/customers/{customerId}/delivery_schedule";
        apiCallerMock.Setup(
                r => r.Get<CustomerService.GetCustomerDeliveryScheduleTypes.Response>(It.Is<string>(uri => uri.StartsWith(uriToMock))))
            .ReturnsAsync(response)
            .Verifiable();
        
        var sut = CreateSut(apiCallerMock.Object);
    
        // Act
        var actualResponse = await sut.GetCustomerDeliverySchedule(customerId, request);

        // Assert
        apiCallerMock.Verify();
        actualResponse.Should().Be(response);
    }

    private static CustomerService CreateSut(IRechargeApiCaller apiCaller)
    {
        var customerServiceLogger = new NullLogger<CustomerService>();
        var sut = new CustomerService(customerServiceLogger, apiCaller);
        return sut;
    }
}
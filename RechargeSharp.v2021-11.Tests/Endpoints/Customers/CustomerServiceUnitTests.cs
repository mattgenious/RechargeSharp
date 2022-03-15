using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RechargeSharp.v2021_11.Endpoints.Customers;
using RechargeSharp.v2021_11.Tests.TestHelpers.AutoFixture;
using RechargeSharp.v2021_11.Utilities;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Endpoints.Customers;

public class CustomerServiceUnitTests
{
    private readonly Fixture _fixture;

    public CustomerServiceUnitTests()
    {
        _fixture = new Fixture();
        _fixture.Customizations.Add(new DateOnlySpecimenBuilder());
    }
    
    [Fact]
    public async Task CanListCustomers()
    {
        // Arrange
        var request = _fixture.Create<CustomerService.ListCustomersTypes.Request>();
        var response = _fixture.Create<CustomerService.ListCustomersTypes.Response>();
        var apiCallerMock = new Mock<IRechargeApiCaller>(MockBehavior.Strict);
        const string uriToMock = "/customers";
        apiCallerMock.Setup(
            r => r.GetAsync<CustomerService.ListCustomersTypes.Response>(It.Is<string>(s => s.StartsWith(uriToMock))))
            .ReturnsAsync(response)
            .Verifiable();
        
        var sut = CreateSut(apiCallerMock.Object);
        
        // Act
        var actualResponse = await sut.ListCustomersAsync(request);

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
        const int customerId = 123;
        var uriToMock = $"/customers/{customerId}";
        apiCallerMock.Setup(
                r => r.GetNullableAsync<CustomerService.GetCustomerTypes.Response>(uriToMock))
            .ReturnsAsync(response)
            .Verifiable();
        
        var sut = CreateSut(apiCallerMock.Object);
    
        // Act
        var actualResponse = await sut.GetCustomerAsync(customerId);

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
        const int customerId = 123;
        var uriToMock = $"/customers/{customerId}";
        apiCallerMock.Setup(
                r => r.PutAsync<CustomerService.UpdateCustomerTypes.Request, CustomerService.UpdateCustomerTypes.Response>(request,uriToMock))
            .ReturnsAsync(response)
            .Verifiable();
        
        var sut = CreateSut(apiCallerMock.Object);
    
        // Act
        var actualResponse = await sut.UpdateCustomerAsync(customerId, request);

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
                r => r.DeleteAsync(uriToMock))
            .Returns(Task.CompletedTask)
            .Verifiable();
        
        var sut = CreateSut(apiCallerMock.Object);
    
        // Act
        await sut.DeleteCustomerAsync(customerId);

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
        var uriToMock = $"/customers";
        apiCallerMock.Setup(
                r => r.PostAsync<CustomerService.CreateCustomerTypes.Request, CustomerService.CreateCustomerTypes.Response>(request,uriToMock))
            .ReturnsAsync(response)
            .Verifiable();
        
        var sut = CreateSut(apiCallerMock.Object);
    
        // Act
        var actualResponse = await sut.CreateCustomerAsync(request);

        // Assert
        apiCallerMock.Verify();
        actualResponse.Should().Be(response);
    }
    
    [Fact]
    public async Task CanGetCustomerDeliverySchedule()
    {
        // Arrange
        var request = _fixture.Create<CustomerService.GetCustomerDeliveryScheduleTypes.Request>();
        var response = _fixture.Create<CustomerService.GetCustomerDeliveryScheduleTypes.Response>();
        var apiCallerMock = new Mock<IRechargeApiCaller>(MockBehavior.Strict);
        const int customerId = 123;
        var uriToMock = $"/customers/{customerId}/delivery_schedule";
        apiCallerMock.Setup(
                r => r.GetAsync<CustomerService.GetCustomerDeliveryScheduleTypes.Response>(It.Is<string>(uri => uri.StartsWith(uriToMock))))
            .ReturnsAsync(response)
            .Verifiable();
        
        var sut = CreateSut(apiCallerMock.Object);
    
        // Act
        var actualResponse = await sut.GetCustomerDeliveryScheduleAsync(customerId, request);

        // Assert
        apiCallerMock.Verify();
        actualResponse.Should().Be(response);
    }

    private static CustomerService CreateSut(IRechargeApiCaller apiCaller)
    {
        var sut = new CustomerService(apiCaller);
        return sut;
    }
}
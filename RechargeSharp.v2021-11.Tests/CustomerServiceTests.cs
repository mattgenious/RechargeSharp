using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using RechargeSharp.v2021_11.Entities.Customers;
using Xunit;

namespace RechargeSharp.v2021_11.Tests;

public class CustomerServiceTests
{
    private const string BaseAddress = "https://api.rechargeapps.com";

    [Fact]
    public async Task CanListCustomers()
    {
        // Arrange
        var jsonReturnedByApi =
            "{\"next_cursor\":\"next_cursor\",\"previous_cursor\":\"previous_cursor\",\"customers\":[{\"id\":37657002,\"analytics_data\":{\"utm_params\":[{\"utm_source\":\"facebook\",\"utm_medium\":\"cpc\"}]},\"created_at\":\"2020-02-19T17:40:07\",\"email\":\"fake@example.com\",\"external_customer_id\":{\"ecommerce\":\"2879413682227\"},\"first_charge_processed_at\":\"2020-02-19T17:40:11\",\"first_name\":\"Jane\",\"has_payment_method_in_dunning\":false,\"has_valid_payment_method\":true,\"hash\":\"7e706455cbd13e40\",\"last_name\":\"Doe\",\"subscriptions_active_count\":0,\"subscriptions_total_count\":1,\"updated_at\":\"2020-12-17T18:50:39\"}]}";
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningOKAndJson(jsonReturnedByApi);

        var sut = CreateSut(httpHandlerMock, BaseAddress);
        var request = new Fixture().Create<CustomerService.ListCustomersTypes.Request>();

        // Act
        var customers = await sut.ListCustomers(request);

        // Assert
        customers.Should().NotBeNull();
        customers.Customers.Should().Contain(c => c.Id == 37657002);
        
        var expectedUri = $"{BaseAddress}/customers";
 
        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get
                    && req.RequestUri!.ToString().StartsWith(expectedUri)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
        
    }
    
    [Fact]
    public async Task CanGetCustomer()
    {
        // Arrange
        var jsonReturnedByApi = "{\"customer\":{\"id\":37657002,\"analytics_data\":{\"utm_params\":[{\"utm_source\":\"facebook\",\"utm_medium\":\"cpc\"}]},\"created_at\":\"2020-02-19T17:40:07\",\"email\":\"fake@example.com\",\"external_customer_id\":{\"ecommerce\":\"2879413682227\"},\"first_charge_processed_at\":\"2020-02-19T17:40:11\",\"first_name\":\"Jane\",\"has_payment_method_in_dunning\":false,\"has_valid_payment_method\":true,\"hash\":\"7e706455cbd13e40\",\"last_name\":\"Doe\",\"subscriptions_active_count\":0,\"subscriptions_total_count\":1,\"updated_at\":\"2020-12-17T18:50:39\"}}";
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningOKAndJson(jsonReturnedByApi);

        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var customer = await sut.GetCustomer(37657002);

        // Assert
        customer.Should().NotBeNull();
        customer.Customer.Id.Should().Be(37657002);
        
        // also check the 'http' call was like we expected it
        var expectedUri = $"{BaseAddress}/customers/37657002";
 
        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Get
                && req.RequestUri!.ToString().StartsWith(expectedUri)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    private static CustomerService CreateSut(IMock<HttpMessageHandler> handlerMock, string baseAddress)
    {
        // use real http client with mocked handler here
        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri(baseAddress),
        };

        var logger = new NullLogger<CustomerService>();
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();

        httpClientFactoryMock.Setup(f => f.CreateClient(string.Empty)).Returns(httpClient);
        var options = Options.Create(new RechargeServiceOptions());
        var sut = new CustomerService(logger, httpClientFactoryMock.Object, options);
        return sut;
    }

    private static Mock<HttpMessageHandler> SetupHttpHandlerMock_ReturningOKAndJson(string mockJsonFromApi)
    {
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            // Setup the PROTECTED method to mock
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            // prepare the expected response of the mocked http call
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(mockJsonFromApi),
            })
            .Verifiable();
        return handlerMock;
    }
}
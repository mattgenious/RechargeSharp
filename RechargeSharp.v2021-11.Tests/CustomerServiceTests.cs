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
        
        var expectedUri = $"{BaseAddress}/customers/37657002";
 
        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Get && 
                req.RequestUri!.ToString().StartsWith(expectedUri)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Fact]
    public async Task CanUpdateCustomer()
    {
        // Arrange
        var jsonReturnedByApi = "{\"customer\":{\"id\":37657002,\"analytics_data\":{\"utm_params\":[{\"utm_source\":\"facebook\",\"utm_medium\":\"cpc\"}]},\"created_at\":\"2020-02-19T17:40:07\",\"email\":\"fake@example.com\",\"external_customer_id\":{\"ecommerce\":\"2879413682227\"},\"first_charge_processed_at\":\"2020-02-19T17:40:11\",\"first_name\":\"Jane\",\"has_payment_method_in_dunning\":false,\"has_valid_payment_method\":true,\"hash\":\"7e706455cbd13e40\",\"last_name\":\"Doe\",\"subscriptions_active_count\":0,\"subscriptions_total_count\":1,\"updated_at\":\"2020-12-17T18:50:39\"}}";
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningOKAndJson(jsonReturnedByApi);

        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        var request = new Fixture().Create<CustomerService.UpdateCustomerTypes.Request>();
        
        // Act
        var updatedCustomer = await sut.UpdateCustomer(37657002, request);

        updatedCustomer.Should().NotBeNull();
        updatedCustomer.Customer.Should().NotBeNull();
        
        var expectedUri = $"{BaseAddress}/customers/{37657002}";
        
        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Put && // Check that the HTTP request method is as expected
                req.Content.Headers.ContentType.MediaType == "application/json" &&
                req.RequestUri!.ToString() == expectedUri
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Fact]
    public async Task CanDeleteCustomer()
    {
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningStatusCode(HttpStatusCode.NoContent);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        // Act
        var act = new Action(() => sut.DeleteCustomer(37657002));
        act.Should().NotThrow();
        
        var expectedUri = $"{BaseAddress}/customers/{37657002}";
        
        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Delete && 
                req.RequestUri!.ToString() == expectedUri
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }    
    
    [Fact]
    public async Task CanCreateCustomer()
    {
        // Arrange
        var jsonReturnedByApi = "{\"customer\":{\"id\":37657002,\"analytics_data\":{\"utm_params\":[{\"utm_source\":\"facebook\",\"utm_medium\":\"cpc\"}]},\"created_at\":\"2020-02-19T17:40:07\",\"email\":\"fake@example.com\",\"external_customer_id\":{\"ecommerce\":\"2879413682227\"},\"first_charge_processed_at\":\"2020-02-19T17:40:11\",\"first_name\":\"Jane\",\"has_payment_method_in_dunning\":false,\"has_valid_payment_method\":true,\"hash\":\"7e706455cbd13e40\",\"last_name\":\"Doe\",\"subscriptions_active_count\":0,\"subscriptions_total_count\":1,\"updated_at\":\"2020-12-17T18:50:39\"}}";
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningOKAndJson(jsonReturnedByApi);

        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        var request = new Fixture().Create<CustomerService.CreateCustomerTypes.Request>();
        
        // Act
        var createdCustomer = await sut.CreateCustomer(request);

        createdCustomer.Should().NotBeNull();
        createdCustomer.Customer.Should().NotBeNull();
        createdCustomer.Customer.Id.Should().Be(37657002);
        
        var expectedUri = $"{BaseAddress}/customers";
        
        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Post && 
                req.RequestUri!.ToString() == expectedUri &&
                req.Content.Headers.ContentType.MediaType == "application/json"
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Fact]
    public async Task CanGetCustomerDeliverySchedule()
    {
        // Arrange
        var jsonReturnedByApi = "{\"deliverySchedule\":{\"customer\":{\"id\":73720164,\"email\":\"test@example.com\",\"first_name\":\"Aria\",\"last_name\":\"Beciu\"},\"deliveries\":[{\"date\":\"2022-02-07\",\"orders\":[{\"id\":null,\"address_id\":79342717,\"charge_id\":507503288,\"line_items\":[{\"subscription_id\":186930285,\"external_product_id\":{\"ecommerce\":null},\"external_variant_id\":{\"ecommerce\":null},\"images\":{},\"is_skippable\":false,\"plan_type\":null,\"product_title\":\"Organic coffee beans\",\"properties\":[],\"quantity\":1,\"subtotal_price\":\"0.00\",\"unit_price\":\"0.00\",\"variant_title\":\"Refill large\"}],\"payment_method\":{\"id\":769874,\"billing_address\":{\"address1\":\"90 avenue du Rouergue\",\"address2\":null,\"city\":\"Rodez\",\"company\":null,\"country_code\":\"FR\",\"first_name\":\"Diane\",\"last_name\":\"Albouy\",\"phone\":null,\"province\":null,\"zip\":\"12000\"},\"payment_details\":{}},\"shipping_address\":{\"address1\":\"149 Forest Avenue\",\"address2\":null,\"city\":\"New York City\",\"company\":null,\"country_code\":\"US\",\"first_name\":\"Aria\",\"last_name\":\"Beciu\",\"phone\":\"1234567890\",\"province\":\"New York\",\"zip\":\"10019\"}}]}]}}";
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningOKAndJson(jsonReturnedByApi);
        
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        var request = new Fixture().Create<CustomerService.GetCustomerDeliveryScheduleTypes.Request>();
        
        // Act
        var deliverySchedule = await sut.GetCustomerDeliverySchedule(73720164, request);
        
        deliverySchedule.Should().NotBeNull();
        deliverySchedule.DeliverySchedule.Customer.Id.Should().Be(73720164);
        
        var expectedUri = $"{BaseAddress}/customers/{73720164}/delivery_schedule";
        
        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Get && 
                req.RequestUri!.ToString().StartsWith(expectedUri)
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
        return CreateHttpMessageHandlerThatReturns(new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(mockJsonFromApi),
        });
    }
    
    private static Mock<HttpMessageHandler> SetupHttpHandlerMock_ReturningStatusCode(HttpStatusCode statusCodeToReturn)
    {
        return CreateHttpMessageHandlerThatReturns(new HttpResponseMessage()
        {
            StatusCode = statusCodeToReturn,
        });
    }
    
    private static Mock<HttpMessageHandler> CreateHttpMessageHandlerThatReturns(HttpResponseMessage httpResponseMessage)
    {
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(httpResponseMessage)
            .Verifiable();
        return handlerMock;
    }
}
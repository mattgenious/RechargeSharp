using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using FluentAssertions.Primitives;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Polly;
using RechargeSharp.v2021_11.Entities.Customers;
using RechargeSharp.v2021_11.Tests.TestHelpers;
using RechargeSharp.v2021_11.Utilities;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Entities.Customers;

public class CustomerServiceIntegrationTests
{
    /// <summary>
    ///     Tests that the service behaves as expected when the Recharge API returns certain HTTP responses
    /// </summary>
    [Theory]
    [MemberData(nameof(RechargeApiHttpResponseTestCases))]
    public async Task CustomerServiceReturnsExpectedOutputWhenRechargeApiRespondsWithCertainHttpContent<T>(string mockJsonFromApi, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<CustomerService, Task<T>> apiCallerFunc, Func<T, ObjectAssertions> assertionsFactory)
    {
        // Arrange
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(mockJsonFromApi, httpStatusCode, uriToMatch, method);
        var apiCaller = CreateRechargeApiCallerWithMockedHttpHandler(handlerMock);
        
        var nullLogger = new NullLogger<CustomerService>();
        var sut = new CustomerService(nullLogger, apiCaller);
        
        // Act
        var result = await apiCallerFunc(sut);
        
        // Assert
        assertionsFactory(result);
    }
    
    public static IEnumerable<object[]> RechargeApiHttpResponseTestCases()
    {
        var fixture = new Fixture();
        
        yield return new object[]
        {
            // List customers
            "{\"next_cursor\":\"next_cursor\",\"previous_cursor\":\"previous_cursor\",\"customers\":[{\"id\":37657002,\"analytics_data\":{\"utm_params\":[{\"utm_source\":\"facebook\",\"utm_medium\":\"cpc\"}]},\"created_at\":\"2020-02-19T17:40:07\",\"email\":\"fake@example.com\",\"external_customer_id\":{\"ecommerce\":\"2879413682227\"},\"first_charge_processed_at\":\"2020-02-19T17:40:11\",\"first_name\":\"Jane\",\"has_payment_method_in_dunning\":false,\"has_valid_payment_method\":true,\"hash\":\"7e706455cbd13e40\",\"last_name\":\"Doe\",\"subscriptions_active_count\":0,\"subscriptions_total_count\":1,\"updated_at\":\"2020-12-17T18:50:39\"}]}",
            HttpStatusCode.OK,
            "/customers",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.ListCustomersTypes.Response>>(service => service.ListCustomers(fixture.Create<CustomerService.ListCustomersTypes.Request>())),
            new Func<CustomerService.ListCustomersTypes.Response, ObjectAssertions>(response => response.Customers.Should().Contain(c => c.Id == 37657002).Should())
        };
        
        yield return new object[]
        {
            // Get customer
            "{\"customer\":{\"id\":37657002,\"analytics_data\":{\"utm_params\":[{\"utm_source\":\"facebook\",\"utm_medium\":\"cpc\"}]},\"created_at\":\"2020-02-19T17:40:07\",\"email\":\"fake@example.com\",\"external_customer_id\":{\"ecommerce\":\"2879413682227\"},\"first_charge_processed_at\":\"2020-02-19T17:40:11\",\"first_name\":\"Jane\",\"has_payment_method_in_dunning\":false,\"has_valid_payment_method\":true,\"hash\":\"7e706455cbd13e40\",\"last_name\":\"Doe\",\"subscriptions_active_count\":0,\"subscriptions_total_count\":1,\"updated_at\":\"2020-12-17T18:50:39\"}}",
            HttpStatusCode.OK,
            $"/customers/{37657002}",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.GetCustomerTypes.Response>>(service => service.GetCustomer(37657002)),
            new Func<CustomerService.GetCustomerTypes.Response, ObjectAssertions>(response => response.Customer.Id.Should().Be(37657002).Should())
        };
        
        yield return new object[]
        {
            // Update customer
            "{\"customer\":{\"id\":37657002,\"analytics_data\":{\"utm_params\":[{\"utm_source\":\"facebook\",\"utm_medium\":\"cpc\"}]},\"created_at\":\"2020-02-19T17:40:07\",\"email\":\"fake@example.com\",\"external_customer_id\":{\"ecommerce\":\"2879413682227\"},\"first_charge_processed_at\":\"2020-02-19T17:40:11\",\"first_name\":\"Jane\",\"has_payment_method_in_dunning\":false,\"has_valid_payment_method\":true,\"hash\":\"7e706455cbd13e40\",\"last_name\":\"Doe\",\"subscriptions_active_count\":0,\"subscriptions_total_count\":1,\"updated_at\":\"2020-12-17T18:50:39\"}}",
            HttpStatusCode.OK,
            $"/customers/{37657002}",
            HttpMethod.Put,
            new Func<CustomerService, Task<CustomerService.UpdateCustomerTypes.Response>>(service => service.UpdateCustomer(37657002, fixture.Create<CustomerService.UpdateCustomerTypes.Request>())),
            new Func<CustomerService.UpdateCustomerTypes.Response, ObjectAssertions>(response => response.Customer.Id.Should().Be(37657002).Should())
        };
        
        yield return new object[]
        {
            // Delete customer
            "",
            HttpStatusCode.NoContent,
            $"/customers/{37657002}",
            HttpMethod.Delete,
            new Func<CustomerService, Task<CustomerService.DeleteCustomerTypes.Response>>(service => service.DeleteCustomer(37657002)),
            new Func<CustomerService.DeleteCustomerTypes.Response, ObjectAssertions>(response => response.Should().NotBeNull().Should())
        };
        
        yield return new object[]
        {
            // Create customer
            "{\"customer\":{\"id\":37657002,\"analytics_data\":{\"utm_params\":[{\"utm_source\":\"facebook\",\"utm_medium\":\"cpc\"}]},\"created_at\":\"2020-02-19T17:40:07\",\"email\":\"fake@example.com\",\"external_customer_id\":{\"ecommerce\":\"2879413682227\"},\"first_charge_processed_at\":\"2020-02-19T17:40:11\",\"first_name\":\"Jane\",\"has_payment_method_in_dunning\":false,\"has_valid_payment_method\":true,\"hash\":\"7e706455cbd13e40\",\"last_name\":\"Doe\",\"subscriptions_active_count\":0,\"subscriptions_total_count\":1,\"updated_at\":\"2020-12-17T18:50:39\"}}",
            HttpStatusCode.OK,
            $"/customers",
            HttpMethod.Post,
            new Func<CustomerService, Task<CustomerService.CreateCustomerTypes.Response>>(service => service.CreateCustomer(fixture.Create<CustomerService.CreateCustomerTypes.Request>())),
            new Func<CustomerService.CreateCustomerTypes.Response, ObjectAssertions>(response => response.Customer.Id.Should().Be(37657002).Should())
        };
        
        yield return new object[]
        {
            // Get customer delivery schedule
            "{\"customer\":{\"id\":1234,\"email\":\"some@email.com\",\"first_name\":\"Some\",\"last_name\":\"Body\"},\"deliveries\":[{\"date\":\"2022-03-31\",\"orders\":[{\"id\":null,\"address_id\":123123,\"charge_id\":55555,\"line_items\":[{\"subscription_id\":4565464,\"external_product_id\":{\"ecommerce\":null},\"external_variant_id\":{\"ecommerce\":null},\"images\":{},\"is_skippable\":false,\"plan_type\":null,\"product_title\":\"Test product\",\"properties\":[{\"name\":\"gram per dag\",\"value\":\"328\"}],\"quantity\":2,\"subtotal_price\":\"0.00\",\"unit_price\":\"0.00\",\"variant_title\":\"571\"}],\"payment_method\":{\"id\":123123,\"billing_address\":{\"address1\":\"Somestreet 31\",\"address2\":null,\"city\":\"København\",\"company\":null,\"country_code\":\"DK\",\"first_name\":\"Some\",\"last_name\":\"Body\",\"phone\":\"12312313\",\"province\":null,\"zip\":\"1100\"},\"payment_details\":{}},\"shipping_address\":{\"address1\":\"Somestreet 31\",\"address2\":null,\"city\":\"København\",\"company\":null,\"country_code\":\"DK\",\"first_name\":\"Some\",\"last_name\":\"Body\",\"phone\":\"12312313\",\"province\":null,\"zip\":\"1100\"}}]},{\"date\":\"2022-04-30\",\"orders\":[{\"id\":null,\"address_id\":123123,\"charge_id\":null,\"line_items\":[],\"payment_method\":{\"id\":51776002,\"billing_address\":{\"address1\":\"Somestreet 31\",\"address2\":null,\"city\":\"København\",\"company\":null,\"country_code\":\"DK\",\"first_name\":\"Some\",\"last_name\":\"Body\",\"phone\":\"12312313\",\"province\":null,\"zip\":\"1100\"},\"payment_details\":{}},\"shipping_address\":{\"address1\":null,\"address2\":null,\"city\":null,\"company\":null,\"country_code\":null,\"first_name\":null,\"last_name\":null,\"phone\":null,\"province\":null,\"zip\":null}}]},{\"date\":\"2022-05-30\",\"orders\":[{\"id\":null,\"address_id\":123123,\"charge_id\":null,\"line_items\":[],\"payment_method\":{\"id\":123123,\"billing_address\":{\"address1\":\"Somestreet 31\",\"address2\":null,\"city\":\"København\",\"company\":null,\"country_code\":\"DK\",\"first_name\":\"Some\",\"last_name\":\"Body\",\"phone\":\"12312313\",\"province\":null,\"zip\":\"1100\"},\"payment_details\":{}},\"shipping_address\":{\"address1\":null,\"address2\":null,\"city\":null,\"company\":null,\"country_code\":null,\"first_name\":null,\"last_name\":null,\"phone\":null,\"province\":null,\"zip\":null}}]}]}",
            HttpStatusCode.OK,
            $"/customers/{1234}/delivery_schedule",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.GetCustomerDeliveryScheduleTypes.Response>>(service => service.GetCustomerDeliverySchedule(1234,fixture.Create<CustomerService.GetCustomerDeliveryScheduleTypes.Request>())),
            new Func<CustomerService.GetCustomerDeliveryScheduleTypes.Response, ObjectAssertions>(response => response.Customer.Id.Should().Be(1234).Should())
        };
    }
    
    private static RechargeApiCaller CreateRechargeApiCallerWithMockedHttpHandler(IMock<HttpMessageHandler> handlerMock, IAsyncPolicy? policy = null)
    {
        // use real http client with mocked handler here
        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://api.rechargeapps.com"),
        };

        var logger = new NullLogger<RechargeApiCaller>();
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();

        httpClientFactoryMock.Setup(f => f.CreateClient(string.Empty)).Returns(httpClient);

        var rechargeApiCallerOptions = new RechargeApiCallerOptions();
        if (policy != null)
            rechargeApiCallerOptions.ApiCallPolicy = policy;
        var sut = new RechargeApiCaller(httpClientFactoryMock.Object, logger, rechargeApiCallerOptions);
        return sut;
    }
}
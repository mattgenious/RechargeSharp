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
using Polly.NoOp;
using RechargeSharp.v2021_11.Entities.Customers;
using RechargeSharp.v2021_11.Exceptions;
using RechargeSharp.v2021_11.Tests.TestHelpers;
using RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Customers;
using RechargeSharp.v2021_11.Utilities;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Entities.Customers;

public class CustomerServiceIntegrationTests
{
    /// <summary>
    ///     Tests that the service behaves as expected when the Recharge API returns certain successful HTTP responses
    /// </summary>
    [Theory]
    [MemberData(nameof(RechargeApiHttpResponseSuccessTestCases))]
    public async Task TestingSuccessResponseCodes<T>(string sampleResponseJsonFile, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<CustomerService, Task<T>> apiCallerFunc, T? expectedDeserializedResponse)
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson(sampleResponseJsonFile);
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, httpStatusCode, uriToMatch, method);
        var apiCaller = CreateRechargeApiCallerWithMockedHttpHandler(handlerMock);
        
        var nullLogger = new NullLogger<CustomerService>();
        var sut = new CustomerService(nullLogger, apiCaller);
        
        // Act
        var result = await apiCallerFunc(sut);
        
        // Assert
        if(expectedDeserializedResponse != null)
            result.Should().BeEquivalentTo(expectedDeserializedResponse);
    }
    
    public static IEnumerable<object[]> RechargeApiHttpResponseSuccessTestCases()
    {
        var fixture = new Fixture();
        
        yield return new object[]
        {
            // List customers
            "Customers/list-customers_200.json",
            HttpStatusCode.OK,
            "/customers",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.ListCustomersTypes.Response>>(service => service.ListCustomers(fixture.Create<CustomerService.ListCustomersTypes.Request>())),
            list_customers_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get customer
            "Customers/get-customer_200.json",
            HttpStatusCode.OK,
            $"/customers/{82940007}",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.GetCustomerTypes.Response>>(service => service.GetCustomer(82940007)),
            get_customer_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Update customer
            "Customers/update-customer_200.json",
            HttpStatusCode.OK,
            $"/customers/{82940507}",
            HttpMethod.Put,
            new Func<CustomerService, Task<CustomerService.UpdateCustomerTypes.Response>>(service => service.UpdateCustomer(82940507, fixture.Create<CustomerService.UpdateCustomerTypes.Request>())),
            update_customer_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Delete customer
            "Customers/delete-customer_204.json",
            HttpStatusCode.NoContent,
            $"/customers/{37657002}",
            HttpMethod.Delete,
            new Func<CustomerService, Task<CustomerService.DeleteCustomerTypes.Response>>(service => service.DeleteCustomer(37657002)),
            (CustomerService.DeleteCustomerTypes.Response?) null
        };
        
        yield return new object[]
        {
            // Create customer
            "Customers/create-customer_201.json",
            HttpStatusCode.OK,
            $"/customers",
            HttpMethod.Post,
            new Func<CustomerService, Task<CustomerService.CreateCustomerTypes.Response>>(service => service.CreateCustomer(fixture.Create<CustomerService.CreateCustomerTypes.Request>())),
            create_customer_201.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get customer delivery schedule - customer has a schedule
            "Customers/get-customer-delivery-schedules_200_customer-has-a-schedule.json",
            HttpStatusCode.OK,
            $"/customers/{100000}/delivery_schedule",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.GetCustomerDeliveryScheduleTypes.Response>>(service => service.GetCustomerDeliverySchedule(100000,fixture.Create<CustomerService.GetCustomerDeliveryScheduleTypes.Request>())),
            get_customer_delivery_schedules_200_customer_has_a_schedule.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get customer delivery schedule - customer does not have a schedule
            "Customers/get-customer-delivery-schedules_200_customer-without-deliveries.json",
            HttpStatusCode.OK,
            $"/customers/{82940823}/delivery_schedule",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.GetCustomerDeliveryScheduleTypes.Response>>(service => service.GetCustomerDeliverySchedule(82940823,fixture.Create<CustomerService.GetCustomerDeliveryScheduleTypes.Request>())),
            get_customer_delivery_schedules_200_customer_without_deliveries.CorrectlyDeserializedJson()
        };
    }
    
    /// <summary>
    ///     Tests that the service behaves as expected when the Recharge API returns certain successful HTTP responses
    /// </summary>
    [Theory]
    [MemberData(nameof(RechargeApiHttpResponseErrorTestCases))]
    public async Task TestingErrorResponseCodes<T>(string sampleResponseJsonFile, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<CustomerService, Task<T>> apiCallerFunc, Type expectedExceptionType)
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson(sampleResponseJsonFile);
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, httpStatusCode, uriToMatch, method);
        var apiCaller = CreateRechargeApiCallerWithMockedHttpHandler(handlerMock, Policy.NoOpAsync());
        
        var nullLogger = new NullLogger<CustomerService>();
        var sut = new CustomerService(nullLogger, apiCaller);
        
        // Act
        Func<Task> act = async () => { await apiCallerFunc(sut); };
        
        // Assert
        var exceptionShouldBeThrown = await act.Should().ThrowAsync<RechargeApiException>();
        var thrownException = exceptionShouldBeThrown.Which;
        thrownException.Should().BeOfType(expectedExceptionType);
        thrownException.ErrorDataJson.Should().NotBeNull();
        thrownException.ErrorDataJson.Errors.Should().NotBeNull();
    }
    
    public static IEnumerable<object[]> RechargeApiHttpResponseErrorTestCases()
    {
        var fixture = new Fixture();
        
        yield return new object[]
        {
            // Create customer - with duplicate email
            "Customers/create-customer_422_email-already-taken.json",
            HttpStatusCode.UnprocessableEntity,
            "/customers",
            HttpMethod.Post,
            new Func<CustomerService, Task<CustomerService.CreateCustomerTypes.Response>>(service => service.CreateCustomer(fixture.Create<CustomerService.CreateCustomerTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Delete customer - no customer with that ID
            "Customers/delete-customer_404_no-customer-with-id.json",
            HttpStatusCode.NotFound,
            "/customers/111111",
            HttpMethod.Delete,
            new Func<CustomerService, Task<CustomerService.DeleteCustomerTypes.Response>>(service => service.DeleteCustomer(111111)),
            typeof(NotFoundException)
        };
        
        yield return new object[]
        {
            // Get customer deliveries - no customer with that ID
            "Customers/get-customer-delivery-schedules_404_no-customer-with-id.json",
            HttpStatusCode.NotFound,
            $"/customers/111111/delivery_schedule",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.GetCustomerDeliveryScheduleTypes.Response>>(service => service.GetCustomerDeliverySchedule(111111, fixture.Create<CustomerService.GetCustomerDeliveryScheduleTypes.Request>())),
            typeof(NotFoundException)
        };
        
        yield return new object[]
        {
            // Get customer - no customer with that ID
            "Customers/get-customer_404_no-customer-with-id.json",
            HttpStatusCode.NotFound,
            "/customers/111111",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.GetCustomerTypes.Response>>(service => service.GetCustomer(111111)),
            typeof(NotFoundException)
        };
        
        yield return new object[]
        {
            // List customers - invalid cursor
            "Customers/list-customers_422_invalid-cursor.json",
            HttpStatusCode.UnprocessableEntity,
            "/customers",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.ListCustomersTypes.Response>>(service => service.ListCustomers(fixture.Create<CustomerService.ListCustomersTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Update customer - empty first and last name
            "Customers/update-customer_422_bad-input.json",
            HttpStatusCode.UnprocessableEntity,
            "/customers/111111",
            HttpMethod.Put,
            new Func<CustomerService, Task<CustomerService.UpdateCustomerTypes.Response>>(service => service.UpdateCustomer(111111, fixture.Create<CustomerService.UpdateCustomerTypes.Request>())),
            typeof(UnprocessableEntityException)
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
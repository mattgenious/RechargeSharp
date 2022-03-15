using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Polly;
using RechargeSharp.v2021_11.Endpoints.Customers;
using RechargeSharp.v2021_11.Exceptions;
using RechargeSharp.v2021_11.Tests.TestHelpers;
using RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Customers;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Endpoints.Customers;

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
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock, Policy.NoOpAsync());
        
        var sut = new CustomerService(apiCaller);
        
        // Act
        var result = await apiCallerFunc(sut);
        
        // Assert
        if (expectedDeserializedResponse != null)
            result.Should().BeEquivalentTo(expectedDeserializedResponse);
        else
            result.Should().BeNull();
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
            new Func<CustomerService, Task<CustomerService.ListCustomersTypes.Response>>(service => service.ListCustomersAsync(fixture.Create<CustomerService.ListCustomersTypes.Request>())),
            list_customers_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get customer
            "Customers/get-customer_200.json",
            HttpStatusCode.OK,
            $"/customers/{82940007}",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.GetCustomerTypes.Response?>>(service => service.GetCustomerAsync(82940007)),
            get_customer_200.CorrectlyDeserializedJson()
        };
        
        
        yield return new object[]
        {
            // Get customer - no customer with that ID
            "Customers/get-customer_404_no-customer-with-id.json",
            HttpStatusCode.NotFound,
            "/customers/111111",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.GetCustomerTypes.Response?>>(service => service.GetCustomerAsync(111111)),
            (CustomerService.GetCustomerTypes.Response?) null
        };
        
        yield return new object[]
        {
            // Update customer
            "Customers/update-customer_200.json",
            HttpStatusCode.OK,
            $"/customers/{82940507}",
            HttpMethod.Put,
            new Func<CustomerService, Task<CustomerService.UpdateCustomerTypes.Response>>(service => service.UpdateCustomerAsync(82940507, fixture.Create<CustomerService.UpdateCustomerTypes.Request>())),
            update_customer_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Create customer
            "Customers/create-customer_201.json",
            HttpStatusCode.Created,
            $"/customers",
            HttpMethod.Post,
            new Func<CustomerService, Task<CustomerService.CreateCustomerTypes.Response>>(service => service.CreateCustomerAsync(fixture.Create<CustomerService.CreateCustomerTypes.Request>())),
            create_customer_201.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get customer delivery schedule - customer has a schedule
            "Customers/get-customer-delivery-schedules_200_customer-has-a-schedule.json",
            HttpStatusCode.OK,
            $"/customers/{100000}/delivery_schedule",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.GetCustomerDeliveryScheduleTypes.Response>>(service => service.GetCustomerDeliveryScheduleAsync(100000,fixture.Create<CustomerService.GetCustomerDeliveryScheduleTypes.Request>())),
            get_customer_delivery_schedules_200_customer_has_a_schedule.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get customer delivery schedule - customer does not have a schedule
            "Customers/get-customer-delivery-schedules_200_customer-without-deliveries.json",
            HttpStatusCode.OK,
            $"/customers/{82940823}/delivery_schedule",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.GetCustomerDeliveryScheduleTypes.Response>>(service => service.GetCustomerDeliveryScheduleAsync(82940823,fixture.Create<CustomerService.GetCustomerDeliveryScheduleTypes.Request>())),
            get_customer_delivery_schedules_200_customer_without_deliveries.CorrectlyDeserializedJson()
        };
    }
    
    /// <summary>
    ///     Testing that deletion works as intended
    /// </summary>
    [Fact]
    public async Task TestingDeletion()
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson("Customers/delete-customer_204.json");
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, HttpStatusCode.NoContent, $"/customers/{37657002}", HttpMethod.Delete);
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock, Policy.NoOpAsync());
        
        var sut = new CustomerService(apiCaller);
        
        // Act
        var act = async () => await sut.DeleteCustomerAsync(37657002);
        
        // Assert
        await act.Should().NotThrowAsync();
    }
    
    /// <summary>
    ///     Tests that the service behaves as expected when the Recharge API returns certain successful HTTP responses
    /// </summary>
    [Theory]
    [MemberData(nameof(RechargeApiHttpResponseErrorTestCases))]
    public async Task TestingErrorResponseCodes(string sampleResponseJsonFile, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<CustomerService, Task> apiCallerFunc, Type expectedExceptionType)
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson(sampleResponseJsonFile);
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, httpStatusCode, uriToMatch, method);
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock, Policy.NoOpAsync());
        
        var sut = new CustomerService(apiCaller);
        
        // Act
        Func<Task> act = async () => { await apiCallerFunc(sut); };
        
        // Assert
        var exceptionShouldBeThrown = await act.Should().ThrowAsync<RechargeApiException>();
        var thrownException = exceptionShouldBeThrown.Which;
        thrownException.Should().BeOfType(expectedExceptionType);
        thrownException.ErrorDataJson.Should().NotBeNull();
        thrownException.ErrorDataJson!.Errors.Should().NotBeNull();
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
            new Func<CustomerService, Task<CustomerService.CreateCustomerTypes.Response>>(service => service.CreateCustomerAsync(fixture.Create<CustomerService.CreateCustomerTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Delete customer - no customer with that ID
            "Customers/delete-customer_404_no-customer-with-id.json",
            HttpStatusCode.NotFound,
            "/customers/111111",
            HttpMethod.Delete,
            new Func<CustomerService, Task>(service => service.DeleteCustomerAsync(111111)),
            typeof(NotFoundException)
        };
        
        yield return new object[]
        {
            // Get customer deliveries - no customer with that ID
            "Customers/get-customer-delivery-schedules_404_no-customer-with-id.json",
            HttpStatusCode.NotFound,
            $"/customers/111111/delivery_schedule",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.GetCustomerDeliveryScheduleTypes.Response>>(service => service.GetCustomerDeliveryScheduleAsync(111111, fixture.Create<CustomerService.GetCustomerDeliveryScheduleTypes.Request>())),
            typeof(NotFoundException)
        };
        
        yield return new object[]
        {
            // List customers - invalid cursor
            "Customers/list-customers_422_invalid-cursor.json",
            HttpStatusCode.UnprocessableEntity,
            "/customers",
            HttpMethod.Get,
            new Func<CustomerService, Task<CustomerService.ListCustomersTypes.Response>>(service => service.ListCustomersAsync(fixture.Create<CustomerService.ListCustomersTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Update customer - empty first and last name
            "Customers/update-customer_422_bad-input.json",
            HttpStatusCode.UnprocessableEntity,
            "/customers/111111",
            HttpMethod.Put,
            new Func<CustomerService, Task<CustomerService.UpdateCustomerTypes.Response>>(service => service.UpdateCustomerAsync(111111, fixture.Create<CustomerService.UpdateCustomerTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
    }
}
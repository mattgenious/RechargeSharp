using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Polly;
using RechargeSharp.v2021_11.Endpoints.Subscriptions;
using RechargeSharp.v2021_11.Exceptions;
using RechargeSharp.v2021_11.Tests.TestHelpers;
using RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Subscriptions;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Endpoints.Subscriptions;

public class SubscriptionsServiceIntegrationTests
{
    /// <summary>
    ///     Tests that the service behaves as expected when the Recharge API returns certain successful HTTP responses
    /// </summary>
    [Theory]
    [MemberData(nameof(RechargeApiHttpResponseSuccessTestCases))]
    public async Task TestingSuccessResponseCodes<T>(string sampleResponseJsonFile, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<SubscriptionService, Task<T>> apiCallerFunc, T? expectedDeserializedResponse)
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson(sampleResponseJsonFile);
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, httpStatusCode, uriToMatch, method);
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock);
        
        var nullLogger = new NullLogger<SubscriptionService>();
        var sut = new SubscriptionService(nullLogger, apiCaller);
        
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
            // Create subscription
            "Subscriptions/create-subscription_201.json",
            HttpStatusCode.Created,
            "/subscriptions",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.CreateSubscriptionTypes.Response>>(service => service.CreateSubscription(fixture.Create<SubscriptionService.CreateSubscriptionTypes.Request>())),
            create_subscription_201.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get subscription
            "Subscriptions/get-subscription_200.json",
            HttpStatusCode.OK,
            "/subscriptions",
            HttpMethod.Get,
            new Func<SubscriptionService, Task<SubscriptionService.GetSubscriptionTypes.Response>>(service => service.GetSubscription(1)),
            get_subscription_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Update subscription
            "Subscriptions/update-subscription_200.json",
            HttpStatusCode.OK,
            "/subscriptions/1",
            HttpMethod.Put,
            new Func<SubscriptionService, Task<SubscriptionService.UpdateSubscriptionTypes.Response>>(service => service.UpdateSubscription(1, fixture.Create<SubscriptionService.UpdateSubscriptionTypes.Request>())),
            update_subscription_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Delete subscription
            "Subscriptions/delete-subscription_204.json",
            HttpStatusCode.NoContent,
            "/subscriptions/1",
            HttpMethod.Delete,
            new Func<SubscriptionService, Task<SubscriptionService.DeleteSubscriptionTypes.Response>>(service => service.DeleteSubscription(1)),
            (SubscriptionService.DeleteSubscriptionTypes.Response?) null
        };
        
        yield return new object[]
        {
            // List subscriptions
            "Subscriptions/list-subscriptions_200.json",
            HttpStatusCode.OK,
            "/subscriptions",
            HttpMethod.Get,
            new Func<SubscriptionService, Task<SubscriptionService.ListSubscriptionsTypes.Response>>(service => service.ListSubscriptions(fixture.Create<SubscriptionService.ListSubscriptionsTypes.Request>())),
            list_subscriptions_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Change a subscription next charge date
            "Subscriptions/change-a-subscription-next-charge-date_200.json",
            HttpStatusCode.OK,
            "/subscriptions/1/set_next_charge_date",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.ChangeSubscriptionsNextChargeDateTypes.Response>>(service => service.ChangeSubscriptionsNextChargeDate(1, new SubscriptionService.ChangeSubscriptionsNextChargeDateTypes.Request(new DateOnly(2022, 03, 01)))),
            change_a_subscription_next_charge_date_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Change a subscription address
            "Subscriptions/change-a-subscription-address_200.json",
            HttpStatusCode.OK,
            "/subscriptions/1/change_address",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.ChangeSubscriptionsAddressTypes.Response>>(service => service.ChangeSubscriptionsAddress(1, new SubscriptionService.ChangeSubscriptionsAddressTypes.Request(1, new DateOnly(2022, 03, 01)))),
            change_a_subscription_address_200.CorrectlyDeserializedJson()
        };
    }
    
    /// <summary>
    ///     Tests that the service behaves as expected when the Recharge API returns certain successful HTTP responses
    /// </summary>
    [Theory]
    [MemberData(nameof(RechargeApiHttpResponseErrorTestCases))]
    public async Task TestingErrorResponseCodes<T>(string sampleResponseJsonFile, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<SubscriptionService, Task<T>> apiCallerFunc, Type expectedExceptionType)
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson(sampleResponseJsonFile);
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, httpStatusCode, uriToMatch, method);
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock, Policy.NoOpAsync());
        
        var nullLogger = new NullLogger<SubscriptionService>();
        var sut = new SubscriptionService(nullLogger, apiCaller);
        
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
            // Create subscription - next charge schedule was set to be in the past
            "Subscriptions/create-subscription_422_next-charge-schedule-was-in-the-past.json",
            HttpStatusCode.UnprocessableEntity,
            "/subscriptions",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.CreateSubscriptionTypes.Response>>(service => service.CreateSubscription(fixture.Create<SubscriptionService.CreateSubscriptionTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Get subscription - no subscription with the given ID
            "Subscriptions/get-subscription_404_no-subscription-with-the-given-id.json",
            HttpStatusCode.NotFound,
            "/subscriptions/1",
            HttpMethod.Get,
            new Func<SubscriptionService, Task<SubscriptionService.GetSubscriptionTypes.Response>>(service => service.GetSubscription(1)),
            typeof(NotFoundException)
        };
        
        yield return new object[]
        {
            // Update subscription - missing required fields
            "Subscriptions/update-subscription_422_missing-required-properties.json",
            HttpStatusCode.UnprocessableEntity,
            "/subscriptions/1",
            HttpMethod.Put,
            new Func<SubscriptionService, Task<SubscriptionService.UpdateSubscriptionTypes.Response>>(service => service.UpdateSubscription(1, fixture.Create<SubscriptionService.UpdateSubscriptionTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Change a subscription next charge date - date set to sometime in the past
            "Subscriptions/change-a-subscription-next-charge-date_422_date-set-to-the-past.json",
            HttpStatusCode.UnprocessableEntity,
            "/subscriptions/1/set_next_charge_date",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.ChangeSubscriptionsNextChargeDateTypes.Response>>(service => service.ChangeSubscriptionsNextChargeDate(1,  new SubscriptionService.ChangeSubscriptionsNextChargeDateTypes.Request(new DateOnly(2022, 03, 01)))),
            typeof(UnprocessableEntityException)
        };
    }
}
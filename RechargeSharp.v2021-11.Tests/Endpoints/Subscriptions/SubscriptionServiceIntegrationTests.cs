using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Polly;
using RechargeSharp.v2021_11.Endpoints.Subscriptions;
using RechargeSharp.v2021_11.Exceptions;
using RechargeSharp.v2021_11.Tests.TestHelpers;
using RechargeSharp.v2021_11.Tests.TestHelpers.AutoFixture;
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
        
        var sut = new SubscriptionService(apiCaller);
        
        // Act
        var result = await apiCallerFunc(sut);
        
        // Assert
        if(expectedDeserializedResponse != null)
            result.Should().BeEquivalentTo(expectedDeserializedResponse);
    }
    
    public static IEnumerable<object[]> RechargeApiHttpResponseSuccessTestCases()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(new DateOnlySpecimenBuilder());
        
        yield return new object[]
        {
            // Create subscription
            "Subscriptions/create-subscription_201.json",
            HttpStatusCode.Created,
            "/subscriptions",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.CreateSubscriptionTypes.Response>>(service => service.CreateSubscriptionAsync(fixture.Create<SubscriptionService.CreateSubscriptionTypes.Request>())),
            create_subscription_201.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get subscription
            "Subscriptions/get-subscription_200.json",
            HttpStatusCode.OK,
            "/subscriptions",
            HttpMethod.Get,
            new Func<SubscriptionService, Task<SubscriptionService.GetSubscriptionTypes.Response?>>(service => service.GetSubscriptionAsync(1)),
            get_subscription_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get subscription - no subscription with the given ID
            "Subscriptions/get-subscription_404_no-subscription-with-the-given-id.json",
            HttpStatusCode.NotFound,
            "/subscriptions/1",
            HttpMethod.Get,
            new Func<SubscriptionService, Task<SubscriptionService.GetSubscriptionTypes.Response?>>(service => service.GetSubscriptionAsync(1)),
            (SubscriptionService.GetSubscriptionTypes.Response?) null
        };

        
        yield return new object[]
        {
            // Update subscription
            "Subscriptions/update-subscription_200.json",
            HttpStatusCode.OK,
            "/subscriptions/1",
            HttpMethod.Put,
            new Func<SubscriptionService, Task<SubscriptionService.UpdateSubscriptionTypes.Response>>(service => service.UpdateSubscriptionAsync(1, fixture.Create<SubscriptionService.UpdateSubscriptionTypes.Request>())),
            update_subscription_200.CorrectlyDeserializedJson()
        };

        yield return new object[]
        {
            // List subscriptions
            "Subscriptions/list-subscriptions_200.json",
            HttpStatusCode.OK,
            "/subscriptions",
            HttpMethod.Get,
            new Func<SubscriptionService, Task<SubscriptionService.ListSubscriptionsTypes.Response>>(service => service.ListSubscriptionsAsync(fixture.Create<SubscriptionService.ListSubscriptionsTypes.Request>())),
            list_subscriptions_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Change a subscription next charge date
            "Subscriptions/change-a-subscription-next-charge-date_200.json",
            HttpStatusCode.OK,
            "/subscriptions/1/set_next_charge_date",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.ChangeSubscriptionsNextChargeDateTypes.Response>>(service => service.ChangeSubscriptionsNextChargeDateAsync(1, fixture.Create<SubscriptionService.ChangeSubscriptionsNextChargeDateTypes.Request>())),
            change_a_subscription_next_charge_date_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Change a subscription address
            "Subscriptions/change-a-subscription-address_200.json",
            HttpStatusCode.OK,
            "/subscriptions/1/change_address",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.ChangeSubscriptionsAddressTypes.Response>>(service => service.ChangeSubscriptionsAddressAsync(1, fixture.Create<SubscriptionService.ChangeSubscriptionsAddressTypes.Request>())),
            change_a_subscription_address_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Cancel a subscription
            "Subscriptions/cancel-subscription_200.json",
            HttpStatusCode.OK,
            "/subscriptions/1/cancel",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.CancelSubscriptionTypes.Response>>(service => service.CancelSubscriptionAsync(1, fixture.Create<SubscriptionService.CancelSubscriptionTypes.Request>())),
            cancel_subscription_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Activate a subscription
            "Subscriptions/activate-subscription_200.json",
            HttpStatusCode.OK,
            "/subscriptions/1/activate",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.ActivateSubscriptionTypes.Response>>(service => service.ActivateSubscriptionAsync(1)),
            activate_subscription_200.CorrectlyDeserializedJson()
        };
    }
    
    /// <summary>
    ///     Testing that deletion works as intended
    /// </summary>
    [Fact]
    public async Task TestingDeletion()
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson("Subscriptions/delete-subscription_204.json");
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, HttpStatusCode.NoContent, "/subscriptions/1", HttpMethod.Delete);
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock);
        
        var sut = new SubscriptionService(apiCaller);
        
        // Act
        var act = async () => await sut.DeleteSubscriptionAsync(1);
        
        // Assert
        await act.Should().NotThrowAsync();
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
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock);
        
        var sut = new SubscriptionService(apiCaller);
        
        // Act
        Func<Task> act = async () => { await apiCallerFunc(sut); };
        
        // Assert
        var exceptionShouldBeThrown = await act.Should().ThrowAsync<RechargeApiException>();
        var thrownException = exceptionShouldBeThrown.Which;
        thrownException.Should().BeOfType(expectedExceptionType);
        thrownException.ErrorData.Should().NotBeNull();
        thrownException.ErrorData.ErrorsAsJson.Should().NotBeNull();
    }
    
    public static IEnumerable<object[]> RechargeApiHttpResponseErrorTestCases()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(new DateOnlySpecimenBuilder());
        
        yield return new object[]
        {
            // Create subscription - next charge schedule was set to be in the past
            "Subscriptions/create-subscription_422_next-charge-schedule-was-in-the-past.json",
            HttpStatusCode.UnprocessableEntity,
            "/subscriptions",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.CreateSubscriptionTypes.Response>>(service => service.CreateSubscriptionAsync(fixture.Create<SubscriptionService.CreateSubscriptionTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Update subscription - missing required fields
            "Subscriptions/update-subscription_422_missing-required-properties.json",
            HttpStatusCode.UnprocessableEntity,
            "/subscriptions/1",
            HttpMethod.Put,
            new Func<SubscriptionService, Task<SubscriptionService.UpdateSubscriptionTypes.Response>>(service => service.UpdateSubscriptionAsync(1, fixture.Create<SubscriptionService.UpdateSubscriptionTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Change a subscription next charge date - date set to sometime in the past
            "Subscriptions/change-a-subscription-next-charge-date_422_date-set-to-the-past.json",
            HttpStatusCode.UnprocessableEntity,
            "/subscriptions/1/set_next_charge_date",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.ChangeSubscriptionsNextChargeDateTypes.Response>>(service => service.ChangeSubscriptionsNextChargeDateAsync(1, fixture.Create<SubscriptionService.ChangeSubscriptionsNextChargeDateTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
    }
}
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using RechargeSharp.v2021_11.Endpoints.Subscriptions;
using RechargeSharp.v2021_11.Tests.TestHelpers;
using RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Customers;
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
            // Create payment method
            "Subscriptions/create-subscription_201.json",
            HttpStatusCode.Created,
            "/subscriptions",
            HttpMethod.Post,
            new Func<SubscriptionService, Task<SubscriptionService.CreateSubscriptionTypes.Response>>(service => service.CreateSubscription(fixture.Create<SubscriptionService.CreateSubscriptionTypes.Request>())),
            create_subscription_201.CorrectlyDeserializedJson()
        };
    }
    
    // /// <summary>
    // ///     Tests that the service behaves as expected when the Recharge API returns certain successful HTTP responses
    // /// </summary>
    // [Theory]
    // [MemberData(nameof(RechargeApiHttpResponseErrorTestCases))]
    // public async Task TestingErrorResponseCodes<T>(string sampleResponseJsonFile, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<PaymentMethodsService, Task<T>> apiCallerFunc, Type expectedExceptionType)
    // {
    //     // Arrange
    //     var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson(sampleResponseJsonFile);
    //     var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, httpStatusCode, uriToMatch, method);
    //     var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock, Policy.NoOpAsync());
    //     
    //     var nullLogger = new NullLogger<SubscriptionService>();
    //     var sut = new SubscriptionService(nullLogger, apiCaller);
    //     
    //     // Act
    //     Func<Task> act = async () => { await apiCallerFunc(sut); };
    //     
    //     // Assert
    //     var exceptionShouldBeThrown = await act.Should().ThrowAsync<RechargeApiException>();
    //     var thrownException = exceptionShouldBeThrown.Which;
    //     thrownException.Should().BeOfType(expectedExceptionType);
    //     thrownException.ErrorDataJson.Should().NotBeNull();
    //     thrownException.ErrorDataJson.Errors.Should().NotBeNull();
    // }
    //
    // public static IEnumerable<object[]> RechargeApiHttpResponseErrorTestCases()
    // {
    //     var fixture = new Fixture();
    //
    //     yield return new object[]
    //     {
    //         // Create payment method - no processor customer token with the provided ID exists
    //         "PaymentMethods/create-payment-method_422_no_processor-customer-token_with_id.json",
    //         HttpStatusCode.UnprocessableEntity,
    //         "/payment_methods",
    //         HttpMethod.Post,
    //         new Func<PaymentMethodsService, Task<PaymentMethodsService.CreatePaymentMethodTypes.Response>>(service => service.CreatePaymentMethod(fixture.Create<PaymentMethodsService.CreatePaymentMethodTypes.Request>())),
    //         typeof(UnprocessableEntityException)
    //     };
    // }
}
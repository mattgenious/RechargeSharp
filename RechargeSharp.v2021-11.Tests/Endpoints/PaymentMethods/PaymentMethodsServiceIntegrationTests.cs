using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Polly;
using RechargeSharp.v2021_11.Endpoints.PaymentMethods;
using RechargeSharp.v2021_11.Exceptions;
using RechargeSharp.v2021_11.Tests.TestHelpers;
using RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.PaymentMethods;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Endpoints.PaymentMethods;

public class PaymentMethodsServiceIntegrationTests
{
    /// <summary>
    ///     Tests that the service behaves as expected when the Recharge API returns certain successful HTTP responses
    /// </summary>
    [Theory]
    [MemberData(nameof(RechargeApiHttpResponseSuccessTestCases))]
    public async Task TestingSuccessResponseCodes<T>(string sampleResponseJsonFile, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<PaymentMethodService, Task<T>> apiCallerFunc, T? expectedDeserializedResponse)
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson(sampleResponseJsonFile);
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, httpStatusCode, uriToMatch, method);
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock);
        
        var nullLogger = new NullLogger<PaymentMethodService>();
        var sut = new PaymentMethodService(nullLogger, apiCaller);
        
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
            "PaymentMethods/create-payment-method_201.json",
            HttpStatusCode.Created,
            "/payment_methods",
            HttpMethod.Post,
            new Func<PaymentMethodService, Task<PaymentMethodService.CreatePaymentMethodTypes.Response>>(service => service.CreatePaymentMethodAsync(fixture.Create<PaymentMethodService.CreatePaymentMethodTypes.Request>())),
            create_payment_method_201.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get payment method
            "PaymentMethods/get-payment-method_200.json",
            HttpStatusCode.OK,
            "/payment_methods/1111111",
            HttpMethod.Get,
            new Func<PaymentMethodService, Task<PaymentMethodService.GetPaymentMethodTypes.Response>>(service => service.GetPaymentMethodAsync(1111111)),
            get_payment_method_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Update payment method
            "PaymentMethods/update-payment-method_200.json",
            HttpStatusCode.OK,
            "/payment_methods/1111111",
            HttpMethod.Put,
            new Func<PaymentMethodService, Task<PaymentMethodService.UpdatePaymentMethodTypes.Response>>(service => service.UpdatePaymentMethodAsync(1111111, fixture.Create<PaymentMethodService.UpdatePaymentMethodTypes.Request>())),
            update_payment_method_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Delete payment method
            "PaymentMethods/delete-payment_method_204.json",
            HttpStatusCode.NoContent,
            "/payment_methods/1111111",
            HttpMethod.Delete,
            new Func<PaymentMethodService, Task<PaymentMethodService.DeletePaymentMethodTypes.Response>>(service => service.DeletePaymentMethodAsync(1111111)),
            (PaymentMethodService.DeletePaymentMethodTypes.Response) null
        };
        
        yield return new object[]
        {
            // List payment methods
            "PaymentMethods/list-payment-methods_200.json",
            HttpStatusCode.OK,
            "/payment_methods",
            HttpMethod.Get,
            new Func<PaymentMethodService, Task<PaymentMethodService.ListPaymentMethodTypes.Response>>(service => service.ListPaymentMethodsAsync(fixture.Create<PaymentMethodService.ListPaymentMethodTypes.Request>())),
            list_payment_methods_200.CorrectlyDeserializedJson()
        };
    }
    
    /// <summary>
    ///     Tests that the service behaves as expected when the Recharge API returns certain successful HTTP responses
    /// </summary>
    [Theory]
    [MemberData(nameof(RechargeApiHttpResponseErrorTestCases))]
    public async Task TestingErrorResponseCodes<T>(string sampleResponseJsonFile, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<PaymentMethodService, Task<T>> apiCallerFunc, Type expectedExceptionType)
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson(sampleResponseJsonFile);
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, httpStatusCode, uriToMatch, method);
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock, Policy.NoOpAsync());
        
        var nullLogger = new NullLogger<PaymentMethodService>();
        var sut = new PaymentMethodService(nullLogger, apiCaller);
        
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
            // Create payment method - no processor customer token with the provided ID exists
            "PaymentMethods/create-payment-method_422_no_processor-customer-token_with_id.json",
            HttpStatusCode.UnprocessableEntity,
            "/payment_methods",
            HttpMethod.Post,
            new Func<PaymentMethodService, Task<PaymentMethodService.CreatePaymentMethodTypes.Response>>(service => service.CreatePaymentMethodAsync(fixture.Create<PaymentMethodService.CreatePaymentMethodTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Get payment method - no payment method with the given ID exists
            "PaymentMethods/get-payment-method_404_no_payment_method_with_id.json",
            HttpStatusCode.NotFound,
            "/payment_methods/1",
            HttpMethod.Get,
            new Func<PaymentMethodService, Task<PaymentMethodService.GetPaymentMethodTypes.Response>>(service => service.GetPaymentMethodAsync(1)),
            typeof(NotFoundException)
        };
        
        yield return new object[]
        {
            // Update payment method - attempting to address1 to be empty
            "PaymentMethods/update-payment-method_422_address-is-empty.json",
            HttpStatusCode.UnprocessableEntity,
            "/payment_methods/1",
            HttpMethod.Put,
            new Func<PaymentMethodService, Task<PaymentMethodService.UpdatePaymentMethodTypes.Response>>(service => service.UpdatePaymentMethodAsync(1, fixture.Create<PaymentMethodService.UpdatePaymentMethodTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Delete payment method - attempting to delete payment method with associated address
            "PaymentMethods/delete-payment_method_422_attempting-to-delete-payment-method-with-related-addresses.json",
            HttpStatusCode.UnprocessableEntity,
            "/payment_methods/1",
            HttpMethod.Delete,
            new Func<PaymentMethodService, Task<PaymentMethodService.DeletePaymentMethodTypes.Response>>(service => service.DeletePaymentMethodAsync(1)),
            typeof(UnprocessableEntityException)
        };
    }
}
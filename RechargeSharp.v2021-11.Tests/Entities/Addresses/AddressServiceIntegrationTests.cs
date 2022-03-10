using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Polly;
using RechargeSharp.v2021_11.Entities.Addresses;
using RechargeSharp.v2021_11.Exceptions;
using RechargeSharp.v2021_11.Tests.TestHelpers;
using RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Addresses;
using RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Customers;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Entities.Addresses;

public class AddressServiceIntegrationTests
{
    /// <summary>
    ///     Tests that the service behaves as expected when the Recharge API returns certain successful HTTP responses
    /// </summary>
    [Theory]
    [MemberData(nameof(RechargeApiHttpResponseSuccessTestCases))]
    public async Task TestingSuccessResponseCodes<T>(string sampleResponseJsonFile, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<AddressesService, Task<T>> apiCallerFunc, T? expectedDeserializedResponse)
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson(sampleResponseJsonFile);
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, httpStatusCode, uriToMatch, method);
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock);
        
        var nullLogger = new NullLogger<AddressesService>();
        var sut = new AddressesService(nullLogger, apiCaller);
        
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
            // Create address
            "Addresses/create-address_201.json",
            HttpStatusCode.Created,
            "/addresses",
            HttpMethod.Post,
            new Func<AddressesService, Task<AddressesService.CreateAddressTypes.Response>>(service => service.CreateAddress(fixture.Create<AddressesService.CreateAddressTypes.Request>())),
            create_address_201.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get address
            "Addresses/get-address_200.json",
            HttpStatusCode.OK,
            "/addresses/1",
            HttpMethod.Get,
            new Func<AddressesService, Task<AddressesService.GetAddressTypes.Response>>(service => service.GetAddress(1)),
            get_address_201.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Update address
            "Addresses/update-address_200.json",
            HttpStatusCode.OK,
            "/addresses/1",
            HttpMethod.Put,
            new Func<AddressesService, Task<AddressesService.UpdateAddressTypes.Response>>(service => service.UpdateAddress(1, fixture.Create<AddressesService.UpdateAddressTypes.Request>())),
            update_address_200.CorrectlyDeserializedJson()
        };
    }
    
    /// <summary>
    ///     Tests that the service behaves as expected when the Recharge API returns certain successful HTTP responses
    /// </summary>
    [Theory]
    [MemberData(nameof(RechargeApiHttpResponseErrorTestCases))]
    public async Task TestingErrorResponseCodes<T>(string sampleResponseJsonFile, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<AddressesService, Task<T>> apiCallerFunc, Type expectedExceptionType)
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson(sampleResponseJsonFile);
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, httpStatusCode, uriToMatch, method);
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock, Policy.NoOpAsync());
        
        var nullLogger = new NullLogger<AddressesService>();
        var sut = new AddressesService(nullLogger, apiCaller);
        
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
            // Create address - no data provided at all
            "Addresses/create-address_422_no-data-provided.json",
            HttpStatusCode.UnprocessableEntity,
            "/addresses",
            HttpMethod.Post,
            new Func<AddressesService, Task<AddressesService.CreateAddressTypes.Response>>(service => service.CreateAddress(fixture.Create<AddressesService.CreateAddressTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Update address - address1 is null
            "Addresses/update-address_422_address1-missing.json",
            HttpStatusCode.UnprocessableEntity,
            "/addresses/1",
            HttpMethod.Put,
            new Func<AddressesService, Task<AddressesService.UpdateAddressTypes.Response>>(service => service.UpdateAddress(1, fixture.Create<AddressesService.UpdateAddressTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
    }
}
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Polly;
using RechargeSharp.v2021_11.Endpoints.Addresses;
using RechargeSharp.v2021_11.Exceptions;
using RechargeSharp.v2021_11.Tests.TestHelpers;
using RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Addresses;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Endpoints.Addresses;

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
        
        yield return new object[]
        {
            // Delete address
            "Addresses/delete-address_204.json",
            HttpStatusCode.NoContent,
            "/addresses/1",
            HttpMethod.Delete,
            new Func<AddressesService, Task<AddressesService.DeleteAddressTypes.Response>>(service => service.DeleteAddress(1)),
            (AddressesService.DeleteAddressTypes.Response?) null
        };
        
        yield return new object[]
        {
            // List addresses
            "Addresses/list-addresses_200.json",
            HttpStatusCode.OK,
            "/addresses",
            HttpMethod.Get,
            new Func<AddressesService, Task<AddressesService.ListAddressesTypes.Response>>(service => service.ListAddresses(fixture.Create<AddressesService.ListAddressesTypes.Request>())),
            list_addresses_201.CorrectlyDeserializedJson()
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
        
        yield return new object[]
        {
            // Delete address - address doesn't exist
            "Addresses/update-address_422_address1-missing.json",
            HttpStatusCode.NotFound,
            "/addresses/1",
            HttpMethod.Delete,
            new Func<AddressesService, Task<AddressesService.DeleteAddressTypes.Response>>(service => service.DeleteAddress(1)),
            typeof(NotFoundException)
        };
        
        yield return new object[]
        {
            // Update address - address has active subscriptions
            "Addresses/delete-address_422_address-has-active-subscriptions.json",
            HttpStatusCode.UnprocessableEntity,
            "/addresses/1",
            HttpMethod.Delete,
            new Func<AddressesService, Task<AddressesService.DeleteAddressTypes.Response>>(service => service.DeleteAddress(1)),
            typeof(UnprocessableEntityException)
        };

        yield return new object[]
        {
            // List addresses - 
            "Addresses/list-addresses_422_updated-at-max-was-not-a-proper-date.json",
            HttpStatusCode.UnprocessableEntity,
            "/addresses",
            HttpMethod.Get,
            new Func<AddressesService, Task<AddressesService.ListAddressesTypes.Response>>(service => service.ListAddresses(fixture.Create<AddressesService.ListAddressesTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
    }
}
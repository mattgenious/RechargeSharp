using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
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
    public async Task TestingSuccessResponseCodes<T>(string sampleResponseJsonFile, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<AddressService, Task<T>> apiCallerFunc, T? expectedDeserializedResponse)
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson(sampleResponseJsonFile);
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, httpStatusCode, uriToMatch, method);
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock);
        
        var sut = new AddressService(apiCaller);
        
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
            // Create address
            "Addresses/create-address_201.json",
            HttpStatusCode.Created,
            "/addresses",
            HttpMethod.Post,
            new Func<AddressService, Task<AddressService.CreateAddressTypes.Response>>(service => service.CreateAddressAsync(fixture.Create<AddressService.CreateAddressTypes.Request>())),
            create_address_201.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get address
            "Addresses/get-address_200.json",
            HttpStatusCode.OK,
            "/addresses/1",
            HttpMethod.Get,
            new Func<AddressService, Task<AddressService.GetAddressTypes.Response?>>(service => service.GetAddressAsync(1)),
            get_address_201.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // Get address - no address with given id
            "Addresses/get-address_404_no-address-with-id.json",
            HttpStatusCode.NotFound,
            "/addresses/1",
            HttpMethod.Get,
            new Func<AddressService, Task<AddressService.GetAddressTypes.Response?>>(service => service.GetAddressAsync(1)),
            (AddressService.GetAddressTypes.Response?) null
        };
        
        yield return new object[]
        {
            // Update address
            "Addresses/update-address_200.json",
            HttpStatusCode.OK,
            "/addresses/1",
            HttpMethod.Put,
            new Func<AddressService, Task<AddressService.UpdateAddressTypes.Response>>(service => service.UpdateAddressAsync(1, fixture.Create<AddressService.UpdateAddressTypes.Request>())),
            update_address_200.CorrectlyDeserializedJson()
        };
        
        yield return new object[]
        {
            // List addresses
            "Addresses/list-addresses_200.json",
            HttpStatusCode.OK,
            "/addresses",
            HttpMethod.Get,
            new Func<AddressService, Task<AddressService.ListAddressesTypes.Response>>(service => service.ListAddressesAsync(fixture.Create<AddressService.ListAddressesTypes.Request>())),
            list_addresses_201.CorrectlyDeserializedJson()
        };
    }
    
    
    /// <summary>
    ///     Tests that the service behaves as expected when the Recharge API returns certain successful HTTP responses
    /// </summary>
    [Fact]
    public async Task TestingDeletion()
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson("Addresses/delete-address_204.json");
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, HttpStatusCode.NoContent, "/addresses/1", HttpMethod.Delete);
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock);
        
        var sut = new AddressService(apiCaller);
        
        // Act
        var act = async () => await sut.DeleteAddressAsync(1);
        await act.Should().NotThrowAsync();
    }
    
    /// <summary>
    ///     Tests that the service behaves as expected when the Recharge API returns certain successful HTTP responses
    /// </summary>
    [Theory]
    [MemberData(nameof(RechargeApiHttpResponseErrorTestCases))]
    public async Task TestingErrorResponseCodes(string sampleResponseJsonFile, HttpStatusCode httpStatusCode, string uriToMatch, HttpMethod method, Func<AddressService, Task> apiCallerFunc, Type expectedExceptionType)
    {
        // Arrange
        var sampleResponseJson = await TestResourcesHelper.GetSampleResponseJson(sampleResponseJsonFile);
        var handlerMock = HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(sampleResponseJson, httpStatusCode, uriToMatch, method);
        var apiCaller = RechargeApiCallerMocking.CreateRechargeApiCallerWithMockedHttpHandler(handlerMock);
        
        var sut = new AddressService(apiCaller);
        
        // Act
        Func<Task> act = async () => { await apiCallerFunc(sut); };
        
        // Assert
        var exceptionShouldBeThrown = await act.Should().ThrowAsync<RechargeApiException>();
        var thrownException = exceptionShouldBeThrown.Which;
        thrownException.Should().BeOfType(expectedExceptionType);
        thrownException.ErrorDataJson.Should().NotBeNull();
        thrownException.ErrorDataJson!.ErrorsAsJson.Should().NotBeNull();
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
            new Func<AddressService, Task<AddressService.CreateAddressTypes.Response>>(service => service.CreateAddressAsync(fixture.Create<AddressService.CreateAddressTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Update address - address1 is null
            "Addresses/update-address_422_address1-missing.json",
            HttpStatusCode.UnprocessableEntity,
            "/addresses/1",
            HttpMethod.Put,
            new Func<AddressService, Task<AddressService.UpdateAddressTypes.Response>>(service => service.UpdateAddressAsync(1, fixture.Create<AddressService.UpdateAddressTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
        
        yield return new object[]
        {
            // Delete address - address doesn't exist
            "Addresses/delete-address_404_no-address-with-id.json",
            HttpStatusCode.NotFound,
            "/addresses/1",
            HttpMethod.Delete,
            new Func<AddressService, Task>(service => service.DeleteAddressAsync(1)),
            typeof(NotFoundException)
        };
        
        yield return new object[]
        {
            // Update address - address has active subscriptions
            "Addresses/delete-address_422_address-has-active-subscriptions.json",
            HttpStatusCode.UnprocessableEntity,
            "/addresses/1",
            HttpMethod.Delete,
            new Func<AddressService, Task>(service => service.DeleteAddressAsync(1)),
            typeof(UnprocessableEntityException)
        };

        yield return new object[]
        {
            // List addresses - update_at_max is not a proper date
            "Addresses/list-addresses_422_updated-at-max-was-not-a-proper-date.json",
            HttpStatusCode.UnprocessableEntity,
            "/addresses",
            HttpMethod.Get,
            new Func<AddressService, Task<AddressService.ListAddressesTypes.Response>>(service => service.ListAddressesAsync(fixture.Create<AddressService.ListAddressesTypes.Request>())),
            typeof(UnprocessableEntityException)
        };
    }
}
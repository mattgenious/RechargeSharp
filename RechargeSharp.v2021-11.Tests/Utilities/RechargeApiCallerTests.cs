using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using RechargeSharp.v2021_11.Exceptions;
using RechargeSharp.v2021_11.Utilities;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Utilities;

public class RechargeApiCallerTests
{
    private const string BaseAddress = "https://api.rechargeapps.com";
    
    [Fact]
    public async Task CanGet()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        var uri = $"{BaseAddress}";
        
        // Act
        var result = await sut.Get<SomeClass>("/somepath");

        // Assert
        result.SomeStringProperty.Should().Be("someValue");

        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Get
                && req.RequestUri!.ToString().StartsWith(uri)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }
    
    [Fact]
    public async Task CanPost()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        var uri = $"{BaseAddress}";
        
        // Act
        var result = await sut.Post<SomeClass, SomeClass>(new SomeClass(), "/somepath");

        // Assert
        result.SomeStringProperty.Should().Be("someValue");

        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Post
                && req.RequestUri!.ToString().StartsWith(uri)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }
    
    [Fact]
    public async Task CanPut()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        var uri = $"{BaseAddress}";
        
        // Act
        var result = await sut.Put<SomeClass, SomeClass>(new SomeClass(), "/somepath");

        // Assert
        result.SomeStringProperty.Should().Be("someValue");

        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Put
                && req.RequestUri!.ToString().StartsWith(uri)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }
    
    [Fact]
    public async Task CanDelete()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        var uri = $"{BaseAddress}";
        
        // Act
        await sut.Delete("/somepath");

        // Assert
        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Delete
                && req.RequestUri!.ToString().StartsWith(uri)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Fact]
    public async Task CanHandleErrorResponseBodyWhenErrorsIsJustAString()
    {
        // Arrange
        var errorJsonFromApi = "{\"errors\":\"Not Found\"}";
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningJsonWithStatusCode(errorJsonFromApi, HttpStatusCode.UnprocessableEntity);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var act = () => sut.Get<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorDataJson?.Errors?.RootElement.Should().NotBeNull();
        var structuredApiErrorData = thrownException.ErrorDataJson!.Errors!.RootElement;
        
        structuredApiErrorData.GetString().Should().Be("Not Found");
    }
    
    [Fact]
    public async Task CanHandleSimpleErrorResponseBody()
    {
        // Arrange
        var errorJsonFromApi =
            "{\"errors\":{\"email\":\"Required field missing\",\"first_name\":\"Required field missing\",\"last_name\":\"Required field missing\"}}";
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningJsonWithStatusCode(errorJsonFromApi, HttpStatusCode.UnprocessableEntity);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        // Act
        var act = () => sut.Get<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorDataJson?.Errors?.RootElement.Should().NotBeNull();
        var structuredApiErrorData = thrownException.ErrorDataJson!.Errors!.RootElement;
        
        structuredApiErrorData.GetProperty("email").GetString().Should().Be("Required field missing");
        structuredApiErrorData.GetProperty("first_name").GetString().Should().Be("Required field missing");
        structuredApiErrorData.GetProperty("last_name").GetString().Should().Be("Required field missing");
    }
    
    [Fact]
    public async Task CanHandleComplexErrorResponseBody()
    {
        // Arrange
        var errorJsonFromApi =
            "{\"errors\":{\"email\":\"Required field missing\",\"first_name\":\"Required field missing\",\"complex_error\":{\"some_property\":\"some value\"}}}";
        var httpHandlerMock =  SetupHttpHandlerMock_ReturningJsonWithStatusCode(errorJsonFromApi, HttpStatusCode.UnprocessableEntity);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var act = () => sut.Get<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorDataJson?.Errors?.RootElement.Should().NotBeNull();
        var structuredApiErrorData = thrownException.ErrorDataJson!.Errors!.RootElement;
        
        structuredApiErrorData.GetProperty("email").GetString().Should().Be("Required field missing");
        structuredApiErrorData.GetProperty("first_name").GetString().Should().Be("Required field missing");
        structuredApiErrorData.GetProperty("complex_error").ValueKind.Should().Be(JsonValueKind.Object);
    }

    [Theory]
    [InlineData(400, typeof(BadRequestException))] // Bad Request: The request was unacceptable, often due to a missing required parameter.
    [InlineData(401, typeof(UnauthorizedException))] // Unauthorized: No valid API key was provided.                        
    [InlineData(402, typeof(UnknownApiFailureException))] // Request Failed: The parameters were valid but the request failed.
    [InlineData(403, typeof(ForbiddenException))] // The request was authenticated but not authorized for the requested resource (permission scope error).
    [InlineData(404, typeof(NotFoundException))] // Not Found: The requested resource doesn’t exist.
    [InlineData(405, typeof(MethodNotAllowedException))] // Method Not Allowed: The method is not allowed for this URI.
    [InlineData(406, typeof(UnknownApiFailureException))] // The request was unacceptable, or requesting a data source which is not allowed although permissions permit the request.
    [InlineData(409, typeof(ConflictException))] // Conflict: You will get this error when you try to send two requests to edit an address or any of its child objects at the same time, in order to avoid out of date information being returned.
    [InlineData(415, typeof(UnsupportedMediaTypeException))] // The request body was not a JSON object.
    [InlineData(422, typeof(UnprocessableEntityException))] // The request was understood but cannot be processed due to invalid or missing supplemental information.
    [InlineData(426, typeof(InvalidApiVersionException))] // The request was made using an invalid API version.
    [InlineData(429, typeof(RateLimitingException))] // The request has been rate limited.
    [InlineData(500, typeof(RechargeApiServerException))] // Internal server error.
    [InlineData(501, typeof(RechargeApiServerException))] // The resource requested has not been implemented in the current version but may be implemented in the future.
    [InlineData(503, typeof(RechargeApiServerException))] // A 3rd party service on which the request depends has timed out.
    [InlineData(999, typeof(RechargeApiException))] // Testing the default case
    public async Task ThrowsRechargeApiExceptionOnApiError(int statusCodeReturnedByApi, Type expectedExceptionType)
    {
        // Arrange
        var httpHandlerMock =  SetupHttpHandlerMock_ReturnsStatusCodeOnly((HttpStatusCode) statusCodeReturnedByApi);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        var uri = $"{BaseAddress}";
        
        // Act
        var act = () => sut.Get<SomeClass>("/doesntmatter");
        
        // Assert
        (await act.Should().ThrowAsync<Exception>()).Which.Should().BeOfType(expectedExceptionType);
    }
    
    private static Mock<HttpMessageHandler> SetupHttpHandlerMock_ReturningJsonWithStatusCode(string mockJsonFromApi, HttpStatusCode returnedStatusCode)
    {
        return CreateHttpMessageHandlerThatReturns(new HttpResponseMessage()
        {
            StatusCode = returnedStatusCode,
            Content = new StringContent(mockJsonFromApi),
        });
    }
    
    private static Mock<HttpMessageHandler> SetupHttpHandlerMock_ReturnsStatusCodeOnly( HttpStatusCode returnedStatusCode)
    {
        return CreateHttpMessageHandlerThatReturns(new HttpResponseMessage()
        {
            StatusCode = returnedStatusCode
        });
    }
    
    private static Mock<HttpMessageHandler> SetupHttpHandlerMock_ReturningStatusCode(HttpStatusCode statusCodeToReturn)
    {
        return CreateHttpMessageHandlerThatReturns(new HttpResponseMessage()
        {
            StatusCode = statusCodeToReturn,
        });
    }
    
    private static Mock<HttpMessageHandler> CreateHttpMessageHandlerThatReturns(HttpResponseMessage httpResponseMessage)
    {
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(httpResponseMessage)
            .Verifiable();
        return handlerMock;
    }
    
    private static RechargeApiCaller CreateSut(IMock<HttpMessageHandler> handlerMock, string baseAddress)
    {
        // use real http client with mocked handler here
        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri(baseAddress),
        };

        var logger = new NullLogger<RechargeApiCaller>();
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();

        httpClientFactoryMock.Setup(f => f.CreateClient(string.Empty)).Returns(httpClient);
        var options = Options.Create(new RechargeServiceOptions());
        var sut = new RechargeApiCaller(httpClientFactoryMock.Object, logger);
        return sut;
    }

    public record SomeClass
    {
        public string SomeStringProperty { get; set; }
    }
}
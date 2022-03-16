using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using RechargeSharp.v2021_11.Configuration;
using RechargeSharp.v2021_11.Configuration.DependencyInjection;
using RechargeSharp.v2021_11.Exceptions;
using RechargeSharp.v2021_11.Tests.TestHelpers;
using RechargeSharp.v2021_11.Utilities;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Utilities;

public class RechargeApiCallerTests
{
    private const string BaseAddress = "https://api.rechargeapps.com";
    private const string ApiKey = "apikeygoeshere";
    private const string ApiVersion = "2021-11";
    
    [Fact]
    public async Task CanGet()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK, "/somepath", HttpMethod.Get);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var result = await sut.GetAsync<SomeClass>("/somepath");

        // Assert
        result.SomeStringProperty.Should().Be("someValue");
        AssertThatExpectedHttpCallsWereMade(httpHandlerMock, HttpMethod.Get, 1);
    }
    
    [Fact]
    public async Task CanPost()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK, "/somepath", HttpMethod.Post);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        // Act
        var result = await sut.PostAsync<SomeClass, SomeClass>(new SomeClass(), "/somepath");

        // Assert
        result.SomeStringProperty.Should().Be("someValue");
        AssertThatExpectedHttpCallsWereMade(httpHandlerMock, HttpMethod.Post, 1);
    }
    
    [Fact]
    public async Task CanPostEmptyBody()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK, "/somepath", HttpMethod.Post);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        // Act
        var result = await sut.PostAsync<SomeClass>("/somepath");

        // Assert
        result.SomeStringProperty.Should().Be("someValue");
        AssertThatExpectedHttpCallsWereMade(httpHandlerMock, HttpMethod.Post, 1);
    }
    
    [Fact]
    public async Task CanPut()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK, "/somepath", HttpMethod.Put);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        // Act
        var result = await sut.PutAsync<SomeClass, SomeClass>(new SomeClass(), "/somepath");

        // Assert
        result.SomeStringProperty.Should().Be("someValue");

        AssertThatExpectedHttpCallsWereMade(httpHandlerMock, HttpMethod.Put, 1);
    }
    
    [Fact]
    public async Task CanDelete()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK, "/somepath", HttpMethod.Delete);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        await sut.DeleteAsync("/somepath");

        // Assert
        AssertThatExpectedHttpCallsWereMade(httpHandlerMock, HttpMethod.Delete, 1);
    }
    
    [Fact]
    public async Task WillRetryOnNonTransientError()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        
        // PaymentRequired is Recharge's way of communicating a rather unspecified error
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.PaymentRequired, "/somepath", HttpMethod.Post);

        var retryCount = 1;
        var sut = CreateSut(httpHandlerMock, BaseAddress, retryCount);
        
        // Act
        var act = () => sut.PostAsync<SomeClass, SomeClass>(new SomeClass(), "/somepath");

        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorData?.ErrorsAsJson?.Should().BeNull();

        AssertThatExpectedHttpCallsWereMade(httpHandlerMock, HttpMethod.Post, retryCount + 1);
    }
    
    [Fact]
    public async Task CanHandleErrorResponseBodyWhenErrorsIsCalledError()
    {
        // Arrange
        var errorJsonFromApi = "{\"error\":\"endpoint not found\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(errorJsonFromApi, HttpStatusCode.UnprocessableEntity, "/doesntmatter", HttpMethod.Get);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var act = () => sut.GetAsync<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorData?.ErrorsAsJson?.Should().NotBeNull();
        var structuredApiErrorData = thrownException.ErrorData!.ErrorsAsJson;
        
        structuredApiErrorData!.Value.GetString().Should().Be("endpoint not found");
    }
    
        
    [Fact]
    public async Task CanHandleNonJsonReturnBodyOnError()
    {
        // Arrange
        var errorJsonFromApi = "this is not JSON";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(errorJsonFromApi, HttpStatusCode.BadGateway, "/doesntmatter", HttpMethod.Get);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var act = () => sut.GetAsync<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorData.Should().NotBeNull();
        thrownException.ErrorData!.ErrorsAsJson?.Should().BeNull();
        thrownException.ErrorData!.RawErrorBody?.Should().Contain(errorJsonFromApi);
    }

    [Fact]
    public async Task CanHandleEmptyErrorResponseBody()
    {
        // Arrange
        var errorJsonFromApi = "";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(errorJsonFromApi, HttpStatusCode.UnprocessableEntity, "/doesntmatter", HttpMethod.Get);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var act = () => sut.GetAsync<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorData?.ErrorsAsJson?.Should().BeNull();
    }
    
    [Fact]
    public async Task CanHandleErrorResponseBodyWhenErrorsIsJustAString()
    {
        // Arrange
        var errorJsonFromApi = "{\"errors\":\"Not Found\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(errorJsonFromApi, HttpStatusCode.UnprocessableEntity, "/doesntmatter", HttpMethod.Get);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var act = () => sut.GetAsync<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorData?.ErrorsAsJson?.Should().NotBeNull();
        var structuredApiErrorData = thrownException.ErrorData!.ErrorsAsJson!;
        
        structuredApiErrorData.Value.GetString().Should().Be("Not Found");
    }
    
    [Fact]
    public async Task CanHandleSimpleErrorResponseBody()
    {
        // Arrange
        var errorJsonFromApi =
            "{\"errors\":{\"email\":\"Required field missing\",\"first_name\":\"Required field missing\",\"last_name\":\"Required field missing\"}}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(errorJsonFromApi, HttpStatusCode.UnprocessableEntity, "/doesntmatter", HttpMethod.Get);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        // Act
        var act = () => sut.GetAsync<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorData?.ErrorsAsJson?.Should().NotBeNull();
        var structuredApiErrorData = thrownException.ErrorData!.ErrorsAsJson!;
        
        structuredApiErrorData.Value.GetProperty("email").GetString().Should().Be("Required field missing");
        structuredApiErrorData.Value.GetProperty("first_name").GetString().Should().Be("Required field missing");
        structuredApiErrorData.Value.GetProperty("last_name").GetString().Should().Be("Required field missing");
    }
    
    [Fact]
    public async Task CanHandleComplexErrorResponseBody()
    {
        // Arrange
        var errorJsonFromApi =
            "{\"errors\":{\"email\":\"Required field missing\",\"first_name\":\"Required field missing\",\"complex_error\":{\"some_property\":\"some value\"}}}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(errorJsonFromApi, HttpStatusCode.UnprocessableEntity, "/doesntmatter", HttpMethod.Get);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var act = () => sut.GetAsync<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorData?.ErrorsAsJson?.Should().NotBeNull();
        var structuredApiErrorData = thrownException.ErrorData!.ErrorsAsJson!;
        
        structuredApiErrorData.Value.GetProperty("email").GetString().Should().Be("Required field missing");
        structuredApiErrorData.Value.GetProperty("first_name").GetString().Should().Be("Required field missing");
        structuredApiErrorData.Value.GetProperty("complex_error").ValueKind.Should().Be(JsonValueKind.Object);
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
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturnsStatusCodeOnly((HttpStatusCode) statusCodeReturnedByApi, "/doesntmatter", HttpMethod.Get);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var act = () => sut.GetAsync<SomeClass>("/doesntmatter");
        
        // Assert
        (await act.Should().ThrowAsync<Exception>()).Which.Should().BeOfType(expectedExceptionType);
    }
    
    private static void AssertThatExpectedHttpCallsWereMade(Mock<HttpMessageHandler> httpHandlerMock, HttpMethod httpMethod, int expectedNumberOfCalls)
    {
        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(expectedNumberOfCalls),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == httpMethod &&
                req.RequestUri!.ToString().StartsWith(BaseAddress) &&
                req.Headers.GetValues(RechargeConstants.Headers.Keys.ApiKey).Contains(ApiKey) &&
                req.Headers.GetValues(RechargeConstants.Headers.Keys.ApiVersion).Contains(ApiVersion)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }
    
    [Fact]
    public async Task LogsAsExpectedWhenStatusCodeIsSuccess()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK, "/somepath", HttpMethod.Get);
        var logger = new TestJsonLogger<LoggingHttpHandler>();
        var loggingHttpHandler = new LoggingHttpHandler(logger, Options.Create(new LoggingHttpHandlerOptions()));
        var sut = CreateSut(loggingHttpHandler, httpHandlerMock, BaseAddress, 0);

        // Act
        await sut.GetAsync<SomeClass>("/somepath");

        // Assert
        logger.LogEntries.Should().HaveCount(2, "one log for the request and one log for the response should have been added");
        var requestLog = logger.LogEntries.First();
        requestLog.LogMessage.Should().NotContain(ApiKey, "the full API key must not be logged");
        requestLog.LogMessage.Should().MatchRegex(@$"{ApiKey.Substring(0,5)}\**", "the first characters of the API key should be logged");
        requestLog.LogAsJson?.RootElement.EnumerateArray().ToList().Should().NotBeEmpty("some JSON elements should have been logged");
        
        var responseLog = logger.LogEntries.Last();
        responseLog.LogAsJson?.RootElement.EnumerateArray().ToList().Should().NotBeEmpty("some JSON elements should have been logged");
    }
    
    [Fact]
    public async Task LogsAsExpectedWhenRetriesAreAttempted()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.PaymentRequired, "/somepath", HttpMethod.Get);
        
        var retryCount = 2;
        var testJsonLogger = new TestJsonLogger<LoggingHttpHandler>();
        var apiCallerJsonLogger = new TestJsonLogger<RechargeApiCaller>();
        var loggingHttpHandler = new LoggingHttpHandler(testJsonLogger, Options.Create(new LoggingHttpHandlerOptions()));
        var sut = CreateSut(loggingHttpHandler, httpHandlerMock, BaseAddress, retryCount, apiCallerJsonLogger);

        // Act
        var act = async () => await sut.GetAsync<SomeClass>("/somepath");

        await act.Should().ThrowAsync<Exception>();

        // Assert
        testJsonLogger.LogEntries.Should().HaveCount((3 * retryCount),"each attempt should produce one log for the request and one log for the response");
        testJsonLogger.LogEntries.Should()
            .AllSatisfy(l => l.LogAsJson?.RootElement.EnumerateArray().ToList().Should().NotBeEmpty(),
                "some JSON elements should have been logged");
        apiCallerJsonLogger.LogEntries.Should().HaveCount(retryCount, "each retry should produce an exception log");
        apiCallerJsonLogger.LogEntries.Should()
            .AllSatisfy(l => l.LogAsJson?.RootElement.EnumerateArray().ToList().Should().NotBeEmpty(),
                "some JSON elements should have been logged");
        apiCallerJsonLogger.LogEntries.Should()
            .AllSatisfy(l => l.Exception.Should().NotBeNull(), "exceptions should have been logged");
    }
    
    private static RechargeApiCaller CreateSut(IMock<HttpMessageHandler> handlerMock, string baseAddress)
    {
        return CreateSut(handlerMock, baseAddress, 0);
    }
    
    private static RechargeApiCaller CreateSut(IMock<HttpMessageHandler> handlerMock, string baseAddress, int retryCount)
    {
        // use real http client with mocked handler here
        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri(baseAddress),
        };
        
        var logger = new NullLogger<RechargeApiCaller>();
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();

        httpClientFactoryMock.Setup(f => f.CreateClient(RechargeSharpDependencyInjection.RechargeSharpHttpClientKey)).Returns(httpClient);

        var rechargeApiCallerOptions = new RechargeApiCallerOptions()
        {
            RetryCount = retryCount,
            ApiKey = ApiKey
        };
        var sut = new RechargeApiCaller(httpClientFactoryMock.Object, logger, Options.Create(rechargeApiCallerOptions));
        return sut;
    }
    
    private static RechargeApiCaller CreateSut(LoggingHttpHandler loggingHttpHandler, IMock<HttpMessageHandler> handlerMock, string baseAddress, int retryCount, ILogger<RechargeApiCaller>? logger = null)
    {
        loggingHttpHandler.InnerHandler = handlerMock.Object;
        
        // use real http client with mocked handler here
        var httpClient = new HttpClient(loggingHttpHandler)
        {
            BaseAddress = new Uri(baseAddress),
        };
        
        logger ??= new NullLogger<RechargeApiCaller>();
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();

        httpClientFactoryMock.Setup(f => f.CreateClient(RechargeSharpDependencyInjection.RechargeSharpHttpClientKey)).Returns(httpClient);

        var rechargeApiCallerOptions = new RechargeApiCallerOptions()
        {
            RetryCount = retryCount,
            ApiKey = ApiKey
        };
        var sut = new RechargeApiCaller(httpClientFactoryMock.Object, logger, Options.Create(rechargeApiCallerOptions));
        return sut;
    }

    private record SomeClass
    {
        public string SomeStringProperty { get; set; }
    }
}
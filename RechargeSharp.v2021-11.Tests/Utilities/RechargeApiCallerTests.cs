using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Moq.Protected;
using Polly;
using RechargeSharp.v2021_11.Exceptions;
using RechargeSharp.v2021_11.Tests.TestHelpers;
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
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK, "/somepath", HttpMethod.Get);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var result = await sut.Get<SomeClass>("/somepath");

        // Assert
        result.SomeStringProperty.Should().Be("someValue");

        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Get
                && req.RequestUri!.ToString().StartsWith(BaseAddress)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }
    
    [Fact]
    public async Task CanPost()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK, "/somepath", HttpMethod.Post);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        // Act
        var result = await sut.Post<SomeClass, SomeClass>(new SomeClass(), "/somepath");

        // Assert
        result.SomeStringProperty.Should().Be("someValue");

        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Post
                && req.RequestUri!.ToString().StartsWith(BaseAddress)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }
    
    [Fact]
    public async Task CanPut()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK, "/somepath", HttpMethod.Put);
        var sut = CreateSut(httpHandlerMock, BaseAddress);
        
        // Act
        var result = await sut.Put<SomeClass, SomeClass>(new SomeClass(), "/somepath");

        // Assert
        result.SomeStringProperty.Should().Be("someValue");

        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Put
                && req.RequestUri!.ToString().StartsWith(BaseAddress)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }
    
    [Fact]
    public async Task CanDelete()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.OK, "/somepath", HttpMethod.Delete);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        await sut.Delete("/somepath");

        // Assert
        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Delete
                && req.RequestUri!.ToString().StartsWith(BaseAddress)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }
    
    [Fact]
    public async Task WillRetryOnNonTransientError()
    {
        // Arrange
        var jsonReturnedByApi = "{\"some_string_property\": \"someValue\"}";
        
        // PaymentRequired is Recharge's way of communicating a rather unspecified error
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(jsonReturnedByApi, HttpStatusCode.PaymentRequired, "/somepath", HttpMethod.Post); 

        var retryCount = 5;
        var retryPolicy = RechargeApiCallerOptions.BuildErrorHandlingLogic(policyBuilder => policyBuilder.RetryAsync(retryCount));
        var sut = CreateSut(httpHandlerMock, BaseAddress, retryPolicy);
        
        // Act
        var act = () => sut.Post<SomeClass, SomeClass>(new SomeClass(), "/somepath");

        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorDataJson?.Errors?.Should().BeNull();

        httpHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(retryCount + 1),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Post
                && req.RequestUri!.ToString().StartsWith(BaseAddress)
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }
    
    [Fact]
    public async Task CanHandleErrorResponseBodyWhenErrorsIsCalledError()
    {
        // Arrange
        var errorJsonFromApi = "{\"error\":\"endpoint not found\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(errorJsonFromApi, HttpStatusCode.UnprocessableEntity, "/doesntmatter", HttpMethod.Get);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var act = () => sut.Get<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorDataJson?.Errors?.Should().NotBeNull();
        var structuredApiErrorData = thrownException.ErrorDataJson!.Errors;
        
        structuredApiErrorData!.Value.GetString().Should().Be("endpoint not found");
    }

    [Fact]
    public async Task CanHandleEmptyErrorResponseBody()
    {
        // Arrange
        var errorJsonFromApi = "";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(errorJsonFromApi, HttpStatusCode.UnprocessableEntity, "/doesntmatter", HttpMethod.Get);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var act = () => sut.Get<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorDataJson?.Errors?.Should().BeNull();
    }
    
    [Fact]
    public async Task CanHandleErrorResponseBodyWhenErrorsIsJustAString()
    {
        // Arrange
        var errorJsonFromApi = "{\"errors\":\"Not Found\"}";
        var httpHandlerMock =  HttpHandlerMocking.SetupHttpHandlerMock_ReturningJsonWithStatusCode(errorJsonFromApi, HttpStatusCode.UnprocessableEntity, "/doesntmatter", HttpMethod.Get);
        var sut = CreateSut(httpHandlerMock, BaseAddress);

        // Act
        var act = () => sut.Get<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorDataJson?.Errors?.Should().NotBeNull();
        var structuredApiErrorData = thrownException.ErrorDataJson!.Errors!;
        
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
        var act = () => sut.Get<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorDataJson?.Errors?.Should().NotBeNull();
        var structuredApiErrorData = thrownException.ErrorDataJson!.Errors!;
        
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
        var act = () => sut.Get<SomeClass>("/doesntmatter");
        
        // Assert
        var thrownException = (await act.Should().ThrowAsync<RechargeApiException>()).Which;
        thrownException.ErrorDataJson?.Errors?.Should().NotBeNull();
        var structuredApiErrorData = thrownException.ErrorDataJson!.Errors!;
        
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
        var uri = $"{BaseAddress}";
        
        // Act
        var act = () => sut.Get<SomeClass>("/doesntmatter");
        
        // Assert
        (await act.Should().ThrowAsync<Exception>()).Which.Should().BeOfType(expectedExceptionType);
    }
    
    
    private static RechargeApiCaller CreateSut(IMock<HttpMessageHandler> handlerMock, string baseAddress)
    {
        return CreateSut(handlerMock, baseAddress, Policy.NoOpAsync());
    }
    
    private static RechargeApiCaller CreateSut(IMock<HttpMessageHandler> handlerMock, string baseAddress, IAsyncPolicy policy)
    {
        // use real http client with mocked handler here
        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri(baseAddress),
        };

        var logger = new NullLogger<RechargeApiCaller>();
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();

        httpClientFactoryMock.Setup(f => f.CreateClient(string.Empty)).Returns(httpClient);

        var rechargeApiCallerOptions = new RechargeApiCallerOptions()
        {
            ApiCallPolicy = policy
        };
        var sut = new RechargeApiCaller(httpClientFactoryMock.Object, logger, rechargeApiCallerOptions);
        return sut;
    }

    public record SomeClass
    {
        public string SomeStringProperty { get; set; }
    }
}
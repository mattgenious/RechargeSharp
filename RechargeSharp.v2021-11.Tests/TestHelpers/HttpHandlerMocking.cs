using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace RechargeSharp.v2021_11.Tests.TestHelpers;

public static class HttpHandlerMocking
{
    private const string BaseAddress = "https://api.rechargeapps.com";
    
    public static Mock<HttpMessageHandler> SetupHttpHandlerMock_ReturningJsonWithStatusCode(string mockJsonFromApi, HttpStatusCode returnedStatusCode, string uriToMatch, HttpMethod method)
    {
        return CreateHttpMessageHandlerThatReturns(new HttpResponseMessage()
        {
            StatusCode = returnedStatusCode,
            Content = new StringContent(mockJsonFromApi),
        }, uriToMatch, method);
    }

    public static Mock<HttpMessageHandler> SetupHttpHandlerMock_ReturnsStatusCodeOnly(HttpStatusCode returnedStatusCode, string uriToMatch, HttpMethod method)
    {
        return CreateHttpMessageHandlerThatReturns(new HttpResponseMessage()
        {
            StatusCode = returnedStatusCode
        }, uriToMatch, method);
    }

    private static Mock<HttpMessageHandler> CreateHttpMessageHandlerThatReturns(HttpResponseMessage httpResponseMessage, string uriToMatch, HttpMethod method)
    {
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(r =>
                    r.RequestUri != null &&
                    r.RequestUri.ToString().StartsWith($"{BaseAddress}{uriToMatch}") &&
                    r.Method == method
                ),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(httpResponseMessage);
        return handlerMock;
    }
}
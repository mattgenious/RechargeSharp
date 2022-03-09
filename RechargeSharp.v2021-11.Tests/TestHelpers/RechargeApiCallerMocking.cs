using System;
using System.Net.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Polly;
using RechargeSharp.v2021_11.Utilities;

namespace RechargeSharp.v2021_11.Tests.TestHelpers;

public static class RechargeApiCallerMocking
{
    public static RechargeApiCaller CreateRechargeApiCallerWithMockedHttpHandler(IMock<HttpMessageHandler> handlerMock, IAsyncPolicy? policy = null)
    {
        // use real http client with mocked handler here
        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://api.rechargeapps.com"),
        };

        var logger = new NullLogger<RechargeApiCaller>();
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();

        httpClientFactoryMock.Setup(f => f.CreateClient(string.Empty)).Returns(httpClient);

        var rechargeApiCallerOptions = new RechargeApiCallerOptions();
        if (policy != null)
            rechargeApiCallerOptions.ApiCallPolicy = policy;
        var sut = new RechargeApiCaller(httpClientFactoryMock.Object, logger, rechargeApiCallerOptions);
        return sut;
    }
}
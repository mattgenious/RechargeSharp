using System;
using System.Net.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using Polly;
using RechargeSharp.v2021_11.Configuration;
using RechargeSharp.v2021_11.Configuration.DependencyInjection;
using RechargeSharp.v2021_11.Utilities;

namespace RechargeSharp.v2021_11.Tests.TestHelpers;

public static class RechargeApiCallerMocking
{
    public static RechargeApiCaller CreateRechargeApiCallerWithMockedHttpHandler(IMock<HttpMessageHandler> handlerMock, int? retryCount = null)
    {
        // use real http client with mocked handler here
        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri(RechargeConstants.ApiUrl),
        };

        var logger = new NullLogger<RechargeApiCaller>();
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();

        httpClientFactoryMock.Setup(f => f.CreateClient(RechargeSharpDependencyInjection.RechargeSharpHttpClientKey)).Returns(httpClient);

        var rechargeApiCallerOptions = new RechargeApiCallerOptions();
        if (retryCount != null)
            rechargeApiCallerOptions.RetryCount = retryCount.Value;
        var sut = new RechargeApiCaller(httpClientFactoryMock.Object, logger, Options.Create(rechargeApiCallerOptions));
        return sut;
    }
}
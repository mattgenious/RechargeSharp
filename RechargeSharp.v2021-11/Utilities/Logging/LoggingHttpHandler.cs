using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RechargeSharp.v2021_11.Configuration;

namespace RechargeSharp.v2021_11.Utilities.Logging;

public class LoggingHttpHandler : DelegatingHandler
{
    private readonly ILogger<LoggingHttpHandler> _logger;
    private readonly LoggingHttpHandlerOptions _configuration;

    public LoggingHttpHandler(ILogger<LoggingHttpHandler> logger, IOptions<LoggingHttpHandlerOptions> options)
    {
        _configuration = options.Value;
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var requestId = Guid.NewGuid().ToString();
        LogRequest(request, requestId);
        var sw = new Stopwatch();
        sw.Start();
        var response = await base.SendAsync(request, cancellationToken);
        sw.Stop();
        LogResponse(response, requestId, sw.Elapsed);
        return response;
    }

    private void LogRequest(HttpRequestMessage request, string requestId)
    {
        var formattedHeaders = string.Join(", ", request.Headers.Select(h => FormatHeader(h)));
        _logger.Log(_configuration.LogLevel, "({RequestId}) Request: {HttpMethod} {Url} - headers: {Headers}", requestId, request.Method, request.RequestUri?.ToString() ?? "-", formattedHeaders);
    }
    
    private void LogResponse(HttpResponseMessage response, string requestId, TimeSpan elapsed)
    {
        var formattedHeaders = string.Join(", ", response.Headers.Select(h => FormatHeader(h, ResponseHeadersThatShouldNotBeLogged)).Where(s => !string.IsNullOrWhiteSpace(s)));
        _logger.Log(_configuration.LogLevel, "({RequestId}) Response: {StatusCode} - response time: {ResponseTimeInMs} ms - headers: {Headers}", requestId, response.StatusCode, elapsed.TotalMilliseconds, formattedHeaders);
    }

    private static string FormatHeader(KeyValuePair<string, IEnumerable<string>> header, HashSet<string>? headersThatShouldNotBeLogged = null)
    {
        var (key, values) = header;
        if (headersThatShouldNotBeLogged?.Contains(key) == true)
            return string.Empty;
        var formattedHeaderValue = string.Join(", ", values);
        if (key.Equals(RechargeConstants.Headers.Keys.ApiKey))
        {
            // We will not log the entire API key
            var headerValuesLength = formattedHeaderValue.Length;
            formattedHeaderValue = formattedHeaderValue[..5];
            formattedHeaderValue = formattedHeaderValue.PadRight(headerValuesLength, '*');
        }
            
        return $"({key}: {formattedHeaderValue})";
    }

    private static readonly HashSet<string> ResponseHeadersThatShouldNotBeLogged = new HashSet<string>()
    {
        "Access-Control-Allow-Origin",
        "Access-Control-Expose-Headers",
        "Connection",
        "Date",
        "Server",
        "Set-Cookie",
        "Strict-Transport-Security",
        "Vary",
        "X-Content-Type-Options"
    };
}
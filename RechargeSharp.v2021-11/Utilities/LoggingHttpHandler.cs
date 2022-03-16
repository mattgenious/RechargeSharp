using Microsoft.Extensions.Logging;
using RechargeSharp.v2021_11.Configuration;

namespace RechargeSharp.v2021_11.Utilities;

public class LoggingHttpHandler : DelegatingHandler
{
    private readonly ILogger<LoggingHttpHandler> _logger;

    public LoggingHttpHandler(ILogger<LoggingHttpHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var requestId = Guid.NewGuid().ToString();
        LogRequest(request, requestId);
        var response = await base.SendAsync(request, cancellationToken);
        LogResponse(response, requestId);
        return response;
    }

    private void LogResponse(HttpResponseMessage response, string requestId)
    {
        var formattedHeaders = string.Join(", ", response.Headers.Select(FormatHeader));

        var logLevel = LogLevel.Information;
        _logger.Log(logLevel, "({RequestId}) Response: {StatusCode} - headers: {Headers}", requestId, response.StatusCode, formattedHeaders);
    }

    private void LogRequest(HttpRequestMessage request, string requestId)
    {
        var formattedHeaders = string.Join(", ", request.Headers.Select(FormatHeader));

        var logLevel = LogLevel.Information;
        _logger.Log(logLevel, "({RequestId}) Request: {HttpMethod} {Url} - headers: {Headers}", requestId, request.Method, request.RequestUri?.ToString() ?? "-", formattedHeaders);
    }

    private static string FormatHeader(KeyValuePair<string, IEnumerable<string>> h)
    {
        var (key, values) = h;
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
}
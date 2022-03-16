using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RechargeSharp.v2021_11.Configuration;

namespace RechargeSharp.v2021_11.Utilities;

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
        var response = await base.SendAsync(request, cancellationToken);
        LogResponse(response, requestId);
        return response;
    }

    private void LogRequest(HttpRequestMessage request, string requestId)
    {
        var formattedHeaders = string.Join(", ", request.Headers.Select(FormatHeader));
        _logger.Log(_configuration.RequestLogLevel, "({RequestId}) Request: {HttpMethod} {Url} - headers: {Headers}", requestId, request.Method, request.RequestUri?.ToString() ?? "-", formattedHeaders);
    }
    
    private void LogResponse(HttpResponseMessage response, string requestId)
    {
        var formattedHeaders = string.Join(", ", response.Headers.Select(FormatHeader));
        _logger.Log(_configuration.ResponseLogLevel, "({RequestId}) Response: {StatusCode} - headers: {Headers}", requestId, response.StatusCode, formattedHeaders);
    }

    private static string FormatHeader(KeyValuePair<string, IEnumerable<string>> header)
    {
        var (key, values) = header;
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

public class LoggingHttpHandlerOptions
{
    public LogLevel RequestLogLevel { get; set; } = LogLevel.Information;
    public LogLevel ResponseLogLevel { get; set; } = LogLevel.Information;
}
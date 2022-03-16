using Microsoft.Extensions.Logging;

namespace RechargeSharp.v2021_11.Utilities.Logging;

public class LoggingHttpHandlerOptions
{
    public LogLevel LogLevel { get; set; } = LogLevel.Debug;
}
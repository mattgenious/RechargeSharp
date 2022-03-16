using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace RechargeSharp.v2021_11.Tests.TestHelpers;

public class TestJsonLogger<T> : ILogger<T>
{
    public readonly List<TestLogEntry> LogEntries = new List<TestLogEntry>();
    
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        JsonDocument? serializedState = null;
        try
        {
            serializedState = JsonSerializer.SerializeToDocument(state);
        }
        catch (Exception e)
        {
            // ignored
        }

        LogEntries.Add(new TestLogEntry(logLevel, exception, serializedState, formatter(state, exception)));
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        throw new NotImplementedException();
    }

    public record TestLogEntry(LogLevel LogLevel, Exception? Exception, JsonDocument? LogAsJson, string LogMessage);
}
using System;
using System.Text.Json;
using FluentAssertions;
using RechargeSharp.v2021_11.Utilities.Json;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Utilities.Json;

/// <summary>
///     Inspired by: https://github.com/michaelrosedev/snakecase_json/blob/dbc70b7e137e42716350685f684bd46d0458d056/Sample.Tests/SerializationTests.cs
/// </summary>
public class SnakeCaseSerializationTests
{
    private readonly JsonSerializerOptions _options;

    public SnakeCaseSerializationTests()
    {
        _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = new SnakeCaseNamingPolicy()
        };
    }

    [Fact]
    public void CanSerializeObjectToJson()
    {
        var input = new SomeClass("here is a string", new DateTime(2022, 3, 1, 12, 0, 0), 2.45m);
        var serialized = JsonSerializer.Serialize(input, _options);
        serialized.Should().NotBeEmpty();
    }

    [Fact]
    public void CanDeserializeJsonToObject()
    {
        var input = "{\"some_string_property\":\"here is a string\",\"some_date_time_property\":\"2022-03-01T12:00:00\",\"some_decimal_property\":2.45}";
        var deserialized = JsonSerializer.Deserialize<SomeClass>(input, _options);
        deserialized.Should().NotBeNull();
        deserialized.SomeStringProperty.Should().Be("here is a string");
        deserialized.SomeDateTimeProperty.Should().Be(new DateTime(2022, 3, 1, 12, 0, 0));
        deserialized.SomeDecimalProperty.Should().Be(2.45m);
    }

    public record SomeClass(string SomeStringProperty, DateTime SomeDateTimeProperty, decimal SomeDecimalProperty);
}
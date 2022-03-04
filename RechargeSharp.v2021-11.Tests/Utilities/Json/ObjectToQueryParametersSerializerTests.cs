using System;
using System.Web;
using FluentAssertions;
using RechargeSharp.v2021_11.Utilities.Queries;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Utilities.Json;

public class ObjectToQueryParametersSerializerTests
{
    [Fact]
    public void CanSerializeObjectToQueryParameters()
    {
        var input = new SomeClass("here is a string", new DateTime(2022, 3, 1, 12, 0, 0), 2.45m);
        var asQueryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(input);
        asQueryString.Value.Should().NotBeNullOrEmpty();
        var parsedQueryString = HttpUtility.ParseQueryString(asQueryString.Value);
        parsedQueryString["some_string_property"].Should().Be(input.SomeStringProperty);
        parsedQueryString["some_date_time_property"].Should().Be("2022-03-01T12:00:00");
        parsedQueryString["some_decimal_property"].Should().Be(input.SomeDecimalProperty.ToString("F2"));
    }
    
    [Fact]
    public void CanSerializeObjectWithNullablePropertiesToQueryParameters()
    {
        var input = new SomeClassWithNullableProperties(null, null, 2.45m);
        var asQueryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(input);
        asQueryString.Value.Should().NotBeNullOrEmpty();
        var parsedQueryString = HttpUtility.ParseQueryString(asQueryString.Value);
        parsedQueryString["some_decimal_property"].Should().Be(input.SomeDecimalProperty.ToString("F2"));
    }

    [Fact]
    public void ThrowsOnComplexProperties()
    {
        var input = new SomeClassWithComplexProperties(new SomeClassWithComplexProperties(null, null), "some string");
        var act = new Action(() => ObjectToQueryStringSerializer.SerializeObjectToQueryString(input));
        act.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }
    
    public record SomeClass(string SomeStringProperty, DateTime SomeDateTimeProperty, decimal SomeDecimalProperty);
    public record SomeClassWithNullableProperties(string? SomeStringProperty, DateTime? SomeDateTimeProperty, decimal SomeDecimalProperty);
    
    public record SomeClassWithComplexProperties(SomeClassWithComplexProperties? SomeComplexProperty, string? SomeStringProperty);
}
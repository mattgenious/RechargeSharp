using FluentAssertions;
using RechargeSharp.v2021_11.Utilities.Json;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Utilities.Json;

public class StringExtensionsTests
{
    [Theory]
    [InlineData("Id", "id")]
    [InlineData("MyName", "my_name")]
    [InlineData("ExpectedDeliveryDate", "expected_delivery_date")]
    [InlineData("", "")]
    public void CanSnakeCaseStrings(string input, string expectedOutput)
    {
        var result = input.ToSnakeCase();
        result.Should().Be(expectedOutput);
    }
}
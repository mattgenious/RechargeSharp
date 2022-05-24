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
    [InlineData("SomeStringProperty", "some_string_property")]
    [InlineData("LolLolLolLol", "lol_lol_lol_lol")]
    [InlineData("lolLolLolLol", "lol_lol_lol_lol")]
    [InlineData("", "")]
    public void CanSnakeCaseStrings(string input, string expectedOutput)
    {
        var result = input.ToSnakeCase();
        result.Should().Be(expectedOutput);
    }
}
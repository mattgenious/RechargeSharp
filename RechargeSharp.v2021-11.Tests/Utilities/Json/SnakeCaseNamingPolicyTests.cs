using System;
using FluentAssertions;
using RechargeSharp.v2021_11.Utilities.Json;
using Xunit;

namespace RechargeSharp.v2021_11.Tests.Utilities.Json;

public class SnakeCaseNamingPolicyTests
{
    private readonly SnakeCaseNamingPolicy _sut;

    public SnakeCaseNamingPolicyTests()
    {
        _sut = new SnakeCaseNamingPolicy();
    }
    
    [Fact]
    public void EmptyStringDoesNotCauseAnException()
    {
        var act = () => { _sut.ConvertName(string.Empty); };
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("Id", "id")]
    [InlineData("Forename", "forename")]
    [InlineData("PeopleCarrier", "people_carrier")]
    [InlineData("MultiWordString", "multi_word_string")]
    public void InputStringIsReturnedInSnakeCase(string input, string expectedOutput)
    {
        var result = _sut.ConvertName(input);
        result.Should().Be(expectedOutput);
    }
}
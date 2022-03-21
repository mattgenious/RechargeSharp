using System.Text.Json;

namespace RechargeSharp.v2021_11.Utilities.Json;

/// <summary>
///     From: https://www.michaelrose.dev/posts/exploring-system-text-json/
/// </summary>
public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return name.ToSnakeCase();
    }
}
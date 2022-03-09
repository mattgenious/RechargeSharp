using System.Text.Json;
using System.Text.Json.Serialization;

namespace RechargeSharp.v2021_11.Utilities.Json;

/// <summary>
///     Modified version of: https://gist.github.com/marcominerva/8640e9d2e556fc78e3f3d079a207c778
/// </summary>
public class DateOnlyNullableConverter : JsonConverter<DateOnly?>
{
    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null)
            return null;
        return DateOnly.Parse(value!);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
    {
        if(value is not null)
            writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd"));
    }
}
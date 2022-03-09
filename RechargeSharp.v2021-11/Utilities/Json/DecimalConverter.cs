using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RechargeSharp.v2021_11.Utilities.Json;

public class DecimalConverter : JsonConverter<decimal?>
{
    public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null)
            return null;
        return decimal.Parse(value, NumberStyles.Any, DateTimeFormatInfo.InvariantInfo);
    }

    public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
    {
        if (value is not null)
            writer.WriteStringValue(value.Value.ToString(DateTimeFormatInfo.InvariantInfo));
    }
}
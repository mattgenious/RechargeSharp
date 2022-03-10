using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RechargeSharp.v2021_11.Utilities.Json;


public class DecimalNullableConverter : JsonConverter<decimal?>
{
    private readonly DecimalConverter _decimalNullableConverter = new DecimalConverter();
    
    public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null)
            return null;
        return _decimalNullableConverter.ParseAsDecimal(value);
;    }

    public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
    {
        if (value is not null)
            _decimalNullableConverter.Write(writer, value.Value, options);
    }
}

public class DecimalConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString()  ?? throw new InvalidOperationException("The decimal field could not be retrieved as a string");
        return ParseAsDecimal(value);
    }
    
    internal decimal ParseAsDecimal(string input)
    {
        return decimal.Parse(input, NumberStyles.Any, DateTimeFormatInfo.InvariantInfo);
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(DateTimeFormatInfo.InvariantInfo));
    }
}

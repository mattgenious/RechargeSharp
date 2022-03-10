using System.Text.Json;
using System.Text.Json.Serialization;

namespace RechargeSharp.v2021_11.Utilities.Json;

/// <summary>
///     Modified version of: https://gist.github.com/marcominerva/8640e9d2e556fc78e3f3d079a207c778
/// </summary>
public class DateOnlyNullableConverter : JsonConverter<DateOnly?>
{
    private readonly DateOnlyConverter _dateOnlyConverter  = new DateOnlyConverter();

    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null)
            return null;
        return _dateOnlyConverter.ParseAsDateOnly(value);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
    {
        if(value is not null)
            _dateOnlyConverter.Write(writer, value.Value, options);
    }
}

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return ParseAsDateOnly(reader.GetString() ?? throw new InvalidOperationException("The DateOnly field could not be retrieved as a string"));
    }

    internal DateOnly ParseAsDateOnly(string input)
    {
        return DateOnly.Parse(input);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }
}
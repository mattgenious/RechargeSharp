using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RechargeSharp.v2021_11.Entities.Errors;

public class ApiErrorJsonConverter : JsonConverter<ApiError>
{
    public ApiErrorJsonConverter()
    {
    }

    public override ApiError Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException();

        var apiError = new ApiError();
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        
        // The "errors" property can appear in both singular and plural
        if (jsonDocument.RootElement.TryGetProperty("errors", out var errors))
        {
            apiError.Errors = errors.Clone();
        }
        else if (jsonDocument.RootElement.TryGetProperty("error", out errors))
        {
            apiError.Errors = errors.Clone();
        }

        return apiError;
    }

    public override void Write(Utf8JsonWriter writer, ApiError value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object) value, options);
    }
}
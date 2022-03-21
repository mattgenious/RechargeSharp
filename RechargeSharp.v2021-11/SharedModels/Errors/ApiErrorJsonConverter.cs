using System.Text.Json;
using System.Text.Json.Serialization;

namespace RechargeSharp.v2021_11.SharedModels.Errors;

public class ApiErrorJsonConverter : JsonConverter<ApiError>
{
    public override ApiError Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException();

        ApiError apiError;
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        
        // The "errors" property can appear in both singular and plural
        if (jsonDocument.RootElement.TryGetProperty("errors", out var errors))
        {
            apiError = new ApiError() {ErrorsAsJson = errors.Clone()};
        }
        else if (jsonDocument.RootElement.TryGetProperty("error", out errors))
        {
            apiError = new ApiError() {ErrorsAsJson = errors.Clone()};
        }
        else
        {
            apiError = new ApiError()
            {
                RawErrorBody = jsonDocument.RootElement.ToString()
            };
        }

        return apiError;
    }

    public override void Write(Utf8JsonWriter writer, ApiError value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object) value, options);
    }
}
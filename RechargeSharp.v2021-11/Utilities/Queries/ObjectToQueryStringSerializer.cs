using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using Microsoft.AspNetCore.Http;
using RechargeSharp.v2021_11.Utilities.Json;

namespace RechargeSharp.v2021_11.Utilities.Queries;

public static class ObjectToQueryStringSerializer
{
    public static QueryString SerializeObjectToQueryString<T>(T instance) where T : class
    {
        var jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        var serialized = JsonSerializer.SerializeToDocument(instance, jsonSerializerOptions);

        var queryString = new QueryString();
        
        foreach (var jsonProperty in serialized.RootElement.EnumerateObject())
        {
            switch (jsonProperty.Value.ValueKind)
            {
                case JsonValueKind.Number:
                case JsonValueKind.String:
                case JsonValueKind.True:
                case JsonValueKind.False:
                case JsonValueKind.Null:
                    queryString = queryString.Add(jsonProperty.Name, jsonProperty.Value.ToString());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(jsonProperty.Value.ValueKind), "Serialization of this JSON type into query parameters has not been implemented");
            }
        }

        return queryString;
    }
}
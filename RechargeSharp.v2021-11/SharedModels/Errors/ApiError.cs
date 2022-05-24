using System.Text.Json;

namespace RechargeSharp.v2021_11.SharedModels.Errors;

public record ApiError
{
    /// <summary>
    ///     If the errors in the request body was JSON, this property will contain the deserialized body
    /// </summary>
    public JsonElement? ErrorsAsJson { get; init; }
    
    /// <summary>
    ///     If the request body with errors was *not* JSON, this property will contain the error body as a string
    /// </summary>
    public string? RawErrorBody { get; init; }
    
    public override string ToString()
    {
        return (ErrorsAsJson?.ToString() ?? RawErrorBody) ?? "(no errors was reported in the response data)";
    }

    public bool IsEntityNotFoundError() => ErrorsAsJson?.ValueEquals("Not Found") == true;
}
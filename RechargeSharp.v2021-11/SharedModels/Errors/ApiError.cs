using System.Text.Json;

namespace RechargeSharp.v2021_11.SharedModels.Errors;

public class ApiError
{
    public JsonElement? Errors { get; set; }
    
    public override string ToString()
    {
        return Errors?.ToString() ?? "(no errors was reported in the response data)";
    }

    public bool IsNotFoundError() => Errors?.ValueEquals("Not Found") == true;
}
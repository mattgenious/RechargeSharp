using System.Text.Json;

namespace RechargeSharp.v2021_11.Entities.Errors;

public class ApiError
{
    // TODO identify if this can be made into a simple Dictionary<string, string> - currently, I'm not sure if there can be duplicate keys or not, or complex objects
    public JsonElement? Errors { get; set; }
    
    //
    public override string ToString()
    {
        return Errors?.ToString() ?? "(no errors was reported in the response data)";
    }
}
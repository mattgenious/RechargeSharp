using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Customers
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CustomerStatus
    {
        [EnumMember(Value = "ACTIVE")]
        Active,
        [EnumMember(Value = "INACTIVE")]
        Inactive
    }
}

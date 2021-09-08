using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Orders
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus
    {
        [EnumMember(Value = "SUCCESS")]
        Success,
        [EnumMember(Value = "QUEUED")]
        Queued,
        [EnumMember(Value = "CANCELLED")]
        Cancelled,
        [EnumMember(Value = "ERROR")]
        Error,
        [EnumMember(Value = "REFUNDED")]
        Refunded,
        [EnumMember(Value = "SKIPPED")]
        Skipped
    }
}

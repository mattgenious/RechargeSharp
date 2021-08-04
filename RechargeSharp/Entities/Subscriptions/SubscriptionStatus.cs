using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Subscriptions
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SubscriptionStatus
    {

        [EnumMember(Value = "ACTIVE")]
        Active,
        [EnumMember(Value = "CANCELLED")]
        Cancelled,
        [EnumMember(Value = "EXPIRED")]
        Expired
    }
}

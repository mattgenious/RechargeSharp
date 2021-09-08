using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Discounts
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AppliesToProductType
    {
        [EnumMember(Value = "ALL")]
        All,
        [EnumMember(Value = "ONETIME")]
        Onetime,
        [EnumMember(Value = "SUBSCRIPTION")]
        Subscription
    }
}

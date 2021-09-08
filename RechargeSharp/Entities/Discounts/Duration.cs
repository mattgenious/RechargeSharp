using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Discounts
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Duration
    {
        [EnumMember(Value = "forever")]
        Forever,
        [EnumMember(Value = "usage_limit")]
        UsageLimit,
        [EnumMember(Value = "single_use")]
        SingleUse
    }
}

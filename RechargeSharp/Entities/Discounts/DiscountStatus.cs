using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Discounts
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DiscountStatus
    {
        [EnumMember(Value = "enabled")]
        Enabled,
        [EnumMember(Value = "disabled")]
        Disabled,
        [EnumMember(Value = "fully_disabled")]
        FullyDisabled
    }
}

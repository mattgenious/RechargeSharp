using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Discounts
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DiscountType
    {
        [EnumMember(Value = "percentage")]
        Percentage,
        [EnumMember(Value = "fixed_amount")] 
        FixedAmount
    }
}

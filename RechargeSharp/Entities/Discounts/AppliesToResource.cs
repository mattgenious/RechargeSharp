using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Discounts
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AppliesToResource
    {
        [EnumMember(Value = "shopify_product")]
        ShopifyProduct,
        [EnumMember(Value = "shopify_collection_id")]
        ShopifyCollectionId
    }
}

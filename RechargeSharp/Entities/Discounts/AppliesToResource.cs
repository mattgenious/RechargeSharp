using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Discounts
{
    public enum AppliesToResource
    {
        [EnumMember(Value = "shopify_product")]
        ShopifyProduct,
        [EnumMember(Value = "shopify_collection_id")]
        ShopifyCollectionId
    }
}

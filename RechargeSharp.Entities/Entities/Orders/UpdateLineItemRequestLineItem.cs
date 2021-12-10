using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Orders
{
    public class UpdateLineItemRequestLineItem : IEquatable<UpdateLineItemRequestLineItem>
    {
        public bool Equals(UpdateLineItemRequestLineItem? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Quantity == other.Quantity && ShopifyProductId == other.ShopifyProductId && ShopifyVariantId == other.ShopifyVariantId && Price == other.Price && ProductTitle == other.ProductTitle && Grams == other.Grams && Vendor == other.Vendor && Sku == other.Sku && VariantTitle == other.VariantTitle;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateLineItemRequestLineItem) obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Quantity);
            hash.Add(ShopifyProductId);
            hash.Add(ShopifyVariantId);
            hash.Add(Price);
            hash.Add(ProductTitle);
            hash.Add(Grams);
            hash.Add(Vendor);
            hash.Add(Sku);
            hash.Add(VariantTitle);
            return hash.ToHashCode();
        }

        public static bool operator ==(UpdateLineItemRequestLineItem left, UpdateLineItemRequestLineItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateLineItemRequestLineItem left, UpdateLineItemRequestLineItem right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        [Required]
        [JsonProperty("shopify_product_id ")]
        public long? ShopifyProductId { get; set; }

        [Required]
        [JsonProperty("shopify_variant_id ")]
        public long? ShopifyVariantId { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public string? Price { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Property>? Properties { get; set; }

        [JsonProperty("product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProductTitle { get; set; }

        [JsonProperty("grams", NullValueHandling = NullValueHandling.Ignore)]
        public long? Grams { get; set; }

        [JsonProperty("vendor", NullValueHandling = NullValueHandling.Ignore)]
        public string? Vendor { get; set; }

        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string? Sku { get; set; }

        [JsonProperty("variant_title", NullValueHandling = NullValueHandling.Ignore)]
        public string? VariantTitle { get; set; }
    }
}

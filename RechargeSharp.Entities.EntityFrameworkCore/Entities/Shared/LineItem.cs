using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Charges;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Orders;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Subscriptions;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Shared
{
    public class LineItem
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonIgnore]
        public virtual Subscription? Subscription { get; set; }

        [JsonIgnore]
        public virtual Order? Order { get; set; }

        [JsonIgnore]
        public virtual Charge? Charge { get; set; }

        [JsonProperty("images")]
        [NotMapped]
        public Images? Images { get; set; }

        [JsonProperty("properties")]
        [NotMapped]
        public ICollection<Property>? Properties { get; set; }

        [JsonProperty("grams")]
        public long Grams { get; set; }

        [JsonProperty("price")]
        public string? Price { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("shopify_product_id")]
        public long ShopifyProductId { get; set; }

        [JsonProperty("shopify_variant_id")]
        public string? ShopifyVariantId { get; set; }

        [JsonProperty("sku")]
        public string? Sku { get; set; }

        [JsonProperty("subscription_id")]
        public long SubscriptionId { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("variant_title")]
        public string? VariantTitle { get; set; }

        public bool Equals(LineItem other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Grams == other.Grams && Equals(Images, other.Images) && Price == other.Price && Quantity == other.Quantity && ShopifyProductId == other.ShopifyProductId && ShopifyVariantId == other.ShopifyVariantId && Sku == other.Sku && SubscriptionId == other.SubscriptionId && Title == other.Title && VariantTitle == other.VariantTitle;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LineItem)obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Grams);
            hash.Add(Images);
            hash.Add(Price);
            hash.Add(Quantity);
            hash.Add(ShopifyProductId);
            hash.Add(ShopifyVariantId);
            hash.Add(Sku);
            hash.Add(SubscriptionId);
            hash.Add(Title);
            hash.Add(VariantTitle);
            return hash.ToHashCode();
        }

        public static bool operator ==(LineItem left, LineItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LineItem left, LineItem right)
        {
            return !Equals(left, right);
        }
    }
}
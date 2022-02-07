using Newtonsoft.Json;
using RechargeSharp.Entities.Products;
using RechargeSharp.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Products
{
    public class Product : IEquatable<Product>
    {
        public bool Equals(Product? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return CollectionId == other.CollectionId && CreatedAt.Equals(other.CreatedAt) && DiscountAmount == other.DiscountAmount && DiscountType == other.DiscountType && Id == other.Id && Equals(Images, other.Images) && ProductId == other.ProductId && ShopifyProductId == other.ShopifyProductId && Equals(SubscriptionDefaults, other.SubscriptionDefaults) && Title == other.Title && UpdatedAt.Equals(other.UpdatedAt);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Product)obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(CollectionId);
            hash.Add(CreatedAt);
            hash.Add(DiscountAmount);
            hash.Add(DiscountType);
            hash.Add(Id);
            hash.Add(Images);
            hash.Add(ProductId);
            hash.Add(ShopifyProductId);
            hash.Add(SubscriptionDefaults);
            hash.Add(Title);
            hash.Add(UpdatedAt);
            return hash.ToHashCode();
        }

        public static bool operator ==(Product left, Product right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Product left, Product right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("collection_id")]
        public long CollectionId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("discount_amount")]
        public long DiscountAmount { get; set; }

        [JsonProperty("discount_type")]
        public string? DiscountType { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("images")]
        public Images? Images { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("shopify_product_id")]
        public long ShopifyProductId { get; set; }

        [JsonProperty("subscription_defaults")]
        [NotMapped]
        public ProductSubscriptionDefaults? SubscriptionDefaults { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}

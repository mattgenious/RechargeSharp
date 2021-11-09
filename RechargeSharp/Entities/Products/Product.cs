using System;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Products
{
    public class Product : IEquatable<Product>
    {
        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CollectionId == other.CollectionId && CreatedAt.Equals(other.CreatedAt) && DiscountAmount == other.DiscountAmount && DiscountType == other.DiscountType && Id == other.Id && Equals(Images, other.Images) && ProductId == other.ProductId && ShopifyProductId == other.ShopifyProductId && Equals(SubscriptionDefaults, other.SubscriptionDefaults) && Title == other.Title && UpdatedAt.Equals(other.UpdatedAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CollectionId.GetHashCode();
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ DiscountAmount.GetHashCode();
                hashCode = (hashCode * 397) ^ (DiscountType != null ? DiscountType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Images != null ? Images.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ProductId.GetHashCode();
                hashCode = (hashCode * 397) ^ ShopifyProductId.GetHashCode();
                hashCode = (hashCode * 397) ^ (SubscriptionDefaults != null ? SubscriptionDefaults.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                return hashCode;
            }
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
        public string DiscountType { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("shopify_product_id")]
        public long ShopifyProductId { get; set; }

        [JsonProperty("subscription_defaults")]
        public ProductSubscriptionDefaults SubscriptionDefaults { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}

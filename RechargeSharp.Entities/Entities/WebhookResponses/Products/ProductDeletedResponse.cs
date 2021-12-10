using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Products
{
    public class ProductDeletedResponse : IEquatable<ProductDeletedResponse>
    {
        public bool Equals(ProductDeletedResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Product, other.Product);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductDeletedResponse) obj);
        }

        public override int GetHashCode()
        {
            return Product?.GetHashCode() ?? 0;
        }

        public static bool operator ==(ProductDeletedResponse left, ProductDeletedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProductDeletedResponse left, ProductDeletedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("product")]
        public WebhookProductDeleted? Product { get; set; }
    }
}

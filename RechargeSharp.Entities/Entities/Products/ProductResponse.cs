using Newtonsoft.Json;

namespace RechargeSharp.Entities.Products
{
    public class ProductResponse : IEquatable<ProductResponse>
    {
        public bool Equals(ProductResponse? other)
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
            return Equals((ProductResponse) obj);
        }

        public override int GetHashCode()
        {
            return Product?.GetHashCode() ?? 0;
        }

        public static bool operator ==(ProductResponse left, ProductResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProductResponse left, ProductResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("product")]
        public Product? Product { get; set; }
    }
}

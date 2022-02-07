using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shop
{
    public class ShopResponse : IEquatable<ShopResponse>
    {
        public bool Equals(ShopResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Shop, other.Shop);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShopResponse) obj);
        }

        public override int GetHashCode()
        {
            return Shop?.GetHashCode() ?? 0;
        }

        public static bool operator ==(ShopResponse left, ShopResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ShopResponse left, ShopResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("shop")]
        public Shop? Shop { get; set; }
    }
}

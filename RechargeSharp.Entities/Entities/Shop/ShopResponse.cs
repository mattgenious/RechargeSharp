using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shop
{
    public class ShopResponse : IEquatable<ShopResponse>
    {
        public bool Equals(ShopResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Shop, other.Shop);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShopResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Shop != null ? Shop.GetHashCode() : 0);
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
        public Shop Shop { get; set; }
    }
}

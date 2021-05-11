using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Discounts
{
    class DiscountResponse : IEquatable<DiscountResponse>
    {
        public bool Equals(DiscountResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Discount, other.Discount);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DiscountResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Discount != null ? Discount.GetHashCode() : 0);
        }

        public static bool operator ==(DiscountResponse left, DiscountResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DiscountResponse left, DiscountResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("discount")]
        public Discount Discount { get; set; }
    }
}

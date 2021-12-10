using Newtonsoft.Json;

namespace RechargeSharp.Entities.Discounts
{
    public class DiscountResponse : IEquatable<DiscountResponse>
    {
        public bool Equals(DiscountResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Discount, other.Discount);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DiscountResponse) obj);
        }

        public override int GetHashCode()
        {
            return Discount?.GetHashCode() ?? 0;
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
        public Discount? Discount { get; set; }
    }
}

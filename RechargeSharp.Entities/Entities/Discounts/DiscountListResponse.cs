using Newtonsoft.Json;

namespace RechargeSharp.Entities.Discounts
{
    public class DiscountListResponse : IEquatable<DiscountListResponse>
    {
        public bool Equals(DiscountListResponse? other)
        {
            if (other is null) return false;
            if (other.Discounts is null) return false;
            if (Discounts is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Discounts.SequenceEqual(other.Discounts);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DiscountListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Discounts != null ? Discounts.GetHashCode() : 0);
        }

        public static bool operator ==(DiscountListResponse left, DiscountListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DiscountListResponse left, DiscountListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("discounts")]
        public IEnumerable<Discount>? Discounts { get; set; }
    }
}

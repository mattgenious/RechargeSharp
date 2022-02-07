using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class CheckoutAppliedDiscount : IEquatable<CheckoutAppliedDiscount>
    {
        public bool Equals(CheckoutAppliedDiscount? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount && Value == other.Value && ValueType == other.ValueType && Applicable == other.Applicable && NonApplicableReason == other.NonApplicableReason;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CheckoutAppliedDiscount) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Value, ValueType, Applicable, NonApplicableReason);
        }

        public static bool operator ==(CheckoutAppliedDiscount left, CheckoutAppliedDiscount right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CheckoutAppliedDiscount left, CheckoutAppliedDiscount right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Amount { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Value { get; set; }

        [JsonProperty("value_type", NullValueHandling = NullValueHandling.Ignore)]
        public string? ValueType { get; set; }

        [JsonProperty("applicable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Applicable { get; set; }

        [JsonProperty("non_applicable_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string? NonApplicableReason { get; set; }
    }
}

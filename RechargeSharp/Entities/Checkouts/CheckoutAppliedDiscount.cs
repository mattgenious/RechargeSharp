using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class CheckoutAppliedDiscount : IEquatable<CheckoutAppliedDiscount>
    {
        public bool Equals(CheckoutAppliedDiscount other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount && Value == other.Value && ValueType == other.ValueType && Applicable == other.Applicable && NonApplicableReason == other.NonApplicableReason;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CheckoutAppliedDiscount) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Amount.GetHashCode();
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
                hashCode = (hashCode * 397) ^ (ValueType != null ? ValueType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Applicable.GetHashCode();
                hashCode = (hashCode * 397) ^ (NonApplicableReason != null ? NonApplicableReason.GetHashCode() : 0);
                return hashCode;
            }
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
        public string ValueType { get; set; }

        [JsonProperty("applicable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Applicable { get; set; }

        [JsonProperty("non_applicable_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string NonApplicableReason { get; set; }
    }
}

using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    /// <summary>
    /// See documentation <see href="https://developer.rechargepayments.com/2021-01/charges/charge_object">https://developer.rechargepayments.com/2021-01/charges/charge_object</see>
    /// </summary>
    public class ChargeDiscountCode : IEquatable<ChargeDiscountCode>
    {
        public bool Equals(ChargeDiscountCode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount && Code == other.Code && Type == other.Type;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChargeDiscountCode) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Code, Type);
        }

        public static bool operator ==(ChargeDiscountCode left, ChargeDiscountCode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChargeDiscountCode left, ChargeDiscountCode right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("amount")]
        public string? Amount { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
    }
}

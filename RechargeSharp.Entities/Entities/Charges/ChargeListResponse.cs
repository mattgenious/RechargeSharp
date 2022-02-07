using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class ChargeListResponse : IEquatable<ChargeListResponse>
    {
        public bool Equals(ChargeListResponse? other)
        {
            if (other is null) return false;
            if (other.Charges is null) return false;
            if (Charges is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Charges.SequenceEqual(other.Charges);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChargeListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Charges != null ? Charges.GetHashCode() : 0);
        }

        public static bool operator ==(ChargeListResponse left, ChargeListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChargeListResponse left, ChargeListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("charges")]
        public IEnumerable<Charge>? Charges { get; set; }
    }
}

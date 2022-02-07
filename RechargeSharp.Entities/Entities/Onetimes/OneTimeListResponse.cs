using Newtonsoft.Json;

namespace RechargeSharp.Entities.Onetimes
{
    public class OnetimeListResponse : IEquatable<OnetimeListResponse>
    {
        public bool Equals(OnetimeListResponse? other)
        {
            if (other is null) return false;
            if (other.OneTimeProducts is null) return false;
            if (OneTimeProducts is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return OneTimeProducts.SequenceEqual(other.OneTimeProducts);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OnetimeListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (OneTimeProducts != null ? OneTimeProducts.GetHashCode() : 0);
        }

        public static bool operator ==(OnetimeListResponse left, OnetimeListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OnetimeListResponse left, OnetimeListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("onetimes")]
        public IEnumerable<Onetime>? OneTimeProducts { get; set; }
    }
}

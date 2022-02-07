using Newtonsoft.Json;

namespace RechargeSharp.Entities.Onetimes
{
    public class OnetimeResponse : IEquatable<OnetimeResponse>
    {
        public bool Equals(OnetimeResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(OneTimeProduct, other.OneTimeProduct);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OnetimeResponse) obj);
        }

        public override int GetHashCode()
        {
            return OneTimeProduct?.GetHashCode() ?? 0;
        }

        public static bool operator ==(OnetimeResponse left, OnetimeResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OnetimeResponse left, OnetimeResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("onetime")]
        public Onetime? OneTimeProduct { get; set; }
    }
}

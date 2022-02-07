using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class CountResponse : IEquatable<CountResponse>
    {
        public bool Equals(CountResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Count == other.Count;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CountResponse) obj);
        }

        public override int GetHashCode()
        {
            return Count.GetHashCode();
        }

        public static bool operator ==(CountResponse left, CountResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CountResponse left, CountResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("count")]
        public long Count { get; set; }
    }
}

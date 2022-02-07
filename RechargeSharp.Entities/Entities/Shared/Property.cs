using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class Property : IEquatable<Property>
    {
        public bool Equals(Property? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Name, other.Name) && Equals(Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Property) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Value != null ? Value.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Property left, Property right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Property left, Property right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("name")]
        public object? Name { get; set; }

        [JsonProperty("value")]
        public object? Value { get; set; }
    }
}

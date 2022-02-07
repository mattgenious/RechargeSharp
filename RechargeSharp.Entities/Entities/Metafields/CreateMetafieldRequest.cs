using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafields
{
    public class CreateMetafieldRequest : IEquatable<CreateMetafieldRequest>
    {
        public bool Equals(CreateMetafieldRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(MetafieldObject, other.MetafieldObject);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateMetafieldRequest) obj);
        }

        public override int GetHashCode()
        {
            return MetafieldObject?.GetHashCode() ?? 0;
        }

        public static bool operator ==(CreateMetafieldRequest left, CreateMetafieldRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateMetafieldRequest left, CreateMetafieldRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("metafield")]
        public CreateMetafieldObject? MetafieldObject { get; set; }
    }
}

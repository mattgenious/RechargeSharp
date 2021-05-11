using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafields
{
    public class MetafieldResponse : IEquatable<MetafieldResponse>
    {
        public bool Equals(MetafieldResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Metafield, other.Metafield);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MetafieldResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Metafield != null ? Metafield.GetHashCode() : 0);
        }

        public static bool operator ==(MetafieldResponse left, MetafieldResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MetafieldResponse left, MetafieldResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("metafield")]
        public Metafield Metafield { get; set; }
    }
}

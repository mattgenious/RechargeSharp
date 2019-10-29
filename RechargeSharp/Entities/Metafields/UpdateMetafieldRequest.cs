using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafields
{
    public class UpdateMetafieldRequest : IEquatable<UpdateMetafieldRequest>
    {
        public bool Equals(UpdateMetafieldRequest other)
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
            return Equals((UpdateMetafieldRequest) obj);
        }

        public override int GetHashCode()
        {
            return (Metafield != null ? Metafield.GetHashCode() : 0);
        }

        public static bool operator ==(UpdateMetafieldRequest left, UpdateMetafieldRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateMetafieldRequest left, UpdateMetafieldRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("metafield")]
        public UpdateMetafieldObject Metafield { get; set; }
    }
}

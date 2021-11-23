using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Collections
{
    public class CollectionResponse : IEquatable<CollectionResponse>
    {
        public bool Equals(CollectionResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Collection, other.Collection);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CollectionResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Collection != null ? Collection.GetHashCode() : 0);
        }

        public static bool operator ==(CollectionResponse left, CollectionResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CollectionResponse left, CollectionResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("collection")]
        public Collection Collection { get; set; }
    }
}

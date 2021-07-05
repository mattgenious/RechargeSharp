using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Onetimes
{
    public class OneTimeListResponse : IEquatable<OneTimeListResponse>
    {
        public bool Equals(OneTimeListResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return OneTimeProducts.SequenceEqual(other.OneTimeProducts);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OneTimeListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (OneTimeProducts != null ? OneTimeProducts.GetHashCode() : 0);
        }

        public static bool operator ==(OneTimeListResponse left, OneTimeListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OneTimeListResponse left, OneTimeListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("onetimes")]
        public IEnumerable<OneTime> OneTimeProducts { get; set; }
    }
}

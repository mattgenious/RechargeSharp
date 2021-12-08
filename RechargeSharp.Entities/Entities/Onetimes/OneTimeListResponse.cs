using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Onetimes
{
    public class OnetimeListResponse : IEquatable<OnetimeListResponse>
    {
        public bool Equals(OnetimeListResponse other)
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
        public IEnumerable<Onetime> OneTimeProducts { get; set; }
    }
}

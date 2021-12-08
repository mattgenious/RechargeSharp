using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Addresses
{
    public class AddressListResponse : IEquatable<AddressListResponse>
    {
        public bool Equals(AddressListResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Addresses.SequenceEqual(other.Addresses);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AddressListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Addresses != null ? Addresses.GetHashCode() : 0);
        }

        public static bool operator ==(AddressListResponse left, AddressListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddressListResponse left, AddressListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("addresses")]
        public IEnumerable<Address> Addresses { get; set; }
    }
}

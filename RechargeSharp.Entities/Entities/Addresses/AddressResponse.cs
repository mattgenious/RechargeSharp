using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Addresses
{
    public class AddressResponse : IEquatable<AddressResponse>
    {
        public bool Equals(AddressResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Address, other.Address);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AddressResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Address != null ? Address.GetHashCode() : 0);
        }

        public static bool operator ==(AddressResponse left, AddressResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddressResponse left, AddressResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}

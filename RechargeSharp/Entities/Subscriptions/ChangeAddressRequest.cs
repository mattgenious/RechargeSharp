using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class ChangeAddressRequest : IEquatable<ChangeAddressRequest>
    {
        public bool Equals(ChangeAddressRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AddressId == other.AddressId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChangeAddressRequest) obj);
        }

        public override int GetHashCode()
        {
            return AddressId.GetHashCode();
        }

        public static bool operator ==(ChangeAddressRequest left, ChangeAddressRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChangeAddressRequest left, ChangeAddressRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address_id")]
        public long AddressId { get; set; }
    }
}

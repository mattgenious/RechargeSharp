using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Addresses
{
    public class AddressUpdatedResponse : IEquatable<AddressUpdatedResponse>
    {
        public bool Equals(AddressUpdatedResponse other)
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
            return Equals((AddressUpdatedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Address != null ? Address.GetHashCode() : 0);
        }

        public static bool operator ==(AddressUpdatedResponse left, AddressUpdatedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddressUpdatedResponse left, AddressUpdatedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address")]
        public WebhookAddress Address { get; set; }
    }
}

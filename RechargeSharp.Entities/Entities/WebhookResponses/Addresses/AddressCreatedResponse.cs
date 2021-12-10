using Newtonsoft.Json;
using RechargeSharp.Entities.Addresses;

namespace RechargeSharp.Entities.WebhookResponses.Addresses
{
    public class AddressCreatedResponse : IEquatable<AddressCreatedResponse>
    {
        public bool Equals(AddressCreatedResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Address, other.Address);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AddressCreatedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Address?.GetHashCode() ?? 0);
        }

        public static bool operator ==(AddressCreatedResponse left, AddressCreatedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddressCreatedResponse left, AddressCreatedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address")]
        public Address? Address { get; set; }
    }
}

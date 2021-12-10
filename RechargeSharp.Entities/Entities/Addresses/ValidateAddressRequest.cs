using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Addresses
{
    public class ValidateAddressRequest : IEquatable<ValidateAddressRequest>
    {
        public bool Equals(ValidateAddressRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Address1 == other.Address1 && State == other.State && Zipcode == other.Zipcode && City == other.City;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ValidateAddressRequest) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Address1, State, Zipcode, City);
        }

        public static bool operator ==(ValidateAddressRequest left, ValidateAddressRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValidateAddressRequest left, ValidateAddressRequest right)
        {
            return !Equals(left, right);
        }


        [Required]
        [JsonProperty("address1")]
        public string? Address1 { get; set; }

        [Required]
        [JsonProperty("state")]
        public string? State { get; set; }

        [Required]
        [JsonProperty("zipcode")]
        public string? Zipcode { get; set; }

        [Required]
        [JsonProperty("city")]
        public string? City { get; set; }
    }
}

using Newtonsoft.Json;

namespace RechargeSharp.Entities.Addresses
{
    public class ValidateAddressErrors : IEquatable<ValidateAddressErrors>
    {
        public bool Equals(ValidateAddressErrors? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return City == other.City && State == other.State && StateName == other.StateName && Zipcode == other.Zipcode;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ValidateAddressErrors) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(City, State, StateName, Zipcode);
        }

        public static bool operator ==(ValidateAddressErrors left, ValidateAddressErrors right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValidateAddressErrors left, ValidateAddressErrors right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("state_name")]
        public string? StateName { get; set; }

        [JsonProperty("zipcode")]
        public string? Zipcode { get; set; }
    }
}
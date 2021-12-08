using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Addresses
{
    public class ValidateAddressErrors : IEquatable<ValidateAddressErrors>
    {
        public bool Equals(ValidateAddressErrors other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return City == other.City && State == other.State && StateName == other.StateName && Zipcode == other.Zipcode;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ValidateAddressErrors) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StateName != null ? StateName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Zipcode != null ? Zipcode.GetHashCode() : 0);
                return hashCode;
            }
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
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("state_name")]
        public string StateName { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }
    }
}
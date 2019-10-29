using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Addresses
{
    public class ValidateAddressRequest : IEquatable<ValidateAddressRequest>
    {
        public bool Equals(ValidateAddressRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Address1 == other.Address1 && State == other.State && Zipcode == other.Zipcode && City == other.City;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ValidateAddressRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Address1 != null ? Address1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Zipcode != null ? Zipcode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(ValidateAddressRequest left, ValidateAddressRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValidateAddressRequest left, ValidateAddressRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}

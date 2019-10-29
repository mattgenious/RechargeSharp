using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Addresses
{
    public class ValidateAddressResponse : IEquatable<ValidateAddressResponse>
    {
        public bool Equals(ValidateAddressResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return City == other.City && Errors == other.Errors && State == other.State && StateName == other.StateName && Zipcode == other.Zipcode;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ValidateAddressResponse) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Errors != null ? Errors.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StateName != null ? StateName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Zipcode.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(ValidateAddressResponse left, ValidateAddressResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValidateAddressResponse left, ValidateAddressResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("errors")]
        public ValidateAddressErrors Errors { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("state_name")]
        public string StateName { get; set; }

        [JsonProperty("zipcode")]
        public long Zipcode { get; set; }
    }
}

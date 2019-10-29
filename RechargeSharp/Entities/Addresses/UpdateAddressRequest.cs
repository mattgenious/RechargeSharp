using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Addresses
{
    public class UpdateAddressRequest : IEquatable<UpdateAddressRequest>
    {
        public bool Equals(UpdateAddressRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Address1 == other.Address1 && Address2 == other.Address2 && City == other.City && Province == other.Province && FirstName == other.FirstName && LastName == other.LastName && Zip == other.Zip && Company == other.Company && Phone == other.Phone && Country == other.Country && OriginalShippingLines.SequenceEqual(other.OriginalShippingLines) && ShippingLinesOverride.SequenceEqual(other.ShippingLinesOverride);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateAddressRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Address1 != null ? Address1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Address2 != null ? Address2.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Province != null ? Province.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Zip.GetHashCode();
                hashCode = (hashCode * 397) ^ (Company != null ? Company.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OriginalShippingLines != null ? OriginalShippingLines.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShippingLinesOverride != null ? ShippingLinesOverride.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(UpdateAddressRequest left, UpdateAddressRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateAddressRequest left, UpdateAddressRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address1", NullValueHandling = NullValueHandling.Ignore)]
        public string Address1 { get; set; }

        [JsonProperty("address2", NullValueHandling = NullValueHandling.Ignore)]
        public string Address2 { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("province", NullValueHandling = NullValueHandling.Ignore)]
        public string Province { get; set; }

        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        public long? Zip { get; set; }

        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        public string Company { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("original_shipping_lines", NullValueHandling = NullValueHandling.Ignore)]
        public List<ShippingLine> OriginalShippingLines { get; set; }

        [JsonProperty("shipping_lines_override", NullValueHandling = NullValueHandling.Ignore)]
        public List<ShippingLine> ShippingLinesOverride { get; set; }
    }
}

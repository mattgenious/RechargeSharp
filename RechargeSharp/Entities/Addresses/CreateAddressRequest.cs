using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Addresses
{
    public class CreateAddressRequest : IEquatable<CreateAddressRequest>
    {
        public bool Equals(CreateAddressRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Address1 == other.Address1 && Address2 == other.Address2 && City == other.City && Province == other.Province && FirstName == other.FirstName && LastName == other.LastName && Zip == other.Zip && Company == other.Company && Phone == other.Phone && Country == other.Country && OriginalShippingLines.SequenceEqual(other.OriginalShippingLines) && ShippingLinesOverride.SequenceEqual(other.ShippingLinesOverride) && CartNote == other.CartNote;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateAddressRequest) obj);
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
                hashCode = (hashCode * 397) ^ (Zip != null ? Zip.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Company != null ? Company.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OriginalShippingLines != null ? OriginalShippingLines.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShippingLinesOverride != null ? ShippingLinesOverride.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CartNote != null ? CartNote.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(CreateAddressRequest left, CreateAddressRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateAddressRequest left, CreateAddressRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2", NullValueHandling = NullValueHandling.Ignore)]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        public string Company { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("original_shipping_lines", NullValueHandling = NullValueHandling.Ignore)]
        public List<ShippingLine> OriginalShippingLines { get; set; }

        [JsonProperty("shipping_lines_override", NullValueHandling = NullValueHandling.Ignore)]
        public List<ShippingLine> ShippingLinesOverride { get; set; }
        [JsonProperty("cart_note", NullValueHandling = NullValueHandling.Ignore)]
        public string CartNote { get; set; }
    }
}

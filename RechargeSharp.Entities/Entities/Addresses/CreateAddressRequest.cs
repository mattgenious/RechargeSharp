using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Addresses
{
    public class CreateAddressRequest : IEquatable<CreateAddressRequest>
    {


        [Required]
        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2", NullValueHandling = NullValueHandling.Ignore)]
        public string Address2 { get; set; }

        [Required]
        [JsonProperty("city")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = true)]
        [JsonProperty("province")]
        public string Province { get; set; }
        
        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        public string Company { get; set; }

        [Required]
        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cart_note", NullValueHandling = NullValueHandling.Ignore)]
        public string CartNote { get; set; }

        [Required]
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("shipping_lines_override", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ShippingLine> ShippingLinesOverride { get; set; }

        public bool Equals(CreateAddressRequest other)
        {
	        if (ReferenceEquals(null, other)) return false;
	        if (ReferenceEquals(this, other)) return true;
	        return Address1 == other.Address1 && Address2 == other.Address2 && City == other.City && Province == other.Province && FirstName == other.FirstName && LastName == other.LastName && Zip == other.Zip && Company == other.Company && Phone == other.Phone && CartNote == other.CartNote && Country == other.Country;
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
	        var hashCode = new HashCode();
	        hashCode.Add(Address1);
	        hashCode.Add(Address2);
	        hashCode.Add(City);
	        hashCode.Add(Province);
	        hashCode.Add(FirstName);
	        hashCode.Add(LastName);
	        hashCode.Add(Zip);
	        hashCode.Add(Company);
	        hashCode.Add(Phone);
	        hashCode.Add(CartNote);
	        hashCode.Add(Country);
	        return hashCode.ToHashCode();
        }

        public static bool operator ==(CreateAddressRequest left, CreateAddressRequest right)
        {
	        return Equals(left, right);
        }

        public static bool operator !=(CreateAddressRequest left, CreateAddressRequest right)
        {
	        return !Equals(left, right);
        }
    }
}

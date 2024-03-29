﻿using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Addresses
{
    public class UpdateAddressRequest : IEquatable<UpdateAddressRequest>
    {
        public bool Equals(UpdateAddressRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Address1 == other.Address1 && Address2 == other.Address2 && City == other.City && Province == other.Province && FirstName == other.FirstName && LastName == other.LastName && Zip == other.Zip && Company == other.Company && Phone == other.Phone && Country == other.Country;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateAddressRequest) obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Address1);
            hash.Add(Address2);
            hash.Add(City);
            hash.Add(Province);
            hash.Add(FirstName);
            hash.Add(LastName);
            hash.Add(Zip);
            hash.Add(Company);
            hash.Add(Phone);
            hash.Add(Country);
            return hash.ToHashCode();
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
        public string? Address1 { get; set; }

        [JsonProperty("address2", NullValueHandling = NullValueHandling.Ignore)]
        public string? Address2 { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string? City { get; set; }

        [JsonProperty("province", NullValueHandling = NullValueHandling.Ignore)]
        public string? Province { get; set; }

        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? FirstName { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? LastName { get; set; }

        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        public string? Zip { get; set; }

        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        public string? Company { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string? Phone { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string? Country { get; set; }

        [JsonProperty("original_shipping_lines", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ShippingLine>? OriginalShippingLines { get; set; }

        [JsonProperty("shipping_lines_override", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ShippingLine>? ShippingLinesOverride { get; set; }
    }
}

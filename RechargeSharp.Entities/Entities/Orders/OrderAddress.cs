﻿using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Orders
{
    public class OrderAddress : IEquatable<OrderAddress>
    {
        public bool Equals(OrderAddress? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Address1 == other.Address1 && Address2 == other.Address2 && City == other.City && Company == other.Company && Country == other.Country && FirstName == other.FirstName && LastName == other.LastName && Phone == other.Phone && Province == other.Province && Zip == other.Zip;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderAddress) obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Address1);
            hash.Add(Address2);
            hash.Add(City);
            hash.Add(Company);
            hash.Add(Country);
            hash.Add(FirstName);
            hash.Add(LastName);
            hash.Add(Phone);
            hash.Add(Province);
            hash.Add(Zip);
            return hash.ToHashCode();
        }

        public static bool operator ==(OrderAddress left, OrderAddress right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OrderAddress left, OrderAddress right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address1", NullValueHandling = NullValueHandling.Ignore)]
        public string? Address1 { get; set; }

        [JsonProperty("address2", NullValueHandling = NullValueHandling.Ignore)]
        public string? Address2 { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string? City { get; set; }

        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        public string? Company { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string? Country { get; set; }

        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? FirstName { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? LastName { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string? Phone { get; set; }

        [Required(AllowEmptyStrings = true)]
        [JsonProperty("province")]
        public string? Province { get; set; }

        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        public string? Zip { get; set; }
    }
}

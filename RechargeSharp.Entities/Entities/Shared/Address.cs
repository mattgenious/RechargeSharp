using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class Address : IEquatable<Address>
    {
        public bool Equals(Address? other)
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
            return Equals((Address) obj);
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

        public static bool operator ==(Address left, Address right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Address left, Address right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("address1")]
        public string? Address1 { get; set; }

        [JsonProperty("address2", NullValueHandling = NullValueHandling.Ignore)]
        public string? Address2 { get; set; }

        [Required]
        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("company")]
        public string? Company { get; set; }

        [Required]
        [JsonProperty("country")]
        public string? Country { get; set; }

        [Required]
        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        [Required]
        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        [Required]
        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("province")]
        public string? Province { get; set; }

        [Required]
        [JsonProperty("zip")]
        public string? Zip { get; set; }
    }
}

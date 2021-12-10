using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Addresses
{
    public class Address : IEquatable<Address>
    {
        public bool Equals(Address? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Address1 == other.Address1 && Address2 == other.Address2 && CartNote == other.CartNote && City == other.City && Company == other.Company && Country == other.Country && CreatedAt.Equals(other.CreatedAt) && CustomerId == other.CustomerId && DiscountId == other.DiscountId && FirstName == other.FirstName && Id == other.Id && LastName == other.LastName && Phone == other.Phone && Province == other.Province && UpdatedAt.Equals(other.UpdatedAt) && Zip == other.Zip;
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
            hash.Add(CartNote);
            hash.Add(City);
            hash.Add(Company);
            hash.Add(Country);
            hash.Add(CreatedAt);
            hash.Add(CustomerId);
            hash.Add(DiscountId);
            hash.Add(FirstName);
            hash.Add(Id);
            hash.Add(LastName);
            hash.Add(Phone);
            hash.Add(Province);
            hash.Add(UpdatedAt);
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


        [JsonProperty("address1")]
        public string? Address1 { get; set; }

        [JsonProperty("address2")]
        public string? Address2 { get; set; }

        [JsonProperty("cart_attributes")]
        public IEnumerable<Property>? CartAttributes { get; set; }

        [JsonProperty("cart_note")]
        public string? CartNote { get; set; }

        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("company")]
        public string? Company { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("discount_id")]
        public long? DiscountId { get; set; }

        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        [JsonProperty("note_attributes")]
        public IEnumerable<Property>? NoteAttributes { get; set; }

        [JsonProperty("original_shipping_lines")]
        public IEnumerable<ShippingLine>? OriginalShippingLines { get; set; }

        [JsonProperty("shipping_lines_override")]
        public IEnumerable<ShippingLine>? ShippingLinesOverride { get; set; }

        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("province")]
        public string? Province { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("zip")]
        public string? Zip { get; set; }
    }
}

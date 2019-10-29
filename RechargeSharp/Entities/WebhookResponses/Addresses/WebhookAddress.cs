using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.WebhookResponses.Addresses
{
    public class WebhookAddress : IEquatable<WebhookAddress>
    {
        public bool Equals(WebhookAddress other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && CustomerId == other.CustomerId && Nullable.Equals(CreatedAt, other.CreatedAt) && Nullable.Equals(UpdatedAt, other.UpdatedAt) && Address1 == other.Address1 && Address2 == other.Address2 && City == other.City && Province == other.Province && FirstName == other.FirstName && LastName == other.LastName && Zip == other.Zip && Company == other.Company && Phone == other.Phone && Country == other.Country && CartNote == other.CartNote && DiscountId == other.DiscountId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookAddress) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ CustomerId.GetHashCode();
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (Address1 != null ? Address1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Address2.GetHashCode();
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Province != null ? Province.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Zip.GetHashCode();
                hashCode = (hashCode * 397) ^ (Company != null ? Company.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CartNote != null ? CartNote.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DiscountId.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(WebhookAddress left, WebhookAddress right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookAddress left, WebhookAddress right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public long Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("zip")]
        public long Zip { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("cart_note")]
        public string CartNote { get; set; }

        [JsonProperty("original_shipping_lines")]
        public List<ShippingLine> OriginalShippingLines { get; set; }

        [JsonProperty("cart_attributes")]
        public List<Property> CartAttributes { get; set; }

        [JsonProperty("note_attributes")]
        public List<Property> NoteAttributes { get; set; }

        [JsonProperty("discount_id")]
        public long? DiscountId { get; set; }
    }
}

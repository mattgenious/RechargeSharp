using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Checkouts
{
    public class UpdateCheckoutRequest : IEquatable<UpdateCheckoutRequest>
    {
        public bool Equals(UpdateCheckoutRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(ShippingAddress, other.ShippingAddress) && Equals(BillingAddress, other.BillingAddress) && Email == other.Email && Note == other.Note && DiscountCode == other.DiscountCode && Phone == other.Phone && BuyerAcceptsMarketing == other.BuyerAcceptsMarketing;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateCheckoutRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ShippingAddress != null ? ShippingAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingAddress != null ? BillingAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Note != null ? Note.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DiscountCode != null ? DiscountCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ BuyerAcceptsMarketing.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(UpdateCheckoutRequest left, UpdateCheckoutRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateCheckoutRequest left, UpdateCheckoutRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("line_items", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<CreateCheckoutRequestLineItem> LineItems { get; set; }

        [JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public Address ShippingAddress { get; set; }

        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Address BillingAddress { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; set; }

        [JsonProperty("note_attributes", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Property> NoteAttributes { get; set; }

        [JsonProperty("shipping_line", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ShippingLine> ShippingLine { get; set; }

        [JsonProperty("discount_code", NullValueHandling = NullValueHandling.Ignore)]
        public string DiscountCode { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty("buyer_accepts_marketing", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BuyerAcceptsMarketing { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Checkouts
{
    public class Checkout : IEquatable<Checkout>
    {
        public bool Equals(Checkout other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AppliedDiscount == other.AppliedDiscount && BillingAddress == other.BillingAddress && BuyerAcceptsMarketing == other.BuyerAcceptsMarketing && Nullable.Equals(CompletedAt, other.CompletedAt) && Nullable.Equals(CreatedAt, other.CreatedAt) && DiscountCode == other.DiscountCode && Email == other.Email && LineItems.SequenceEqual(other.LineItems) && Note == other.Note && NoteAttributes.SequenceEqual(other.NoteAttributes) && Phone == other.Phone && RequiresShipping == other.RequiresShipping && ShippingAddress == other.ShippingAddress && ShippingLine == other.ShippingLine && ShippingRate.SequenceEqual(other.ShippingRate) && SubtotalPrice == other.SubtotalPrice && TaxLines.SequenceEqual(other.TaxLines) && TaxesIncluded == other.TaxesIncluded && Token == other.Token && TotalPrice == other.TotalPrice && TotalTax == other.TotalTax && Nullable.Equals(UpdatedAt, other.UpdatedAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Checkout) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (AppliedDiscount != null ? AppliedDiscount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingAddress != null ? BillingAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ BuyerAcceptsMarketing.GetHashCode();
                hashCode = (hashCode * 397) ^ CompletedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (DiscountCode != null ? DiscountCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LineItems != null ? LineItems.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Note != null ? Note.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (NoteAttributes != null ? NoteAttributes.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ RequiresShipping.GetHashCode();
                hashCode = (hashCode * 397) ^ (ShippingAddress != null ? ShippingAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShippingLine != null ? ShippingLine.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShippingRate != null ? ShippingRate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SubtotalPrice != null ? SubtotalPrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TaxLines != null ? TaxLines.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TaxesIncluded.GetHashCode();
                hashCode = (hashCode * 397) ^ (Token != null ? Token.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TotalPrice != null ? TotalPrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TotalTax != null ? TotalTax.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Checkout left, Checkout right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Checkout left, Checkout right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("applied_discount")]
        public CheckoutAppliedDiscount AppliedDiscount { get; set; }

        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("buyer_accepts_marketing")]
        public bool BuyerAcceptsMarketing { get; set; }

        [JsonProperty("completed_at")]
        public DateTime? CompletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("discount_code")]
        public string DiscountCode { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("line_items")]
        public CheckoutLineItem[] LineItems { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("note_attributes")]
        public Dictionary<string, string> NoteAttributes { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("requires_shipping")]
        public bool RequiresShipping { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("shipping_line")]
        public ShippingLine ShippingLine { get; set; }

        [JsonProperty("shipping_rate")]
        public ShippingRate[] ShippingRate { get; set; }

        [JsonProperty("subtotal_price")]
        public string SubtotalPrice { get; set; }

        [JsonProperty("tax_lines")]
        public TaxLine[] TaxLines { get; set; }

        [JsonProperty("taxes_included")]
        public bool TaxesIncluded { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("total_price")]
        public string TotalPrice { get; set; }

        [JsonProperty("total_tax")]
        public string TotalTax { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}

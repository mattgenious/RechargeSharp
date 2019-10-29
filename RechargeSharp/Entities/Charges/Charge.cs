using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Charges
{
    public class Charge : IEquatable<Charge>
    {
        public bool Equals(Charge other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AddressId == other.AddressId && BillingAddress == other.BillingAddress && ClientDetails == other.ClientDetails && Nullable.Equals(CreatedAt, other.CreatedAt) && CustomerHash == other.CustomerHash && CustomerId == other.CustomerId && DiscountCodes.SequenceEqual(other.DiscountCodes) && Email == other.Email && FirstName == other.FirstName && HasUncommitedChanges == other.HasUncommitedChanges && Id == other.Id && LastName == other.LastName && LineItems.SequenceEqual(other.LineItems) && Note == other.Note && NoteAttributes.SequenceEqual(other.NoteAttributes) && Nullable.Equals(ScheduledAt, other.ScheduledAt) && ShipmentsCount == other.ShipmentsCount && Equals(ShippingAddress, other.ShippingAddress) && ShippingLines.SequenceEqual(other.ShippingLines) && ShopifyOrderId == other.ShopifyOrderId && Status == other.Status && SubTotal == other.SubTotal && SubtotalPrice == other.SubtotalPrice && Tags == other.Tags && TaxLines == other.TaxLines && TotalDiscounts == other.TotalDiscounts && TotalLineItemsPrice == other.TotalLineItemsPrice && TotalPrice == other.TotalPrice && TotalRefunds == other.TotalRefunds && TotalTax == other.TotalTax && TotalWeight == other.TotalWeight && TransactionId == other.TransactionId && Type == other.Type && Nullable.Equals(UpdatedAt, other.UpdatedAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Charge)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = AddressId.GetHashCode();
                hashCode = (hashCode * 397) ^ (BillingAddress != null ? BillingAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ClientDetails != null ? ClientDetails.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (CustomerHash != null ? CustomerHash.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CustomerId.GetHashCode();
                hashCode = (hashCode * 397) ^ (DiscountCodes != null ? DiscountCodes.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ HasUncommitedChanges.GetHashCode();
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LineItems != null ? LineItems.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Note != null ? Note.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (NoteAttributes != null ? NoteAttributes.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ScheduledAt.GetHashCode();
                hashCode = (hashCode * 397) ^ ShipmentsCount.GetHashCode();
                hashCode = (hashCode * 397) ^ (ShippingAddress != null ? ShippingAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShippingLines != null ? ShippingLines.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ShopifyOrderId.GetHashCode();
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SubTotal != null ? SubTotal.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SubtotalPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ (Tags != null ? Tags.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TaxLines.GetHashCode();
                hashCode = (hashCode * 397) ^ (TotalDiscounts != null ? TotalDiscounts.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TotalLineItemsPrice != null ? TotalLineItemsPrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TotalPrice != null ? TotalPrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TotalRefunds != null ? TotalRefunds.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TotalTax.GetHashCode();
                hashCode = (hashCode * 397) ^ TotalWeight.GetHashCode();
                hashCode = (hashCode * 397) ^ (TransactionId != null ? TransactionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Charge left, Charge right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Charge left, Charge right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [JsonProperty("billing_address")]
        public Shared.Address BillingAddress { get; set; }

        [JsonProperty("client_details")]
        public ClientDetails ClientDetails { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("customer_hash")]
        public string CustomerHash { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("discount_codes")]
        public List<DiscountCode> DiscountCodes { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("has_uncommited_changes")]
        public bool HasUncommitedChanges { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("note_attributes")]
        public Property[] NoteAttributes { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTime? ScheduledAt { get; set; }

        [JsonProperty("shipments_count")]
        public long? ShipmentsCount { get; set; }

        [JsonProperty("shipping_address")]
        public Shared.Address ShippingAddress { get; set; }

        [JsonProperty("shipping_lines")]
        public List<ShippingLine> ShippingLines { get; set; }

        [JsonProperty("shopify_order_id")]
        public long? ShopifyOrderId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("sub_total")]
        public string SubTotal { get; set; }

        [JsonProperty("subtotal_price")]
        public decimal? SubtotalPrice { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("tax_lines")]
        public decimal TaxLines { get; set; }

        [JsonProperty("total_discounts")]
        public string TotalDiscounts { get; set; }

        [JsonProperty("total_line_items_price")]
        public string TotalLineItemsPrice { get; set; }

        [JsonProperty("total_price")]
        public string TotalPrice { get; set; }

        [JsonProperty("total_refunds")]
        public string TotalRefunds { get; set; }

        [JsonProperty("total_tax")]
        public decimal TotalTax { get; set; }

        [JsonProperty("total_weight")]
        public decimal TotalWeight { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}

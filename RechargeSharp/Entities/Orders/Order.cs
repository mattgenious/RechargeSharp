using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Orders
{
    public class Order : IEquatable<Order>
    {
        public bool Equals(Order other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AddressId == other.AddressId && AddressIsActive == other.AddressIsActive && Equals(BillingAddress, other.BillingAddress) && ChargeId == other.ChargeId && ChargeStatus == other.ChargeStatus && Nullable.Equals(CreatedAt, other.CreatedAt) && CustomerId == other.CustomerId && Email == other.Email && FirstName == other.FirstName && Hash == other.Hash && Id == other.Id && IsPrepaid == other.IsPrepaid && LastName == other.LastName && LineItems.SequenceEqual(other.LineItems) && Note == other.Note && NoteAttributes.SequenceEqual(other.NoteAttributes) && PaymentProcessor == other.PaymentProcessor && Nullable.Equals(ProcessedAt, other.ProcessedAt) && Nullable.Equals(ScheduledAt, other.ScheduledAt) && Nullable.Equals(ShippedDate, other.ShippedDate) && Equals(ShippingAddress, other.ShippingAddress) && Nullable.Equals(ShippingDate, other.ShippingDate) && ShippingLines.SequenceEqual(other.ShippingLines) && ShopifyCartToken == other.ShopifyCartToken && ShopifyId == other.ShopifyId && ShopifyOrderId == other.ShopifyOrderId && ShopifyOrderNumber == other.ShopifyOrderNumber && Status == other.Status && SubtotalPrice == other.SubtotalPrice && Tags == other.Tags && TaxLines.SequenceEqual(other.TaxLines) && TotalDiscounts == other.TotalDiscounts && TotalLineItemsPrice == other.TotalLineItemsPrice && TotalPrice == other.TotalPrice && TotalRefunds == other.TotalRefunds && TotalTax == other.TotalTax && TotalWeight == other.TotalWeight && TransactionId == other.TransactionId && Type == other.Type && Nullable.Equals(UpdatedAt, other.UpdatedAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Order) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = AddressId.GetHashCode();
                hashCode = (hashCode * 397) ^ AddressIsActive.GetHashCode();
                hashCode = (hashCode * 397) ^ (BillingAddress != null ? BillingAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ChargeId.GetHashCode();
                hashCode = (hashCode * 397) ^ (ChargeStatus != null ? ChargeStatus.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ CustomerId.GetHashCode();
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Hash != null ? Hash.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ IsPrepaid.GetHashCode();
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LineItems != null ? LineItems.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Note != null ? Note.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (NoteAttributes != null ? NoteAttributes.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PaymentProcessor != null ? PaymentProcessor.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ProcessedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ ScheduledAt.GetHashCode();
                hashCode = (hashCode * 397) ^ ShippedDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (ShippingAddress != null ? ShippingAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ShippingDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (ShippingLines != null ? ShippingLines.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShopifyCartToken != null ? ShopifyCartToken.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShopifyId != null ? ShopifyId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShopifyOrderId != null ? ShopifyOrderId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ShopifyOrderNumber.GetHashCode();
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SubtotalPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ (Tags != null ? Tags.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TaxLines != null ? TaxLines.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TotalDiscounts.GetHashCode();
                hashCode = (hashCode * 397) ^ TotalLineItemsPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ TotalPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ (TotalRefunds != null ? TotalRefunds.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TotalTax.GetHashCode();
                hashCode = (hashCode * 397) ^ TotalWeight.GetHashCode();
                hashCode = (hashCode * 397) ^ (TransactionId != null ? TransactionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Order left, Order right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Order left, Order right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [JsonProperty("address_is_active")]
        public long AddressIsActive { get; set; }

        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("charge_id")]
        public long ChargeId { get; set; }

        [JsonProperty("charge_status")]
        public string ChargeStatus { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_prepaid")]
        public long IsPrepaid { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("note_attributes")]
        public Property[] NoteAttributes { get; set; }

        [JsonProperty("payment_processor")]
        public string PaymentProcessor { get; set; }

        [JsonProperty("processed_at")]
        public DateTime? ProcessedAt { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTime? ScheduledAt { get; set; }

        [JsonProperty("shipped_date")]
        public DateTime? ShippedDate { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("shipping_date")]
        public DateTime? ShippingDate { get; set; }

        [JsonProperty("shipping_lines")]
        public List<ShippingLine> ShippingLines { get; set; }

        [JsonProperty("shopify_cart_token")]
        public string ShopifyCartToken { get; set; }

        [JsonProperty("shopify_id")]
        public string ShopifyId { get; set; }

        [JsonProperty("shopify_order_id")]
        public string ShopifyOrderId { get; set; }

        [JsonProperty("shopify_order_number")]
        public long? ShopifyOrderNumber { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("subtotal_price")]
        public long SubtotalPrice { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("tax_lines")]
        public List<TaxLine> TaxLines { get; set; }

        [JsonProperty("total_discounts")]
        public long TotalDiscounts { get; set; }

        [JsonProperty("total_line_items_price")]
        public long TotalLineItemsPrice { get; set; }

        [JsonProperty("total_price")]
        public long TotalPrice { get; set; }

        [JsonProperty("total_refunds")]
        public string TotalRefunds { get; set; }

        [JsonProperty("total_tax")]
        public long TotalTax { get; set; }

        [JsonProperty("total_weight")]
        public long TotalWeight { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}

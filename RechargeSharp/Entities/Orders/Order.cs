using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Orders
{
    public class Order : IEquatable<Order>
    {
	    [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [JsonProperty("address_is_active")]
        public long? AddressIsActive { get; set; }

        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("charge_id")]
        public long? ChargeId { get; set; }

        [JsonProperty("charge_status")]
        public string ChargeStatus { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

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
        public IEnumerable<LineItem> LineItems { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("note_attributes")]
        public IEnumerable<Property> NoteAttributes { get; set; }

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
        public IEnumerable<ShippingLine> ShippingLines { get; set; }

        [JsonProperty("shopify_cart_token")]
        public string ShopifyCartToken { get; set; }

        [JsonProperty("shopify_id")]
        public string ShopifyId { get; set; }

        [JsonProperty("shopify_order_id")]
        public string ShopifyOrderId { get; set; }

        [JsonProperty("shopify_order_number")]
        public long? ShopifyOrderNumber { get; set; }

        [JsonProperty("status")]
        public OrderStatus? Status { get; set; }

        [JsonProperty("subtotal_price")]
        public decimal? SubtotalPrice { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("tax_lines")]
        public IEnumerable<TaxLine> TaxLines { get; set; }

        [JsonProperty("total_discounts")]
        public decimal? TotalDiscounts { get; set; }

        [JsonProperty("total_line_items_price")]
        public decimal? TotalLineItemsPrice { get; set; }

        [JsonProperty("total_price")]
        public decimal? TotalPrice { get; set; }

        [JsonProperty("total_refunds")]
        public decimal? TotalRefunds { get; set; }

        [JsonProperty("total_tax")]
        public decimal? TotalTax { get; set; }

        [JsonProperty("total_weight")]
        public decimal? TotalWeight { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public bool Equals(Order other)
        {
	        if (ReferenceEquals(null, other)) return false;
	        if (ReferenceEquals(this, other)) return true;
	        return AddressId == other.AddressId && AddressIsActive == other.AddressIsActive && Equals(BillingAddress, other.BillingAddress) && ChargeId == other.ChargeId && ChargeStatus == other.ChargeStatus && CreatedAt.Equals(other.CreatedAt) && CustomerId == other.CustomerId && Email == other.Email && FirstName == other.FirstName && Hash == other.Hash && Id == other.Id && IsPrepaid == other.IsPrepaid && LastName == other.LastName && Note == other.Note && PaymentProcessor == other.PaymentProcessor && Nullable.Equals(ProcessedAt, other.ProcessedAt) && Nullable.Equals(ScheduledAt, other.ScheduledAt) && Nullable.Equals(ShippedDate, other.ShippedDate) && Equals(ShippingAddress, other.ShippingAddress) && Nullable.Equals(ShippingDate, other.ShippingDate) && ShopifyCartToken == other.ShopifyCartToken && ShopifyId == other.ShopifyId && ShopifyOrderId == other.ShopifyOrderId && ShopifyOrderNumber == other.ShopifyOrderNumber && Status == other.Status && SubtotalPrice == other.SubtotalPrice && Tags == other.Tags && TotalDiscounts == other.TotalDiscounts && TotalLineItemsPrice == other.TotalLineItemsPrice && TotalPrice == other.TotalPrice && TotalRefunds == other.TotalRefunds && TotalTax == other.TotalTax && TotalWeight == other.TotalWeight && TransactionId == other.TransactionId && Type == other.Type && UpdatedAt.Equals(other.UpdatedAt);
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
	        var hashCode = new HashCode();
	        hashCode.Add(AddressId);
	        hashCode.Add(AddressIsActive);
	        hashCode.Add(BillingAddress);
	        hashCode.Add(ChargeId);
	        hashCode.Add(ChargeStatus);
	        hashCode.Add(CreatedAt);
	        hashCode.Add(CustomerId);
	        hashCode.Add(Email);
	        hashCode.Add(FirstName);
	        hashCode.Add(Hash);
	        hashCode.Add(Id);
	        hashCode.Add(IsPrepaid);
	        hashCode.Add(LastName);
	        hashCode.Add(Note);
	        hashCode.Add(PaymentProcessor);
	        hashCode.Add(ProcessedAt);
	        hashCode.Add(ScheduledAt);
	        hashCode.Add(ShippedDate);
	        hashCode.Add(ShippingAddress);
	        hashCode.Add(ShippingDate);
	        hashCode.Add(ShopifyCartToken);
	        hashCode.Add(ShopifyId);
	        hashCode.Add(ShopifyOrderId);
	        hashCode.Add(ShopifyOrderNumber);
	        hashCode.Add(Status);
	        hashCode.Add(SubtotalPrice);
	        hashCode.Add(Tags);
	        hashCode.Add(TotalDiscounts);
	        hashCode.Add(TotalLineItemsPrice);
	        hashCode.Add(TotalPrice);
	        hashCode.Add(TotalRefunds);
	        hashCode.Add(TotalTax);
	        hashCode.Add(TotalWeight);
	        hashCode.Add(TransactionId);
	        hashCode.Add(Type);
	        hashCode.Add(UpdatedAt);
	        return hashCode.ToHashCode();
        }
    }
}

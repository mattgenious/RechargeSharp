using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Orders
{
    class Order
    {
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
        public DateTimeOffset CreatedAt { get; set; }

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
        public DateTimeOffset ProcessedAt { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTimeOffset ScheduledAt { get; set; }

        [JsonProperty("shipped_date")]
        public DateTimeOffset ShippedDate { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("shipping_date")]
        public DateTimeOffset ShippingDate { get; set; }

        [JsonProperty("shipping_lines")]
        public List<ShippingLine> ShippingLines { get; set; }

        [JsonProperty("shopify_cart_token")]
        public string ShopifyCartToken { get; set; }

        [JsonProperty("shopify_id")]
        public string ShopifyId { get; set; }

        [JsonProperty("shopify_order_id")]
        public string ShopifyOrderId { get; set; }

        [JsonProperty("shopify_order_number")]
        public long ShopifyOrderNumber { get; set; }

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
        public DateTimeOffset UpdatedAt { get; set; }
    }
}

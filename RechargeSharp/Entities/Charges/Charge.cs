using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Charges
{
    public class Charge
    {
        [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [JsonProperty("billing_address")]
        public Shared.Address BillingAddress { get; set; }

        [JsonProperty("client_details")]
        public ClientDetails ClientDetails { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

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
        public DateTimeOffset ScheduledAt { get; set; }

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
        public DateTimeOffset UpdatedAt { get; set; }
    }
}

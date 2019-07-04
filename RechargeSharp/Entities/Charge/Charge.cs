using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Charge
{
    class Charge
    {
        [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("client_details")]
        public ClientDetails ClientDetails { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("customer_hash")]
        public string CustomerHash { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("discount_codes")]
        public List<object> DiscountCodes { get; set; }

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
        public object NoteAttributes { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTimeOffset ScheduledAt { get; set; }

        [JsonProperty("shipments_count")]
        public object ShipmentsCount { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("shipping_lines")]
        public List<ShippingLine> ShippingLines { get; set; }

        [JsonProperty("shopify_order_id")]
        public object ShopifyOrderId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("sub_total")]
        public object SubTotal { get; set; }

        [JsonProperty("subtotal_price")]
        public long SubtotalPrice { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("tax_lines")]
        public long TaxLines { get; set; }

        [JsonProperty("total_discounts")]
        public string TotalDiscounts { get; set; }

        [JsonProperty("total_line_items_price")]
        public string TotalLineItemsPrice { get; set; }

        [JsonProperty("total_price")]
        public string TotalPrice { get; set; }

        [JsonProperty("total_refunds")]
        public object TotalRefunds { get; set; }

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

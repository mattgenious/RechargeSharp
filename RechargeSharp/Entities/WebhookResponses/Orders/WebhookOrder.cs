using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.WebhookResponses.Orders
{
    public class WebhookOrder
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("charge_status")]
        public string ChargeStatus { get; set; }

        [JsonProperty("payment_processor")]
        public string PaymentProcessor { get; set; }

        [JsonProperty("address_is_active")]
        public long AddressIsActive { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("charge_id")]
        public long ChargeId { get; set; }

        [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [JsonProperty("shopify_id")]
        public string ShopifyId { get; set; }

        [JsonProperty("shopify_order_id")]
        public string ShopifyOrderId { get; set; }

        [JsonProperty("shopify_order_number")]
        public long ShopifyOrderNumber { get; set; }

        [JsonProperty("shopify_cart_token")]
        public string ShopifyCartToken { get; set; }

        [JsonProperty("shipping_date")]
        public DateTime? ShippingDate { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTime? ScheduledAt { get; set; }

        [JsonProperty("shipped_date")]
        public DateTime? ShippedDate { get; set; }

        [JsonProperty("processed_at")]
        public DateTime? ProcessedAt { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("is_prepaid")]
        public long IsPrepaid { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; }

        [JsonProperty("total_price")]
        public string TotalPrice { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }
    }
}

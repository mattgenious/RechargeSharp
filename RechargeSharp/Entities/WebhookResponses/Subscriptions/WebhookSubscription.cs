using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.WebhookResponses.Subscriptions
{
    public class WebhookSubscription
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("address_id")]
        public long? AddressId { get; set; }

        [JsonProperty("customer_id")]
        public long? CustomerId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("next_charge_scheduled_at")]
        public DateTimeOffset? NextChargeScheduledAt { get; set; }

        [JsonProperty("cancelled_at")]
        public DateTimeOffset? CancelledAt { get; set; }

        [JsonProperty("product_title")]
        public string ProductTitle { get; set; }

        [JsonProperty("variant_title")]
        public string VariantTitle { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("recharge_product_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? RechargeProductId { get; set; }

        [JsonProperty("shopify_product_id")]
        public long? ShopifyProductId { get; set; }

        [JsonProperty("shopify_variant_id")]
        public long? ShopifyVariantId { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("order_interval_unit")]
        public string OrderIntervalUnit { get; set; }

        [JsonProperty("order_interval_frequency")]
        public string OrderIntervalFrequency { get; set; }

        [JsonProperty("charge_interval_frequency")]
        public string ChargeIntervalFrequency { get; set; }

        [JsonProperty("cancellation_reason")]
        public string CancellationReason { get; set; }

        [JsonProperty("cancellation_reason_comments")]
        public string CancellationReasonComments { get; set; }

        [JsonProperty("order_day_of_week")]
        public long? OrderDayOfWeek { get; set; }

        [JsonProperty("order_day_of_month")]
        public long? OrderDayOfMonth { get; set; }

        [JsonProperty("properties")]
        public List<Property> Properties { get; set; }

        [JsonProperty("expire_after_specific_number_of_charges")]
        public long? ExpireAfterSpecificNumberOfCharges { get; set; }

        [JsonProperty("max_retries_reached")]
        public long? MaxRetriesReached { get; set; }

        [JsonProperty("has_queued_charges")]
        public long? HasQueuedCharges { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities
{
    public class Subscription
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("address_id")]
        public long? AddressId { get; set; }

        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public long CustomerId { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("next_charge_scheduled_at", NullValueHandling = NullValueHandling.Include)]
        public DateTimeOffset? NextChargeScheduledAt { get; set; }

        [JsonProperty("cancelled_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CancelledAt { get; set; }

        [JsonProperty("product_title")]
        public string ProductTitle { get; set; }

        [JsonProperty("variant_title")]
        public string VariantTitle { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("shopify_product_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShopifyProductId { get; set; }

        [JsonProperty("shopify_variant_id")]
        public long ShopifyVariantId { get; set; }

        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; set; }

        [JsonProperty("order_interval_unit")]
        public string OrderIntervalUnit { get; set; }

        [JsonProperty("order_interval_frequency")]
        public string OrderIntervalFrequency { get; set; }

        [JsonProperty("charge_interval_frequency")]
        public string ChargeIntervalFrequency { get; set; }

        [JsonProperty("cancellation_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string CancellationReason { get; set; }

        [JsonProperty("cancellation_reason_comments", NullValueHandling = NullValueHandling.Ignore)]
        public string CancellationReasonComments { get; set; }

        [JsonProperty("order_day_of_week", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfWeek { get; set; }

        [JsonProperty("order_day_of_month", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfMonth { get; set; }

        [JsonProperty("properties")]
        public Property[] Properties { get; set; }

        [JsonProperty("expire_after_specific_number_of_charges", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpireAfterSpecificNumberOfCharges { get; set; }

        [JsonProperty("max_retries_reached", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxRetriesReached { get; set; }

        [JsonProperty("has_queued_charges", NullValueHandling = NullValueHandling.Ignore)]
        public long? HasQueuedCharges { get; set; }
        [JsonProperty("commit_update", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CommitUpdate { get; set; }
    }
}

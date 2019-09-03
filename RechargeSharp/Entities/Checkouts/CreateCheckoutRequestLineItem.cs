using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Checkouts
{
    public class CreateCheckoutRequestLineItem
    {
        [JsonProperty("charge_interval_frequency", NullValueHandling = NullValueHandling.Ignore)]
        public long? ChargeIntervalFrequency { get; set; }

        [JsonProperty("cutoff_day_of_month", NullValueHandling = NullValueHandling.Ignore)]
        public long? CutoffDayOfMonth { get; set; }

        [JsonProperty("cutoff_day_of_week", NullValueHandling = NullValueHandling.Ignore)]
        public long? CutoffDayOfWeek { get; set; }

        [JsonProperty("expire_after_specific_number_of_charges", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpireAfterSpecificNumberOfCharges { get; set; }

        [JsonProperty("fulfillment_service", NullValueHandling = NullValueHandling.Ignore)]
        public string FulfillmentService { get; set; }

        [JsonProperty("grams", NullValueHandling = NullValueHandling.Ignore)]
        public long? Grams { get; set; }

        [JsonProperty("line_price", NullValueHandling = NullValueHandling.Ignore)]
        public string LinePrice { get; set; }

        [JsonProperty("order_day_of_month", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfMonth { get; set; }

        [JsonProperty("order_day_of_week", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfWeek { get; set; }

        [JsonProperty("order_interval_frequency", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderIntervalFrequency { get; set; }

        [JsonProperty("order_interval_unit", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderIntervalUnit { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public string Price { get; set; }

        [JsonProperty("product_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProductId { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public Property[] Properties { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("requires_shipping", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RequiresShipping { get; set; }

        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; set; }

        [JsonProperty("taxable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Taxable { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("variant_id")]
        public long VariantId { get; set; }

        [JsonProperty("variant_title", NullValueHandling = NullValueHandling.Ignore)]
        public string VariantTitle { get; set; }

        [JsonProperty("vendor", NullValueHandling = NullValueHandling.Ignore)]
        public string Vendor { get; set; }
    }
}

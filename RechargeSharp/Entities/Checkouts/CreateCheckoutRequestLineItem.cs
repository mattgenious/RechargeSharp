using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Checkouts
{
    public class CreateCheckoutRequestLineItem
    {
        [JsonProperty("charge_interval_frequency")]
        public long ChargeIntervalFrequency { get; set; }

        [JsonProperty("cutoff_day_of_month")]
        public long CutoffDayOfMonth { get; set; }

        [JsonProperty("cutoff_day_of_week")]
        public long CutoffDayOfWeek { get; set; }

        [JsonProperty("expire_after_specific_number_of_charges")]
        public long ExpireAfterSpecificNumberOfCharges { get; set; }

        [JsonProperty("fulfillment_service")]
        public string FulfillmentService { get; set; }

        [JsonProperty("grams")]
        public long Grams { get; set; }

        [JsonProperty("line_price")]
        public string LinePrice { get; set; }

        [JsonProperty("order_day_of_month")]
        public long OrderDayOfMonth { get; set; }

        [JsonProperty("order_day_of_week")]
        public long OrderDayOfWeek { get; set; }

        [JsonProperty("order_interval_frequency")]
        public long OrderIntervalFrequency { get; set; }

        [JsonProperty("order_interval_unit")]
        public string OrderIntervalUnit { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("properties")]
        public Property[] Properties { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("requires_shipping")]
        public bool RequiresShipping { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("taxable")]
        public bool Taxable { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("variant_id")]
        public long VariantId { get; set; }

        [JsonProperty("variant_title")]
        public string VariantTitle { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }
    }
}

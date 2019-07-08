using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    class SubscriptionDefaults
    {
        [JsonProperty("charge_interval_frequency")]
        public long ChargeIntervalFrequency { get; set; }

        [JsonProperty("cutoff_day_of_month")]
        public long CutoffDayOfMonth { get; set; }

        [JsonProperty("cutoff_day_of_week")]
        public long CutoffDayOfWeek { get; set; }

        [JsonProperty("expire_after_specific_number_of_charges")]
        public long ExpireAfterSpecificNumberOfCharges { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonProperty("number_charges_until_expiration")]
        public long NumberChargesUntilExpiration { get; set; }

        [JsonProperty("order_day_of_month")]
        public long OrderDayOfMonth { get; set; }

        [JsonProperty("order_day_of_week")]
        public string OrderDayOfWeek { get; set; }

        [JsonProperty("order_interval_frequency")]
        public long OrderIntervalFrequency { get; set; }

        [JsonProperty("order_interval_frequency_options")]
        public List<long> OrderIntervalFrequencyOptions { get; set; }

        [JsonProperty("order_interval_unit")]
        public string OrderIntervalUnit { get; set; }

        [JsonProperty("storefront_purchase_options")]
        public string StorefrontPurchaseOptions { get; set; }
    }
}

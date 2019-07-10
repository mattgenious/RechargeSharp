using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks.Charges
{
    class ChargeFailed : Entities.Charges.Charge
    {
        [JsonProperty("last_charge_attempt_date")]
        public DateTimeOffset LastChargeAttemptDate { get; set; }

        [JsonProperty("retry_date")]
        public DateTimeOffset RetryDate { get; set; }

        [JsonProperty("number_times_tried")]
        public long NumberTimesTried { get; set; }

        [JsonProperty("shopify_variant_id_not_found")]
        public string ShopifyVariantIdNotFound { get; set; }

        [JsonProperty("error_type")]
        public string ErrorType { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}

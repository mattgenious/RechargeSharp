﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Charges;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class WebhookChargeMaxRetriesReached : Charge
    {
        [JsonProperty("last_charge_attempt_date")]
        public DateTime? LastChargeAttemptDate { get; set; }

        [JsonProperty("retry_date")]
        public DateTime? RetryDate { get; set; }

        [JsonProperty("number_times_tried")]
        public long NumberTimesTried { get; set; }

        [JsonProperty("shopify_variant_id_not_found")]
        public object ShopifyVariantIdNotFound { get; set; }

        [JsonProperty("error_type")]
        public string ErrorType { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}

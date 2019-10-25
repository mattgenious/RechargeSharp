using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class CancelSubscriptionRequest
    {
        [JsonProperty("cancellation_reason")]
        public string CancellationReason { get; set; }
        [JsonProperty("cancellation_reason_comments", NullValueHandling = NullValueHandling.Ignore)]
        public string CancellationReasonComments { get; set; }

        [JsonProperty("send_email", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SendEmail { get; set; }
    }
}

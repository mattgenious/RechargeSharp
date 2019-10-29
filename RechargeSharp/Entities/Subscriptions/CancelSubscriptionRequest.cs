using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class CancelSubscriptionRequest : IEquatable<CancelSubscriptionRequest>
    {
        public bool Equals(CancelSubscriptionRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CancellationReason == other.CancellationReason && CancellationReasonComments == other.CancellationReasonComments && SendEmail == other.SendEmail;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CancelSubscriptionRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (CancellationReason != null ? CancellationReason.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CancellationReasonComments != null ? CancellationReasonComments.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SendEmail.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(CancelSubscriptionRequest left, CancelSubscriptionRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CancelSubscriptionRequest left, CancelSubscriptionRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("cancellation_reason")]
        public string CancellationReason { get; set; }
        [JsonProperty("cancellation_reason_comments", NullValueHandling = NullValueHandling.Ignore)]
        public string CancellationReasonComments { get; set; }

        [JsonProperty("send_email", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SendEmail { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class CancelSubscriptionRequest : IEquatable<CancelSubscriptionRequest>
    {
        public bool Equals(CancelSubscriptionRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return CancellationReason == other.CancellationReason && CancellationReasonComments == other.CancellationReasonComments && SendEmail == other.SendEmail;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CancelSubscriptionRequest) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CancellationReason, CancellationReasonComments, SendEmail);
        }

        public static bool operator ==(CancelSubscriptionRequest left, CancelSubscriptionRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CancelSubscriptionRequest left, CancelSubscriptionRequest right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("cancellation_reason")]
        public string? CancellationReason { get; set; }

        [JsonProperty("cancellation_reason_comments", NullValueHandling = NullValueHandling.Ignore)]
        public string? CancellationReasonComments { get; set; }

        [JsonProperty("send_email", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SendEmail { get; set; }
    }
}

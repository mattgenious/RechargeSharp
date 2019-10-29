using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Charges;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class WebhookChargePaid : Charge, IEquatable<WebhookChargePaid>
    {
        public bool Equals(WebhookChargePaid other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && ProcessorName == other.ProcessorName && Nullable.Equals(ProcessedAt, other.ProcessedAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookChargePaid) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (ProcessorName != null ? ProcessorName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ProcessedAt.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(WebhookChargePaid left, WebhookChargePaid right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookChargePaid left, WebhookChargePaid right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("processor_name")]
        public string ProcessorName { get; set; }

        [JsonProperty("processed_at")]
        public DateTime? ProcessedAt { get; set; }
    }
}

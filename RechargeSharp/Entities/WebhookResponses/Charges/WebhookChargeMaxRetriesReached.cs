using System;
using Newtonsoft.Json;
using RechargeSharp.Entities.Charges;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class WebhookChargeMaxRetriesReached : Charge, IEquatable<WebhookChargeMaxRetriesReached>
    {
        public bool Equals(WebhookChargeMaxRetriesReached other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Nullable.Equals(LastChargeAttemptDate, other.LastChargeAttemptDate) && Nullable.Equals(RetryDate, other.RetryDate) && NumberTimesTried == other.NumberTimesTried && Equals(ShopifyVariantIdNotFound, other.ShopifyVariantIdNotFound) && ErrorType == other.ErrorType && Error == other.Error;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookChargeMaxRetriesReached) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ LastChargeAttemptDate.GetHashCode();
                hashCode = (hashCode * 397) ^ RetryDate.GetHashCode();
                hashCode = (hashCode * 397) ^ NumberTimesTried.GetHashCode();
                hashCode = (hashCode * 397) ^ (ShopifyVariantIdNotFound != null ? ShopifyVariantIdNotFound.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ErrorType != null ? ErrorType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Error != null ? Error.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(WebhookChargeMaxRetriesReached left, WebhookChargeMaxRetriesReached right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookChargeMaxRetriesReached left, WebhookChargeMaxRetriesReached right)
        {
            return !Equals(left, right);
        }

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

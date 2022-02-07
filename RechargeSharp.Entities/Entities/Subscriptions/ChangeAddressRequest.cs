using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class ChangeAddressRequest : IEquatable<ChangeAddressRequest>
    {
        public bool Equals(ChangeAddressRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return AddressId == other.AddressId && Nullable.Equals(NextChargeScheduledAt, other.NextChargeScheduledAt);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChangeAddressRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (AddressId.GetHashCode() * 397) ^ NextChargeScheduledAt.GetHashCode();
            }
        }

        public static bool operator ==(ChangeAddressRequest left, ChangeAddressRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChangeAddressRequest left, ChangeAddressRequest right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Id of the new address
        /// </summary>
        [Required]
        [JsonProperty("address_id")]
        public long? AddressId { get; set; }

        /// <summary>
        /// Optionally the next charge date if different than current next charge date
        /// </summary>
        [JsonProperty("next_charge_scheduled_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? NextChargeScheduledAt { get; set; }
    }
}

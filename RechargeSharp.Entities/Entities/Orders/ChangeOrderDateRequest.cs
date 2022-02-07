using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Orders
{
    public class ChangeOrderDateRequest : IEquatable<ChangeOrderDateRequest>
    {
        public bool Equals(ChangeOrderDateRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Nullable.Equals(ScheduledAt, other.ScheduledAt);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChangeOrderDateRequest) obj);
        }

        public override int GetHashCode()
        {
            return ScheduledAt.GetHashCode();
        }

        public static bool operator ==(ChangeOrderDateRequest left, ChangeOrderDateRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChangeOrderDateRequest left, ChangeOrderDateRequest right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("scheduled_at")]
        public DateTimeOffset? ScheduledAt { get; set; }
    }
}

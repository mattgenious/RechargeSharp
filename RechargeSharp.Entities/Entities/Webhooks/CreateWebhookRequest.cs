using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class CreateWebhookRequest : IEquatable<CreateWebhookRequest>
    {
        public bool Equals(CreateWebhookRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Address == other.Address && Topic == other.Topic;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateWebhookRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Address != null ? Address.GetHashCode() : 0) * 397) ^ (Topic != null ? Topic.GetHashCode() : 0);
            }
        }

        public static bool operator ==(CreateWebhookRequest left, CreateWebhookRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateWebhookRequest left, CreateWebhookRequest right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("address")]
        public string? Address { get; set; }

        [Required]
        [JsonProperty("topic")]
        public string? Topic { get; set; }
    }
}

using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class Webhook : IEquatable<Webhook>
    {
        public bool Equals(Webhook? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Address, other.Address) && Id == other.Id && Topic == other.Topic;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Webhook) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Address, Id, Topic);
        }

        public static bool operator ==(Webhook left, Webhook right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Webhook left, Webhook right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address")]
        public Uri? Address { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("topic")]
        public WebhookTopic? Topic { get; set; }
    }
}

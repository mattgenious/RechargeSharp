using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Rulesets
{
    public class RulesetCreatedResponse : IEquatable<RulesetCreatedResponse>
    {
        public bool Equals(RulesetCreatedResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Ruleset, other.Ruleset);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RulesetCreatedResponse) obj);
        }

        public override int GetHashCode()
        {
            return Ruleset?.GetHashCode() ?? 0;
        }

        public static bool operator ==(RulesetCreatedResponse left, RulesetCreatedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RulesetCreatedResponse left, RulesetCreatedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("ruleset")]
        public WebhookRuleset? Ruleset { get; set; }
    }
}

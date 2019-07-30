using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Rulesets
{
    public class RulesetCreatedResponse
    {
        [JsonProperty("ruleset")]
        public WebhookRuleset Ruleset { get; set; }
    }
}

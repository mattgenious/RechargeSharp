﻿using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class ChargeCreatedResponse : IEquatable<ChargeCreatedResponse>
    {
        public bool Equals(ChargeCreatedResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Charge, other.Charge);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChargeCreatedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Charge != null ? Charge.GetHashCode() : 0);
        }

        public static bool operator ==(ChargeCreatedResponse left, ChargeCreatedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChargeCreatedResponse left, ChargeCreatedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("charge")]
        public WebhookChargeCreated Charge { get; set; }
    }
}

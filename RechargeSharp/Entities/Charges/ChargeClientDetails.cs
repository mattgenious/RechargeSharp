﻿using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class ChargeClientDetails : IEquatable<ChargeClientDetails>
    {
        public bool Equals(ChargeClientDetails other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return BrowserIp == other.BrowserIp && UserAgent == other.UserAgent;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChargeClientDetails) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((BrowserIp != null ? BrowserIp.GetHashCode() : 0) * 397) ^ (UserAgent != null ? UserAgent.GetHashCode() : 0);
            }
        }

        public static bool operator ==(ChargeClientDetails left, ChargeClientDetails right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChargeClientDetails left, ChargeClientDetails right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("browser_ip")]
        public string BrowserIp { get; set; }

        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }
    }
}
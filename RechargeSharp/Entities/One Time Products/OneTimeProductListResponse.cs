using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.One_Time_Products
{
    public class OneTimeProductListResponse : IEquatable<OneTimeProductListResponse>
    {
        public bool Equals(OneTimeProductListResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return OneTimeProducts.SequenceEqual(other.OneTimeProducts);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OneTimeProductListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (OneTimeProducts != null ? OneTimeProducts.GetHashCode() : 0);
        }

        public static bool operator ==(OneTimeProductListResponse left, OneTimeProductListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OneTimeProductListResponse left, OneTimeProductListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("onetimes")]
        public List<OneTimeProduct> OneTimeProducts { get; set; }
    }
}

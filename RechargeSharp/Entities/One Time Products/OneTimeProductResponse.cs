using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.One_Time_Products
{
    public class OneTimeProductResponse : IEquatable<OneTimeProductResponse>
    {
        public bool Equals(OneTimeProductResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(OneTimeProduct, other.OneTimeProduct);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OneTimeProductResponse) obj);
        }

        public override int GetHashCode()
        {
            return (OneTimeProduct != null ? OneTimeProduct.GetHashCode() : 0);
        }

        public static bool operator ==(OneTimeProductResponse left, OneTimeProductResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OneTimeProductResponse left, OneTimeProductResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("onetime")]
        public OneTimeProduct OneTimeProduct { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Products
{
    public class ProductListResponse : IEquatable<ProductListResponse>
    {
        public bool Equals(ProductListResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Products.SequenceEqual(other.Products);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Products != null ? Products.GetHashCode() : 0);
        }

        public static bool operator ==(ProductListResponse left, ProductListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProductListResponse left, ProductListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("products")]
        public IEnumerable<Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Orders
{
    public class UpdateLineItemsRequest : IEquatable<UpdateLineItemsRequest>
    {
        public bool Equals(UpdateLineItemsRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return LineItems.SequenceEqual(other.LineItems);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateLineItemsRequest) obj);
        }

        public override int GetHashCode()
        {
            return (LineItems != null ? LineItems.GetHashCode() : 0);
        }

        public static bool operator ==(UpdateLineItemsRequest left, UpdateLineItemsRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateLineItemsRequest left, UpdateLineItemsRequest right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("line_items")]
        public IEnumerable<UpdateLineItemRequestLineItem> LineItems { get; set; }
    }
}

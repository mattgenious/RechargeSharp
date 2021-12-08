using Newtonsoft.Json;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Customers;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Products;
using RechargeSharp.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Onetimes
{
    public class Onetime : RechargeSharp.Entities.Onetimes.Onetime
    {
        [JsonIgnore]
        public Address? Address { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }
        
        [JsonIgnore]
        public Product? Product { get; set; }

        [JsonProperty("properties")]
        [NotMapped]
        public new ICollection<Property>? Properties { get; set; }
    }
}

using Newtonsoft.Json;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Addresses;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Discounts
{
    public class Discount : RechargeSharp.Entities.Discounts.Discount
    {
        [JsonIgnore]
        public virtual Address? Address { get; set; }
    }
}

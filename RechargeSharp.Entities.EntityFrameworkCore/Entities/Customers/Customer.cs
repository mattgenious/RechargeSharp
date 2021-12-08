using Newtonsoft.Json;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Addresses;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Charges;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Onetimes;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Orders;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Subscriptions;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Customers
{
    public class Customer : RechargeSharp.Entities.Customers.Customer
    {
        [JsonIgnore]
        public virtual ICollection<Address>? Addresses { get; set; }

        [JsonIgnore]
        public virtual ICollection<Subscription>? Subscriptions { get; set; }

        [JsonIgnore]
        public virtual ICollection<Charge>? Charges { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }

        [JsonIgnore]
        public virtual ICollection<Onetime>? Onetimes { get; set; }
    }
}

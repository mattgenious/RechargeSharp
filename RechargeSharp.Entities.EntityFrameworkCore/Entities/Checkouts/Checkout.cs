using Newtonsoft.Json;
using RechargeSharp.Entities.Checkouts;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Charges;
using RechargeSharp.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Checkouts
{
    public class Checkout : RechargeSharp.Entities.Checkouts.Checkout
    {
        [JsonIgnore]
        public Charge? Charge { get; set; }
    }
}

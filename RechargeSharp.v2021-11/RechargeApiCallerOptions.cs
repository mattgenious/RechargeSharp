using System.ComponentModel.DataAnnotations;

namespace RechargeSharp.v2021_11
{
    public class RechargeApiCallerOptions
    {
        [Required]
        public string? ApiKey { get; set; }

        [Range(0, 20)]
        public int RetryCount { get; set; } = 10;
    }
}

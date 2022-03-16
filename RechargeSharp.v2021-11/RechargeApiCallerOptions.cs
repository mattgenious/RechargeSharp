using System.ComponentModel.DataAnnotations;
using Polly;
using RechargeSharp.v2021_11.Exceptions;

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

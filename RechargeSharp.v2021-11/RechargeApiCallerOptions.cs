using System.ComponentModel.DataAnnotations;
using Polly;
using RechargeSharp.v2021_11.Exceptions;

namespace RechargeSharp.v2021_11
{
    public class RechargeApiCallerOptions
    {
        [Required]
        public string ApiKey { get; set; }
        
        public IAsyncPolicy ApiCallPolicy { get; internal set; } = GetDefaultApiCallPolicy();
        
        public static IAsyncPolicy GetDefaultApiCallPolicy()
        {
            var jitterer = new Random();

            var retryLogic = new Func<PolicyBuilder, IAsyncPolicy>(policyBuilder => policyBuilder.WaitAndRetryAsync(10, x => TimeSpan.FromSeconds(x) + TimeSpan.FromMilliseconds(jitterer.NextInt64(1000))));

            return BuildErrorHandlingLogic(retryLogic);
        }

        internal static IAsyncPolicy BuildErrorHandlingLogic(Func<PolicyBuilder, IAsyncPolicy> func)
        {
            var policyWithConfiguredExceptionHandling = Policy
                .Handle<HttpRequestException>()
                .Or<RechargeApiException>(e => e.IsTransient is true or null);

            return func(policyWithConfiguredExceptionHandling);
        }
    }
}

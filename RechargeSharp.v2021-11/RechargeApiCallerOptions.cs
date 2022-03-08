using Polly;
using RechargeSharp.v2021_11.Exceptions;

namespace RechargeSharp.v2021_11
{
    public class RechargeApiCallerOptions
    {
        public IEnumerable<string>? ApiKeyArray;
        public string? WebhookApiKey;
        private int _index = 0;
        private bool _ordered = false;
        private int _count = 0;

        public string? GetWebhookApiKey()
        {
            return WebhookApiKey;
        }

        public string GetApiKey()
        {
            if (ApiKeyArray == null)
            {
                throw new ArgumentNullException("Please supply API keys in options when registering RechargeSharp in your DI container");
            }
            if (!ApiKeyArray.Any())
            {
                throw new ArgumentException("Please supply api keys in options when registering RechargeSharp in your DI container");
            }

            if (_count == 0)
            {
                _count = ApiKeyArray.Count();
            }

            if (!_ordered)
            {
                ApiKeyArray = ApiKeyArray.OrderBy(x => x);
                _ordered = true;
            }

            if (_index < _count)
            {
                var returnVal = ApiKeyArray.Skip(_index).First();
                _index++;
                if (string.IsNullOrEmpty(returnVal))
                {
                    return GetApiKey();
                }
                return returnVal;
            }
            else
            {
                _index = 0;
                return GetApiKey();
            }

        }

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

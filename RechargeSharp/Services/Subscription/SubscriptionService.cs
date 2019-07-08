using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RechargeSharp.Services.Subscription
{
    class SubscriptionService : RechargeSharpService
    {
        public SubscriptionService(string apiKey) : base(apiKey)
        {

        }

        public async Task<Entities.Subscription.Subscription> GetSubscriptionAsync(string id)
        {
            var response = await GetAsync($"/subscriptions/{id}");
            return JsonConvert.DeserializeObject<Entities.Subscription.Subscription>(
                await response.Content.ReadAsStringAsync());
        }
    }
}

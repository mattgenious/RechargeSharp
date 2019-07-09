using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RechargeSharp.Services.Subscriptions
{
    public class SubscriptionService : RechargeSharpService
    {
        public SubscriptionService(string apiKey) : base(apiKey)
        {
        }

        public async Task<Entities.Subscriptions.Subscription> GetSubscriptionAsync(string id)
        {
            var response = await GetAsync($"/subscriptions/{id}");
            return JsonConvert.DeserializeObject<Entities.Subscriptions.Subscription>(
                await response.Content.ReadAsStringAsync());
        }
    }
}

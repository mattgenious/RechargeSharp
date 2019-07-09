using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;

namespace RechargeSharp.Services
{
    public class RechargeSharpService
    {
        protected readonly HttpClient HttpClient;
        protected readonly AsyncRetryPolicy<HttpResponseMessage> AsyncRetryPolicy;
        protected RechargeSharpService(string apiKey)
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.Add("X-Recharge-Access-Token", apiKey);
            HttpClient.BaseAddress = new Uri("https://api.rechargeapps.com/");
            AsyncRetryPolicy = Policy.HandleResult<HttpResponseMessage>(x =>
            {
                if (!x.IsSuccessStatusCode)
                {
                    if ((int)x.StatusCode == 429 && (int)x.StatusCode > 499)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }).RetryAsync(3);
        }

        protected async Task<HttpResponseMessage> GetAsync(string path)
        {
            return await AsyncRetryPolicy.ExecuteAsync(async () => await HttpClient.GetAsync(path));
        }
        protected async Task<HttpResponseMessage> PutAsync(string path, string jsonData)
        {
            return await AsyncRetryPolicy.ExecuteAsync(async () => await HttpClient.PutAsync(path, new StringContent(jsonData)));
        }
        protected async Task<HttpResponseMessage> PostAsync(string path, string jsonData)
        {
            return await AsyncRetryPolicy.ExecuteAsync(async () => await HttpClient.PostAsync(path, new StringContent(jsonData)));
        }
        protected async Task<HttpResponseMessage> DeleteAsync(string path)
        {
            return await AsyncRetryPolicy.ExecuteAsync(async () => await HttpClient.DeleteAsync(path));
        }
    }
}

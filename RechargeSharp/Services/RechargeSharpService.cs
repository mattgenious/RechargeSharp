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
                        throw new HttpRequestException(x.ReasonPhrase);
                    }
                }
                else
                {
                    return false;
                }
            }).RetryAsync(3);
        }

        protected Task<HttpResponseMessage> GetAsync(string path)
        {
            return AsyncRetryPolicy.ExecuteAsync(async () => await HttpClient.GetAsync(path));
        }
        protected Task<HttpResponseMessage> PutAsync(string path, string jsonData)
        {
            return AsyncRetryPolicy.ExecuteAsync(async () => await HttpClient.PutAsync(path, new StringContent(jsonData)));
        }
        protected Task<HttpResponseMessage> PostAsync(string path, string jsonData)
        {
            return AsyncRetryPolicy.ExecuteAsync(async () => await HttpClient.PostAsync(path, new StringContent(jsonData)));
        }
        protected Task<HttpResponseMessage> DeleteAsync(string path)
        {
            return AsyncRetryPolicy.ExecuteAsync(async () => await HttpClient.DeleteAsync(path));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            AsyncRetryPolicy = Policy.HandleResult<HttpResponseMessage>( x =>
            {
                if (!x.IsSuccessStatusCode)
                {
                    if ((int)x.StatusCode == 400 || (int)x.StatusCode == 404 || (int)x.StatusCode == 422 || (int)x.StatusCode > 499)
                    {
                        throw new Exception(x.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }).WaitAndRetryAsync(new []
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(3),
                TimeSpan.FromSeconds(4),
                TimeSpan.FromSeconds(5)
            });
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
        protected Task<HttpResponseMessage> PostAsJsonAsync(string path, string jsonData)
        {
            var content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return AsyncRetryPolicy.ExecuteAsync(async () => await HttpClient.PostAsync(path, content));
        }
        protected Task<HttpResponseMessage> DeleteAsync(string path)
        {
            return AsyncRetryPolicy.ExecuteAsync(async () => await HttpClient.DeleteAsync(path));
        }
    }
}

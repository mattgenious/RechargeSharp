using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using Polly;
using Polly.Wrap;

namespace RechargeSharp.Services
{
    class RechargeSharpService
    {
        protected readonly HttpClient HttpClient;
        protected readonly PolicyBuilder<HttpResponseMessage> PolicyBuilder;
        protected RechargeSharpService(string apiKey)
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.Add("X-Recharge-Access-Token", apiKey);
            HttpClient.BaseAddress = new Uri("https://api.rechargeapps.com/");
            PolicyBuilder = Policy.HandleResult<HttpResponseMessage>(x => x.IsSuccessStatusCode);
        }

        protected async Task<HttpResponseMessage> GetAsync(string path)
        {
            return await HttpClient.GetAsync(path);
        }
        protected async Task<HttpResponseMessage> PutAsync(string path, string jsonData)
        {
            return await HttpClient.PutAsync(path, new StringContent(jsonData));
        }
        protected async Task<HttpResponseMessage> PostAsync(string path, string jsonData)
        {
            return await HttpClient.PostAsync(path, new StringContent(jsonData));
        }
        protected async Task<HttpResponseMessage> DeleteAsync(string path)
        {
            return await HttpClient.DeleteAsync(path);
        }
    }
}

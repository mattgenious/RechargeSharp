using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace RechargeSharp.Services
{
    public class RechargeSharpService
    {
        protected readonly HttpClient HttpClient;
        protected readonly AsyncRetryPolicy<HttpResponseMessage> AsyncRetryPolicy;
        protected readonly ILogger<RechargeSharpService>? Logger;
        protected RechargeSharpService(string apiKey, ILogger<RechargeSharpService>? logger)
        {
            Logger = logger;

            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.Add("X-Recharge-Access-Token", apiKey);
            HttpClient.BaseAddress = new Uri("https://api.rechargeapps.com/");
            AsyncRetryPolicy = Policy.HandleResult<HttpResponseMessage>( x =>
            {
                if (!x.IsSuccessStatusCode)
                {
                    Logger?.LogError(x.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    if ((int)x.StatusCode > 399 && (int)x.StatusCode != 429)
                    {
                        throw new Exception(x.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }).WaitAndRetryForeverAsync(
                retryAttempt => 
                    TimeSpan.FromSeconds(1));
        }

        protected RechargeSharpService(string apiKey) : this(apiKey, null)
        {
        }

        protected Task<HttpResponseMessage> GetAsync(string path)
        {
            return AsyncRetryPolicy.ExecuteAsync(async () => await HttpClient.GetAsync(path));
        }
        protected Task<HttpResponseMessage> PutAsJsonAsync(string path, string jsonData)
        {
            var content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return AsyncRetryPolicy.ExecuteAsync(async () => await HttpClient.PutAsync(path, content));
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

        protected void ValidateModel(object objectToValidate)
        {
            var context = new ValidationContext(objectToValidate);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(objectToValidate, context, results, true))
            {
                throw new ArgumentException(string.Join(", ", results), nameof(objectToValidate));
            }
        }
    }
}

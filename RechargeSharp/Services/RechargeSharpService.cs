using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using Polly;
using Polly.Wrap;

namespace RechargeSharp.Services
{
    class RechargeSharpService
    {
        protected readonly HttpClient _httpClient;
        protected RechargeSharpService(string apiKey)
        {
            // configure httpclient.
            // configure Polly policy.
            // then allow subclasses to use client in methods.
            _httpClient = new HttpClient();
            Policy timoutPolicy = Policy.Timeout(30);
        }
    }
}

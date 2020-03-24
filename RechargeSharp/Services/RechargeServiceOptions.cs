using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RechargeSharp.Services
{
    public class RechargeServiceOptions
    {
        public IEnumerable<string> ApiKeyArray;
        public string WebhookApiKey;
        private int _index = 0;
        private bool _ordered = false;
        private int _count = 0;

        public string GetWebhookApiKey()
        {
            return WebhookApiKey;
        }

        public string GetApiKey()
        {
            if (ApiKeyArray == null)
            {
                throw new ArgumentNullException("Please supply api keys in options when registering RechargeSharp in your DI container");
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
                return returnVal;
            }
            else
            {
                _index = 0;
                return GetApiKey();
            }

        }
    }
}

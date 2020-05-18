using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WAC.Models.Config;
using WAC.Rest.Abstract;
using WAC.Rest.Models;

namespace WAC.Rest
{
    public class CurrencyRates : ICurrencyRates
    {
        private static IDictionary<string, double> currencies;
        private static string apiUrl;
        private static string _base;
        public CurrencyRates(IOptions<AppConfig> settings)
        {
            apiUrl = settings.Value.CurrencyUrl;
            try
            {
                Currencies();
            }
            catch
            {
                _base = "EUR";
            }
        }
        public string Base()
        {
            return _base;
        }

        public IDictionary<string, double> Currencies()
        {
            var result = ApiRequest().Result;
            currencies = result.rates;
            _base = result.@base;
            return currencies;
        }
        private async Task<Rates> ApiRequest()
        {
            Rates rates = new Rates();
            using (HttpClient http = new HttpClient())
            {
                var response = await http.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    rates = await response.Content.ReadAsAsync<Models.Rates>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception(errorMessage);
                }
            }
            return rates;
        }

    }

}

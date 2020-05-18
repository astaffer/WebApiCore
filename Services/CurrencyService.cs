using WAC.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using WAC.Services.Abstract;
using WAC.Rest.Abstract;

namespace WAC.Services
{
    public class CurrencyService : ICurrencyService
    {
        ICurrencyRates cr;
        public CurrencyService(ICurrencyRates currencyRates)
        {
            cr = currencyRates;
        }
        public double Convert(string fromCurrency, string toCurrency, double value)
        {
            if (fromCurrency == toCurrency)
                return value;
            double result = 0.0;
            var currencies = cr.Currencies();
            string _base = cr.Base();
            
            if (fromCurrency != _base)
            {
                result = currencies[fromCurrency] != 0.0 ? value / currencies[fromCurrency] : 0;
            }
            else
            {
                result = value;
            }
            if (toCurrency != _base)
            {
                result = result * currencies[toCurrency];
            }
            return result;
        }

        public bool CurrencyExist(string currency)
        {
            bool result = false;
            if (cr.Currencies().ContainsKey(currency))
                result = true;
            return result;
        }
    }
}

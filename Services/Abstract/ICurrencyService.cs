using WAC.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace WAC.Services.Abstract
{
    public interface ICurrencyService
    {
        public bool CurrencyExist(string currency);
        public double Convert(string fromCurrency, string toCurrency, double value);
    }
}

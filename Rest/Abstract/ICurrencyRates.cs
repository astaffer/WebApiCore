using System;
using System.Collections.Generic;
using System.Text;

namespace WAC.Rest.Abstract
{
    public interface ICurrencyRates
    {
        IDictionary<string, double> Currencies();
        string Base();
    }
}

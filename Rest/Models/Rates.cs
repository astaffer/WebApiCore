using System;
using System.Collections.Generic;
using System.Text;

namespace WAC.Rest.Models
{
    public class Rates
    {
        public IDictionary<string, double> rates { get; set; }
        public string @base {get;set ;}
        public string date { get; set; }

    }
}

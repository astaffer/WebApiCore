using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAC.Models.Data
{
    public class Wallet
    {
        public string Key { get; set; }
        public User User { get; set; }
        public IDictionary<string, double> Accounts { get; set; }
    }
}

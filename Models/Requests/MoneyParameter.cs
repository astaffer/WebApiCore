using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAC.Models.Data;

namespace WAC.Models.Requests
{
    public class MoneyParameter
    {
        public Money Money { get; set; }
        public User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAC.Models.Data;

namespace WAC.Models.Requests
{
    public class MoveMoneyParameter
    {
        public Money From { get; set; }
        public string ToCurrency { get; set; }
        public User User { get; set; }
    }
}

using WAC.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace WAC.Models.Responses
{
    public class WalletResponse : BaseResponse
    {
        public Wallet wallet { get; set; }
    }
}

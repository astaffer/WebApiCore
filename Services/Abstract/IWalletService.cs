using System;
using System.Collections.Generic;
using System.Text;
using WAC.Models.Requests;
using WAC.Models.Responses;

namespace WAC.Services.Abstract
{
    public interface IWalletService
    {
        BaseResponse PlusMoney(MoneyParameter param);
        BaseResponse MinusMoney(MoneyParameter param);
        BaseResponse MoveMoney(MoveMoneyParameter param);
        WalletResponse GetStatus(UserParameter param);
    }
}

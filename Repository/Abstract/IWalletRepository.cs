using WAC.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace WAC.Repository.Abstract
{
    public interface  IWalletRepository
    {
        void Update(Wallet wallet);
        Wallet GetWallet(string key);
        void Create(Wallet wallet);
    }
}

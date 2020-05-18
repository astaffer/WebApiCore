using WAC.Models.Data;
using WAC.Repository.Abstract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace WAC.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private static ConcurrentDictionary<string, Wallet> _wallets =
              new ConcurrentDictionary<string, Wallet>();
        public WalletRepository()
        {
            Create(new Wallet()
            {
                User = new User() { UserId = "bear" }
                ,
                Accounts = new ConcurrentDictionary<string, double>()
                {
                    ["RUB"] = 300,
                    ["USD"] = 10,
                    ["EUR"] = 200,
                }


            });
            Create(new Wallet()
            {
                User = new User() { UserId = "bird" }
                ,
                Accounts = new ConcurrentDictionary<string, double>()
                {
                    ["RUB"] = 30,
                    ["EUR"] = 20,
                }
            });
            Create(new Wallet()
            {
                User = new User() { UserId = "wolf" }
                ,
                Accounts = new ConcurrentDictionary<string, double>()
                {
                    ["RUB"] = 500,
                    ["USD"] = 10,
                    ["EUR"] = 100,
                }
            });
        }

        public void Create(Wallet wallet)
        {
            wallet.Key = wallet.User.UserId;
            _wallets[wallet.Key] = wallet;
        }

        public Wallet GetWallet(string key)
        {
            Wallet wallet;
            _wallets.TryGetValue(key, out wallet);
            return wallet;
        }

        public void Update(Wallet wallet)
        {
            _wallets[wallet.Key] = wallet;
        }
    }
}

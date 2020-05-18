using WAC.Models.Requests;
using WAC.Models.Responses;
using WAC.Repository.Abstract;
using WAC.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using WAC.Rest.Abstract;

namespace WAC.Services
{
    public class WalletService : IWalletService
    {
        private IWalletRepository wr;
        private ICurrencyService cr;
        public WalletService(IWalletRepository repository, ICurrencyService currencyService)
        {
            wr = repository;
            cr = currencyService;
        }
        public WalletResponse GetStatus(UserParameter param)
        {
            WalletResponse result = new WalletResponse();
            try
            {
                result.wallet = wr.GetWallet(param.User.UserId);
                if (result.wallet == null)
                {
                    throw new Exception("Пользователь не найден");
                }
            }
            catch (Exception e)
            {
                result.IsError = true;
                result.ErrorMessage = e.Message;
            }
            return result;
        }

        public BaseResponse MinusMoney(MoneyParameter param)
        {
            var result = new BaseResponse();
            try
            {
                result = AddMoney(param, true);
            }
            catch (Exception e)
            {
                result.IsError = true;
                result.ErrorMessage = e.Message;
            }
            return result;
        }
        public BaseResponse PlusMoney(MoneyParameter param)
        {
            var result = new BaseResponse();
            try
            {
                result = AddMoney(param);
            }
            catch (Exception e)
            {
                result.IsError = true;
                result.ErrorMessage = e.Message;
            }
            return result;
        }
        public BaseResponse MoveMoney(MoveMoneyParameter param)
        {
            var result = new BaseResponse();
            try
            {
                result = MinusMoney(new MoneyParameter() { Money = param.From, User = param.User });
                if (!result.IsError)
                {
                    param.From.Amount = cr.Convert(param.From.Currency, param.ToCurrency, param.From.Amount);
                    param.From.Currency = param.ToCurrency;
                    result = PlusMoney(new MoneyParameter() { Money = param.From, User = param.User });
                }
            }
            catch (Exception e)
            {
                result.IsError = true;
                result.ErrorMessage = e.Message;
            }
            return result;
        }

        private BaseResponse AddMoney(MoneyParameter param, bool minus = false)
        {
            var result = new BaseResponse();

            var wallet = wr.GetWallet(param.User.UserId);
            if (wallet == null)
            {
                throw new Exception("Пользователь не найден");
            }
            if (!wallet.Accounts.ContainsKey(param.Money.Currency))
            {
                if (!cr.CurrencyExist(param.Money.Currency))
                {
                    throw new Exception("Валюта не определена");
                }
                wallet.Accounts[param.Money.Currency] = 0;
            }
            if (minus)
            {
                wallet.Accounts[param.Money.Currency] -= param.Money.Amount;
            }
            else
            {
                wallet.Accounts[param.Money.Currency] += param.Money.Amount;
            }
            wr.Update(wallet);
            return result;
        }
    }
}

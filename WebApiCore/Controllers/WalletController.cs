using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WAC.Models.Data;
using WAC.Models.Requests;
using WAC.Models.Responses;
using WAC.Services.Abstract;

namespace WebApiCore.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        public IWalletService ws { get; set; }
        private readonly IConfiguration Configuration;

        public WalletController(IWalletService walletService, IConfiguration configuration)
        {
            ws = walletService;
            Configuration = configuration;
        }
        [HttpPost]
        public WalletResponse GetWallet(UserParameter parm)
        {
            var s = Configuration["AppConfig:CurrencyUrl"];
            return ws.GetStatus(parm);
        }
        [HttpPost]
        public BaseResponse PlusMoney(MoneyParameter parm)
        {
            return ws.PlusMoney(parm);
        }
        [HttpPost]
        public BaseResponse MinusMoney(MoneyParameter parm)
        {
            return ws.MinusMoney(parm);
        }
        [HttpPost]
        public BaseResponse MoveMoney(MoveMoneyParameter parm)
        {
            return ws.MoveMoney(parm);
        }
    }
}
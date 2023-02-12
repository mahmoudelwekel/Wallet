using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Domain.Common.APPSetting;
using Wallet.ServiceLayer.Contract.IEntityServices.ITransactionServices;
using Wallet.UI.Models;
using Wallet.UI.Models.TransactionModels;

namespace Wallet.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ITransactionEntityService _transactionService;


        public HomeController(
            ITransactionEntityService transactionService,
            IMapper mapper,
            IOptions<AppSettings> _appSetting, UserManager<IdentityUser> UserManager) : base(mapper, _appSetting, UserManager)
        {
            _transactionService = transactionService;
        }


        public IActionResult Index()
        {
            var b = new TransactionBalanceModel() {

                Balance = _transactionService.GetUserTransactionBalance(User?.Claims?.FirstOrDefault()?.Value)

            };

            return View(b);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

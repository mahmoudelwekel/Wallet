using AutoMapper; 
using Wallet.UI.Models.TransactionModels;
using Wallet.Domain.Common.APPSetting; 
using Wallet.ServiceLayer.Contract.IEntityServices.ITransactionServices;
using Wallet.ServiceLayer.Contract.IEntityServices.ITransactionServices.DTOs; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Wallet.UI.Controllers
{ 
    public class TransactionsController : BaseController
    {
        private readonly ITransactionEntityService _transactionService;


        public TransactionsController(
            ITransactionEntityService transactionService,
            IMapper mapper,
            IOptions<AppSettings> _appSetting, UserManager<IdentityUser> UserManager) : base(mapper, _appSetting, UserManager)
        {
            _transactionService = transactionService;
        }
        #region Create Transaction

        public IActionResult Create()
        {
             return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTransactionReqModel model)
        {
            if (ModelState.IsValid)
            {
                model.TransactionFromUserId = User?.Claims?.FirstOrDefault()?.Value;
                model.TransactionCreateBy = User?.Claims?.FirstOrDefault()?.Value;

                var res = _transactionService.AddTransaction(_mapper.Map<TransactionDTO>(model));

                if (res)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("All", "Failed");
                }
            }
            return View(model);
        }
         

        #endregion

     

    }
}

using AutoMapper;
using Wallet.Domain.Common.APPSetting;
using Wallet.Domain.Entities.Wallet;
using Wallet.RepositoryLayer.Contract.IWalletRepository;
using Wallet.ServiceLayer.Contract.IEntityServices.ITransactionServices;
using Wallet.ServiceLayer.Contract.IEntityServices.ITransactionServices.DTOs;
using Wallet.ServiceLayer.Persistence.GenericService;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.ServiceLayer.Persistence.EntityServices.TransactionService
{
    public class TransactionEntityService : GenericServices, ITransactionEntityService
    {
        public TransactionEntityService(
            IWalletWrapper WalletWrapper,
            IOptions<AppSettings> appSettings,
            ILogger<TransactionEntityService> logger,
            IMapper mapper) : base(WalletWrapper, appSettings, logger, mapper)
        {

        }

        public bool AddTransaction(TransactionDTO _tran)
        {
            bool response = false;

            try
            {

                var ToUser = _WalletWrapper.UserRepository.GetUserByPhone(_tran.TransactionToUserPhone);

                if (ToUser != null)
                {
                    Transaction transaction = _mapper.Map<Transaction>(_tran);
                    transaction.TransactionCreateDate = DateTime.Now;
                    transaction.TransactionToUserId = ToUser.Id;

                    response = _WalletWrapper.TransactionRepository
                                                    .AddTransaction(ref transaction);

                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"TransactionEntityService>> AddTransaction>> throws the following Exception {ex.Message}");
            }
            return response;
        }

        public decimal GetUserTransactionBalance(string _userID)
        {
            decimal response = 0;

            try
            {

                decimal ToUser = _WalletWrapper.TransactionRepository.GetTransactionsToUser(_userID).Sum(x=>x.TransactionAmount);
                decimal FromUser = _WalletWrapper.TransactionRepository.GetTransactionsFromUser(_userID).Sum(x=>x.TransactionAmount);

                response = ToUser - FromUser;

            }
            catch (Exception ex)
            {
                _logger.LogError($"TransactionEntityService>> GetUserTransactionBalance>> throws the following Exception {ex.Message}");
            }
            return response;
        }
    }
}

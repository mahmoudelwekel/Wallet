using Wallet.Domain.Contexts;
using Wallet.Domain.Entities.Wallet;
//using Wallet.Helper.Enums;
//using Wallet.Helper.Extentions;
using Wallet.RepositoryLayer.Contract.IWalletRepository;
using Wallet.RepositoryLayer.Persistence.WalletRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.RepositoryLayer.Persistence.GenericRepository;

namespace Wallet.RepositoryLayer.Persistence.WalletRepository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {

        public TransactionRepository(IConfiguration config, IBaseContext context) : base(config, context)
        {

        }


        public Transaction GetTransactionByID(long _transactionId)
        {
            return _dbContext.Wallet().Transactions.Find(_transactionId);
        }

        public bool AddTransaction(ref Transaction _transaction)
        {
            return Insert(_dbContext.Wallet(), _transaction);
        }

        public List<Transaction> GetTransactionsFromUser(string UserId)
        {
            return _dbContext.Wallet().Transactions.Where(x=>x.TransactionFromUserId==UserId).ToList();
        }

        public List<Transaction> GetTransactionsToUser(string UserId)
        {
            return _dbContext.Wallet().Transactions.Where(x => x.TransactionToUserId == UserId).ToList();
        }
    }
}

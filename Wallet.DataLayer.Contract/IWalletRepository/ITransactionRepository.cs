using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Entities.Wallet;

namespace Wallet.RepositoryLayer.Contract.IWalletRepository
{
    public interface ITransactionRepository
    {
        Transaction GetTransactionByID(long _transactionId);
        List<Transaction> GetTransactionsFromUser(string UserId);
        List<Transaction> GetTransactionsToUser(string UserId);

        bool AddTransaction(ref Transaction _transaction);


    }
}

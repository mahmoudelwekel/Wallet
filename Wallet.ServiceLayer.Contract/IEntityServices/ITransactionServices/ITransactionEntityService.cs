using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.ServiceLayer.Contract.IEntityServices.ITransactionServices.DTOs;

namespace Wallet.ServiceLayer.Contract.IEntityServices.ITransactionServices
{
    public interface ITransactionEntityService
    {
       bool  AddTransaction(  TransactionDTO _transaction);
       decimal  GetUserTransactionBalance(  string _userID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.RepositoryLayer.Contract.IWalletRepository
{
    public interface IWalletWrapper : IDisposable
    {
        
        ITransactionRepository TransactionRepository { get; }
        IUserRepository UserRepository { get; }
     
        
    }
}

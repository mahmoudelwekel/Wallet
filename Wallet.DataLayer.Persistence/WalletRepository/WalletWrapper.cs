using Wallet.Domain.Contexts;
using Wallet.RepositoryLayer.Contract.IWalletRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.RepositoryLayer.Persistence.WalletRepository
{
    public class WalletWrapper : IWalletWrapper
    {
        private readonly IConfiguration _config;
        private readonly IBaseContext _context;

        public WalletWrapper(IBaseContext context)
        {
            this._context = context;
        }
 
        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------

        private ITransactionRepository _transactionRepository;
        public ITransactionRepository TransactionRepository
        {
            get
            {
                if (_transactionRepository == null)
                {
                    _transactionRepository = new TransactionRepository(_config, _context);
                }
                return _transactionRepository;
            }
        }
        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------
        
        private IUserRepository _UserRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_UserRepository == null)
                {
                    _UserRepository = new UserRepository(_config, _context);
                }
                return _UserRepository;
            }
        }
        
        
        
        public void Dispose()
        {
           
        }
    }
}

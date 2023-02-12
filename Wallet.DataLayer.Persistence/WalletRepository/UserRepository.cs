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
    public class UserRepository : GenericRepository<AspNetUser>, IUserRepository
    {

        public UserRepository(IConfiguration config, IBaseContext context) : base(config, context)
        {

        }
 
        public AspNetUser GetUserByPhone(string Phone)
        {
            return _dbContext.Wallet().AspNetUsers.FirstOrDefault(x => x.PhoneNumber == Phone);
        }
    }
}

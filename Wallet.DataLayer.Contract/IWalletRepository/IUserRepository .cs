using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Entities.Wallet;

namespace Wallet.RepositoryLayer.Contract.IWalletRepository
{
    public interface IUserRepository
    {
        AspNetUser GetUserByPhone(string Phone);

 

    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Common.APPSetting;
using Wallet.Domain.Entities.Wallet;

namespace Wallet.Domain.Contexts
{

    public interface IBaseContext
    {
        WalletContext Wallet();

    }
    public class BaseContext : IBaseContext
    {


        private readonly string _DefaultConnection;


        private readonly int _DefaultConnectionTimeOut;



        private WalletContext _DefaultContext;


        public BaseContext(IOptions<ConnectionStringModel> connectionStringModel, IOptions<ConnectionTimeOutModel> connectionTimeOutModel)
        {
            this._DefaultConnection = connectionStringModel.Value.DefaultConnection;
            this._DefaultConnectionTimeOut = connectionTimeOutModel.Value.DefaultConnectionTimeOut;
        }

        public WalletContext Wallet()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WalletContext>();
            optionsBuilder.UseSqlServer(_DefaultConnection);

            _DefaultContext = _DefaultContext ?? new WalletContext(optionsBuilder.Options);
            _DefaultContext.Database.SetCommandTimeout(_DefaultConnectionTimeOut);

            _DefaultContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _DefaultContext.ChangeTracker.LazyLoadingEnabled = false;
            _DefaultContext.ChangeTracker.AutoDetectChangesEnabled = false;

            return _DefaultContext;
        }


    }
}

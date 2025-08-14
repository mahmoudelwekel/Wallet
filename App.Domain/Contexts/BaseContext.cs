
using App.Domain.CommonAppSetting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace App.Domain.Contexts
{

    public interface IBaseContext
    {
        Entities.App.MainContext App();

    }
    public class BaseContext : IBaseContext
    {


        private readonly string _DefaultConnection;


        private readonly int _DefaultConnectionTimeOut;



        private Entities.App.MainContext _DefaultContext;


        public BaseContext(IOptions<ConnectionStringModel> connectionStringModel, IOptions<ConnectionTimeOutModel> connectionTimeOutModel)
        {
            this._DefaultConnection = connectionStringModel.Value.DefaultConnection;
            this._DefaultConnectionTimeOut = connectionTimeOutModel.Value.DefaultConnectionTimeOut;
        }

        public Entities.App.MainContext App()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Entities.App.MainContext>();
            optionsBuilder.UseSqlServer(_DefaultConnection);

            _DefaultContext = _DefaultContext ?? new Entities.App.MainContext(optionsBuilder.Options);
            _DefaultContext.Database.SetCommandTimeout(_DefaultConnectionTimeOut);

            _DefaultContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _DefaultContext.ChangeTracker.LazyLoadingEnabled = false;
            _DefaultContext.ChangeTracker.AutoDetectChangesEnabled = false;

            return _DefaultContext;
        }


    }
}

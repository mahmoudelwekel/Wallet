using App.Domain.Contexts;
using App.Domain.Entities.App;
using App.RepositoryLayer.Contract.IAppRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace App.RepositoryLayer.Persistence.AppRepository
{
    public class AppWrapper : IAppUnitOfWork
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _AppDbContext;

        public AppWrapper(IBaseContext context, IConfiguration config)
        {
            this._AppDbContext = context.App();
            this._config = config;

        }

        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------

        private IExampleRepository _ExampleRepository;
        public IExampleRepository ExampleRepository
        {
            get
            {
                if (_ExampleRepository == null)
                {
                    _ExampleRepository = new ExampleRepository(_config, _AppDbContext);
                }
                return _ExampleRepository;
            }
        }
        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------





        public void Dispose()
        {
            _AppDbContext.Dispose();
        }

        public int SaveChanges()
        {
            return _AppDbContext.SaveChanges();
        }

        public void ForgetChanges()
        {
            foreach (EntityEntry entry in _AppDbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }
    }
}

using App.Domain.Contexts;
using App.RepositoryLayer.Contract.IAppRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace App.RepositoryLayer.Persistence.AppRepository
{
    public class AppWrapper : IAppUnitOfWork
    {
        private readonly IConfiguration _config;
        private readonly IBaseContext _context;

        public AppWrapper(IBaseContext context)
        {
            this._context = context;
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
                    _ExampleRepository = new ExampleRepository(_config, _context);
                }
                return _ExampleRepository;
            }
        }
        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------





        public void Dispose()
        {
            _context.App().Dispose();
        }

        public int SaveChanges()
        {
            return _context.App().SaveChanges();
        }

        public void ForgetChanges()
        {
            foreach (EntityEntry entry in _context.App().ChangeTracker.Entries())
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

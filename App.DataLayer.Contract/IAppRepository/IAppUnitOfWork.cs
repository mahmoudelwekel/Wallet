using System;

namespace App.RepositoryLayer.Contract.IAppRepository
{
    public interface IAppUnitOfWork : IDisposable
    {
        IExampleRepository ExampleRepository { get; }

        int SaveChanges();
        void ForgetChanges();

    }
}

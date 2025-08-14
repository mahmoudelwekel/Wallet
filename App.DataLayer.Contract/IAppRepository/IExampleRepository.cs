using App.Domain.Entities.App;
using App.RepositoryLayer.Contract.IGenericRepository;
using System.Collections.Generic;

namespace App.RepositoryLayer.Contract.IAppRepository
{
    public interface IExampleRepository : IGenericRepository<Example>
    {
        Example GetByID(int _ExampleId);
        List<Example> GetFromUser(string UserId);
        List<Example> GetToUser(string UserId);

        bool Create(Example _Example);


    }
}

using App.Domain.Entities.App;
using System.Collections.Generic;

namespace App.RepositoryLayer.Contract.IAppRepository
{
    public interface IExampleRepository : IAppGenericRepository<Example>
    {
        Example GetByID(int _ExampleId);
        List<Example> GetFromUser(string UserId);
        List<Example> GetToUser(string UserId);

        bool Create(Example _Example);


    }
}

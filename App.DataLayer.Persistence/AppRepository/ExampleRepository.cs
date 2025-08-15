using App.Domain.Contexts;
using App.Domain.Entities.App;
//using App.Helper.Enums;
//using App.Helper.Extentions;
using App.RepositoryLayer.Contract.IAppRepository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace App.RepositoryLayer.Persistence.AppRepository
{
    public class ExampleRepository : AppGenericRepository<Example>, IExampleRepository
    {

        public ExampleRepository(IConfiguration config, AppDbContext context) : base(config, context)
        {

        }


        public Example GetByID(int _ExampleId)
        {
            return FindSingle(_ExampleId);
        }

        public bool Create(Example _Example)
        {
            Insert(_Example);
            return true;
        }

        public List<Example> GetFromUser(string UserId)
        {
            return Find(x => x.ExampleFromUserId == UserId).ToList();
        }

        public List<Example> GetToUser(string UserId)
        {
            return Find(x => x.ExampleToUserId == UserId).ToList();
        }
    }
}

using Wallet.Domain.Contexts;
using Wallet.RepositoryLayer.Contract.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Wallet.RepositoryLayer.Persistence.GenericRepository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IConfiguration _config;
        protected readonly IBaseContext _dbContext;

        public GenericRepository(IConfiguration config, IBaseContext DBContext)
        {
            _config = config;
            _dbContext = DBContext;
            DefaultTypeMap.MatchNamesWithUnderscores = true;

        }

        public void Dispose()
        {
            
        }

        public T GetById(DbContext _context, T id)
        {
            return _context.Find<T>(id);
        }

        public IEnumerable<T> GetAll(DbContext _context)
        {
            return _context.Set<T>().ToList();
        }


        public bool Insert(DbContext _context, T _obj)
        {
            _context.Add<T>(_obj);
            return SaveChanges(_context);
        }

        public bool Insert(DbContext _context,ref T _obj)
        {
            _context.Add<T>(_obj);
            return SaveChanges(_context);
        }

        public bool Update(DbContext _context, T _obj)
        {
            _context.Update<T>(_obj);
            return SaveChanges(_context);
        }


        public bool SaveChanges(DbContext _context)
        {
            int result = _context.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;
        }

        
    }
}

 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.RepositoryLayer.Contract.IGenericRepository
{
    public interface IGenericRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll(DbContext _context);
        T GetById(DbContext _context, T id);
        bool Insert(DbContext _context, T _obj);
        bool Insert(DbContext _context, ref T _obj);
        bool Update(DbContext _context, T _obj);
        bool SaveChanges(DbContext _context);

        
    }
}

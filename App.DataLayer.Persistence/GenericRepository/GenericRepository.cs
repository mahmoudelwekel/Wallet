using App.Domain.Common.Models;
using App.Domain.Contexts;
using App.Domain.Enum;
using App.RepositoryLayer.Contract.IGenericRepository;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace App.RepositoryLayer.Persistence.GenericRepository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IConfiguration _config;
        protected readonly IBaseContext _context;

        public GenericRepository(IConfiguration config, IBaseContext DBContext)
        {
            _config = config;
            _context = DBContext;
            DefaultTypeMap.MatchNamesWithUnderscores = true;

        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression = null, string Include = "", OrderBy OrderBy = 0, string OrderColumn = null, bool AsNoTracking = false)
        {
            var res = AsNoTracking ? _context.App().Set<T>().AsQueryable() : _context.App().Set<T>().AsNoTracking();

            if (expression != null)
            {
                res = res.Where(expression);
            }

            foreach (var item in Include.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                res = res.Include(item);
            }

            if (OrderBy == OrderBy.Ascending)
            {
                string ColumnName = ((T)Activator.CreateInstance(typeof(T))).GetType().GetProperties().FirstOrDefault(x => x.Name.ToLower() == OrderColumn.ToLower())?.Name;
                res = res.OrderBy(p => EF.Property<T>(p, ColumnName));
            }
            else if (OrderBy == OrderBy.Descending)
            {
                string ColumnName = ((T)Activator.CreateInstance(typeof(T))).GetType().GetProperties().FirstOrDefault(x => x.Name.ToLower() == OrderColumn.ToLower())?.Name;
                res = res.OrderByDescending(p => EF.Property<T>(p, ColumnName));
            }

            return res;
        }

        public T FindSingle(Expression<Func<T, bool>> expression, string Include = "", bool AsNoTracking = false)
        {
            return Find(expression, Include, AsNoTracking: AsNoTracking).FirstOrDefault();
        }
        public T FindSingle(int id)
        {
            return _context.App().Find<T>(id);
        }


        public void Insert(T entity)
        {
            _context.App().Add<T>(entity);
        }

        public void Update(T entity)
        {
            _context.App().Update<T>(entity);
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.App().Set<T>().Remove(entity);
        }
        public void Delete(Expression<Func<T, bool>> expression)
        {
            var ents = _context.App().Set<T>().Where(expression).ToList();
            foreach (var ent in ents)
                Delete(ent);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.App().Set<T>().AddRange(entities);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.App().Set<T>().UpdateRange(entities);

        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.App().Set<T>().RemoveRange(entities);
        }



        public int Count(Expression<Func<T, bool>> expression)
        {
            return _context.App().Set<T>().Count(expression);
        }
        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _context.App().Set<T>().Any(expression);
        }


        public string InsertAndGetId(T entity, string IdColumnName)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.App().Set<T>().Add(entity);
            _context.App().SaveChanges();
            return entity.GetType().GetProperty(IdColumnName).GetValue(entity, null).ToString();
        }

        public PagedResult<T> GetPage(int skip, int take, Expression<Func<T, bool>> predicate = null, string Include = null, OrderBy OrderBy = 0, string OrderColumn = null, bool AsNoTracking = true)
        {
            IEnumerable<T> source = Find(predicate, Include, OrderBy, OrderColumn, AsNoTracking);

            int totalNumberOfRecords = source.Count();
            return new PagedResult<T>
            {
                Skip = skip,
                Take = take,
                Data = source.Skip(skip).Take(take).ToList(),
                TotalNumberOfRecords = totalNumberOfRecords
            };
        }

        //public SelectList GetLookUp(string Value, string Text, string SelectedValue = "", string GroupBy = "", Expression<Func<T, bool>> expression = null, OrderBy OrderBy = 0, string OrderColumn = null)
        //{
        //    return new SelectList(Find(expression, "", true, OrderBy, OrderColumn), Value, Text, SelectedValue, GroupBy);

        //}



        public void Dispose()
        {

        }
    }
}

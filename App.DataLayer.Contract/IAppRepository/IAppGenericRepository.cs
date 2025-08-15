using App.Domain.Common.Models;
using App.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace App.RepositoryLayer.Contract.IAppRepository
{
    public interface IAppGenericRepository<T> : IDisposable
    {
        //IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate = null, string Include = null, OrderBy OrderBy = 0, string OrderColumn = null, bool AsNoTracking = false);
        T FindSingle(int id);
        T FindSingle(Expression<Func<T, bool>> expression, string Include = "", bool AsNoTracking = false);
        int Count(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
        void AddRange(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
        string InsertAndGetId(T entity, string IdColumnName);
        PagedResult<T> GetPage(int skip, int take, Expression<Func<T, bool>> predicate = null, string Include = null, OrderBy OrderBy = 0, string OrderColumn = null, bool AsNoTracking = true);
        //SelectList GetLookUp(string Value, string Text, string SelectedValue = "", string GroupBy = "", Expression<Func<T, bool>> expression = null, OrderBy OrderBy = 0, string OrderColumn = null, bool AsNoTracking = true);




    }
}

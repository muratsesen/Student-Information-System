
using System;
using System.Linq.Expressions;

namespace Api.Data.Repositories.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    {
        #region NoAsync

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null);

        T Get(Expression<Func<T, bool>> expression);

        int SaveChanges();

        IQueryable<T> Query();

        TResult InTransaction<TResult>(Func<TResult> action, Action successAction = null, Action<Exception> exceptionAction = null);

        int GetCount(Expression<Func<T, bool>> expression = null);

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> expression = null);

        #endregion

        #region WithAsync

        Task<int> RemoveRangeAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null);

        Task<IEnumerable<T>> GetListWithIncludeAsync(Expression<Func<T, bool>> expression = null,
            params Expression<Func<T, object>>[] includeProperties);

        Task<IEnumerable<T>> GetListWithIncludeAsync(Expression<Func<T, bool>> expression = null,
            Expression<Func<T, object>> includeProperties = null);

        Task<T> GetAsync(Expression<Func<T, bool>> expression,
            params Expression<Func<T, object>>[] includeProperties);

        Task<int> SaveChangesAsync();

        Task<int> Execute(FormattableString interpolatedQueryString);

        Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null);

        #endregion
    }
}


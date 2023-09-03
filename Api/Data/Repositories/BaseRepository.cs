using System;
using System.Linq.Expressions;
using Api.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : AppDbContext
    {
        public BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        protected AppDbContext Context { get; }

        public TEntity Add(TEntity entity)
        {
            Context.Add(entity);
            SaveChanges();
            return entity;
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Execute(FormattableString interpolatedQueryString)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().FirstOrDefault(expression);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? Context.Set<TEntity>().Count() : Context.Set<TEntity>().Count(expression);
        }

        public Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null
            ? Context.Set<TEntity>().AsNoTracking()
            : Context.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetListWithIncludeAsync(Expression<Func<TEntity, bool>> expression = null,
    params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (expression != null)
                query = query.Where(expression);

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetListWithIncludeAsync(Expression<Func<TEntity, bool>> expression = null,
            Expression<Func<TEntity, object>> includeProperties = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (expression != null)
                query = query.Where(expression);

            if (includeProperties != null)
                query = query.Include(includeProperties);

            // query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync();
        }


        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public TResult InTransaction<TResult>(Func<TResult> action, Action successAction = null, Action<Exception> exceptionAction = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public Task<int> RemoveRangeAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            Context.Update(entity);
            SaveChanges();
            return entity;
        }
    }
}


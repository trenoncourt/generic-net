using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using GenericNet.Repository.Abstractions;

namespace GenericNet.Repository.Ef6
{
    public class RepositoryAsync<TDbContext, TEntity> : Repository<TDbContext, TEntity>, IRepositoryAsync<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        public RepositoryAsync(TDbContext context) : base(context)
        {
        }
        public virtual async Task<IEnumerable<TEntity>> SelectAsync(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            IQueryable<TEntity> query = Query(where, orderBy, includes, skipPage, takePage, skip, take, tracking);
            return await query.ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TResult>> SelectAsync<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            IQueryable<TEntity> query = Query(where, orderBy, includes, skipPage, takePage, skip, take, tracking);
            return await query.Select(select).ToListAsync().ConfigureAwait(false);
        }

        public virtual Task<TEntity> FindAsync(params object[] keyValues)
        {
            return DbSet.FindAsync(keyValues);
        }

        public virtual Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return DbSet.FindAsync(keyValues, cancellationToken);
        }

        public virtual Task<TEntity> FindFirstAsync(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            IQueryable<TEntity> query = Query(where, orderBy, includes, skipPage, takePage, skip, take, tracking);
            return query.FirstOrDefaultAsync();
        }

        public virtual Task<TResult> FindFirstAsync<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            IQueryable<TEntity> query = Query(where, orderBy, includes, skipPage, takePage, skip, take, tracking);
            return query.Select(select).FirstOrDefaultAsync();
        }

        public virtual Task<TEntity> FindLastAsync(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            IQueryable<TEntity> query = Query(where, orderBy, includes, skipPage, takePage, skip, take, tracking);
            return query.OrderByDescending(x => x).FirstOrDefaultAsync();
        }

        public virtual Task<TResult> FindLastAsync<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            IQueryable<TEntity> query = Query(where, orderBy, includes, skipPage, takePage, skip, take, tracking);
            return query.Select(select).OrderByDescending(x => x).FirstOrDefaultAsync();
        }
        
        public virtual Task<bool> DeleteAsync(object key)
        {
            return DeleteAsync(CancellationToken.None, key);
        }

        public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, object key)
        {
            var entity = await FindAsync(cancellationToken, key).ConfigureAwait(false);

            if (entity == null)
            {
                return false;
            }
            
            DbSet.Remove(entity);

            return true;
        }
    }
}
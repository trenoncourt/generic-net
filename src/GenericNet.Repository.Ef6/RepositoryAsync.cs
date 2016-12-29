using System.Collections.Generic;
using System.Data.Entity;
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

        public virtual Task<TEntity> FindAsync(params object[] keyValues)
        {
            return DbSet.FindAsync(keyValues);
        }

        public virtual Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return DbSet.FindAsync(cancellationToken, keyValues);
        }

        public virtual async Task<IEnumerable<TEntity>> SelectAsync(bool activateTracking = false)
        {
            return await DbSet.ToListAsync().ConfigureAwait(false);
        }

        public virtual Task<bool> DeleteAsync(params object[] keyValues)
        {
            return DeleteAsync(keyValues, CancellationToken.None);
        }

        public virtual async Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            var entity = await FindAsync(cancellationToken, keyValues).ConfigureAwait(false);

            if (entity == null)
            {
                return false;
            }
            
            DbSet.Remove(entity);

            return true;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace GenericNet.Service.Abstractions
{
    public interface IService<TIdentifier, TEntity> 
        where TIdentifier : class
        where TEntity : class
    {
        TEntity Find(params object[] keyValues);

        IEnumerable<TEntity> Select(bool activateTracking = false);

        TEntity Insert(TEntity entity);

        void InsertRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        void Delete(params object[] keyValues);

        void Delete(TEntity entity);

        IQueryable<TEntity> Queryable(bool activateTracking = false);
    }
}
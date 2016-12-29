using System.Collections.Generic;
using System.Linq;

namespace GenericNet.Service.Abstractions
{
    public interface IService<TIdentifier, TEntity> 
        where TIdentifier : class
        where TEntity : class
    {
        TEntity Find(object key, bool activateTracking = false);
        TEntity Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        IQueryable<TEntity> Queryable();
    }
}
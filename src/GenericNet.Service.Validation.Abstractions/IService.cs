using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace GenericNet.Service.Validation.Abstractions
{
    public interface IServiceValidator<TIdentifier, TEntity, TValidator> 
        where TIdentifier : class
        where TEntity : class
        where TValidator : IValidator<TEntity>
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
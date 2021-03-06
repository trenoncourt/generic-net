﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace GenericNet.Service.Validation.Abstractions
{
    public interface IServiceValidatorAsync<TIdentifier, TEntity, TValidator> : IServiceValidator<TIdentifier, TEntity, TValidator> 
        where TIdentifier : class
        where TEntity : class
        where TValidator : IValidator<TEntity>
    {
        Task<TEntity> FindAsync(object key, bool activateTracking = false);

        Task<TEntity> FindAsync(CancellationToken cancellationToken, object key, bool activateTracking = false);

        Task<TEntity> FindAsync(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false);

        Task<TResult> FindAsync<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false);

        Task<TEntity> FindLastAsync(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false);

        Task<bool> DeleteAsync(object key);

        Task<bool> DeleteAsync(CancellationToken cancellationToken, object key);

        Task<IEnumerable<TEntity>> SelectAsync(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false);

        Task<IEnumerable<TResult>> SelectAsync<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false);
    }
}
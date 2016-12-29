using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GenericNet.Queryable.Extensions.Ef6
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Asynchronously creates a System.Collections.Generic.List`1 from an System.Linq.IQueryable`1 by enumerating it asynchronously.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">An System.Linq.IQueryable`1 to create a list from.</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains a System.Collections.Generic.List`1 that contains elements from the input sequence.
        /// </returns>
        /// <remarks>
        /// Multiple active operations on the same context instance are not supported. 
        /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
        /// </remarks>
        public static Task<List<TSource>> ToListAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken = default(CancellationToken))
        {
            return System.Data.Entity.QueryableExtensions.ToListAsync(source, cancellationToken);
        }

        public static Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source);
        }

        public static Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source, cancellationToken);
        }

        public static Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source, predicate);
        }

        public static Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source, predicate, cancellationToken);
        }

        public static Task<TSource> LastOrDefaultAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source.OrderByDescending(x => x));
        }

        public static Task<TSource> LastOrDefaultAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source.OrderByDescending(x => x), cancellationToken);
        }

        public static Task<TSource> LastOrDefaultAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source.OrderByDescending(x => x), predicate);
        }

        public static Task<TSource> LastOrDefaultAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source.OrderByDescending(x => x), predicate, cancellationToken);
        }
    }
}
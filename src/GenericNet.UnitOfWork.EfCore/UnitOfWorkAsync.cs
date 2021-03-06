﻿using System;
using System.Threading;
using System.Threading.Tasks;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GenericNet.UnitOfWork.EfCore
{
    public class UnitOfWorkAsync<TIdentifier> : UnitOfWork<TIdentifier>, IUnitOfWorkAsync<TIdentifier> where TIdentifier : class
    {
        public UnitOfWorkAsync(IServiceProvider serviceProvider, DbContextOptions dbContextOptions) : base(serviceProvider, dbContextOptions)
        {
        }

        public new async Task SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            await base.SaveChangesAsync(cancellationToken);
        }

        public IRepositoryAsync<TIdentifier, TEntity> RepositoryAsync<TEntity>() where TEntity : class
        {
            return ServiceProvider.GetService<IRepositoryAsync<TIdentifier, TEntity>>();
        }
    }
}
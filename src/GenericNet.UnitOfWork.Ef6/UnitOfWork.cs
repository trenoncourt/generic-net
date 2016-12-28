using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;
using GenericNet.UnitOfWork.Ef6.Extensions;
using Microsoft.Extensions.DependencyInjection;
using IsolationLevel = GenericNet.UnitOfWork.Abstractions.IsolationLevel;

namespace GenericNet.UnitOfWork.Ef6
{
    public class UnitOfWork<TIdentifier> : DbContext, IUnitOfWork<TIdentifier> where TIdentifier : class
    {
        protected readonly IServiceProvider ServiceProvider;
        protected IDbConnection Connection;
        protected IDbTransaction Transaction;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public virtual void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)this).ObjectContext;
            if (objectContext.Connection.State != ConnectionState.Open)
            {
                objectContext.Connection.Open();
            }
            Transaction = objectContext.Connection.BeginTransaction(isolationLevel.ToEfCoreIsolationLevel());
        }

        public virtual void Commit()
        {
            Transaction.Commit();
        }

        public virtual void Rollback()
        {
            Transaction.Rollback();
        }

        public IRepository<TIdentifier, TEntity> Repository<TEntity>() where TEntity : class
        {
            return ServiceProvider.GetService<IRepository<TIdentifier, TEntity>>();
        }
    }
}
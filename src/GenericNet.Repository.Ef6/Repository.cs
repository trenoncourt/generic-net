﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using GenericNet.Repository.Abstractions;

namespace GenericNet.Repository.Ef6
{
    public class Repository<TDbContext, TEntity> : IRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {

        public Repository(TDbContext context)
        {
            DbSet = context.Set<TEntity>();
        }

        protected readonly DbSet<TEntity> DbSet;

        public virtual TEntity Find(params object[] key)
        {
            return DbSet.Find(key);
        }

        public virtual IEnumerable<TEntity> Select(bool activateTracking = false)
        {
            return activateTracking ? DbSet.ToList() : DbSet.AsNoTracking().ToList();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual TEntity Update(TEntity entity)
        {
            DbSet.AddOrUpdate(entity);
            return entity;
        }

        public virtual void Delete(params object[] keyValues)
        {
            var entity = Find(keyValues);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual IQueryable<TEntity> Queryable(bool activateTracking = false)
        {
            return activateTracking ? DbSet : DbSet.AsNoTracking();
        }
    }
}
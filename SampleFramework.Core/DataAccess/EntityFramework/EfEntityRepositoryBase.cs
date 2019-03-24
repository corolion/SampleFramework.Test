using SampleFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SampleFramework.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> query = null)
        {
            using (var context = new TContext())
            {
                return query == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(query).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> query)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(query);
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var insertedEntity = context.Entry(entity);
                insertedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}

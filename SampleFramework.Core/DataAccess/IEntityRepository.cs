using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SampleFramework.Core.Entities;

namespace SampleFramework.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetList(Expression<Func<T, bool>> query = null);
        T Get(Expression<Func<T, bool>> query = null);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
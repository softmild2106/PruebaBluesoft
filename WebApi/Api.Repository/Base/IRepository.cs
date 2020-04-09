using Api.Database.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Api.Repository.Base
{
public interface IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        TEntity GetById(TKey id);
        IEnumerable<TEntity> List();
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Update(TEntity entity);
    }
}

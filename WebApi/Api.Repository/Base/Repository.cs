using Api.Database.Base;
using Api.Database.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Api.Repository.Base
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        protected readonly ApiContext _dbContext;

        public Repository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TEntity Add(TEntity entity)
        {
            entity.LastModifiedOn = DateTime.Now;
            entity.CreatedOn = DateTime.Now;
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity editedEntity)
        {
            editedEntity.LastModifiedOn = DateTime.Now;
            editedEntity.LastModifiedBy = 1;
            _dbContext.Entry(editedEntity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return editedEntity;
        }

        public TEntity GetById(TKey id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> List()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>()
            .Where(predicate)
            .AsEnumerable();
        }
    }
}

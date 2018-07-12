using ApiJwtEFInMemory.DDD.Domain.Interfaces;
using ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.DDD.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ApiJwtEFInMemory.DDD.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork UnitOfWork;

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Add(TEntity obj)
        {
            UnitOfWork.Set<TEntity>().Add(obj);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            UnitOfWork.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return UnitOfWork.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = UnitOfWork.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (string includeProperty in includeProperties.Split
                      (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public TEntity GetBy(Expression<Func<TEntity, bool>> predicate, string includeProperties = "")
        {
            IQueryable<TEntity> query = UnitOfWork.Set<TEntity>();
            foreach (string includeProperty in includeProperties.Split
                      (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate).FirstOrDefault();
        }

        public TEntity GetById(int id)
        {
            return UnitOfWork.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            UnitOfWork.Set<TEntity>().Remove(obj);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            UnitOfWork.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity obj)
        {
            UnitOfWork.Entry(obj).State = EntityState.Modified;
        }

    }
}

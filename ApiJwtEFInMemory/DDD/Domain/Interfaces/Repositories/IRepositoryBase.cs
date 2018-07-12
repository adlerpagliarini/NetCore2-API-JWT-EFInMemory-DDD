using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void AddRange(IEnumerable<TEntity> entities);

        TEntity GetById(int id);

        TEntity GetBy(Expression<Func<TEntity, bool>> predicate, 
                      string includeProperties = "");

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
                       Func<IQueryable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null,
                       string includeProperties = "");

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TEntity obj);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}

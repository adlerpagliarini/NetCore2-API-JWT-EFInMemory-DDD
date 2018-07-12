using ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJwtEFInMemory.DDD.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int Commit();
    }
}

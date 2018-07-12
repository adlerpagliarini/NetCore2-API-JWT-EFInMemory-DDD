using ApiJwtEFInMemory.DDD.Domain.Interfaces;
using ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.DDD.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJwtEFInMemory.DDD.Infra.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return _context.Entry(entity);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}

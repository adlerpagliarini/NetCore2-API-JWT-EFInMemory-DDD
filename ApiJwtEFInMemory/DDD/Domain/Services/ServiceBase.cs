using ApiJwtEFInMemory.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ApiJwtEFInMemory.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        public IRepositoryBase<TEntity> _repository { get; }

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public virtual void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}

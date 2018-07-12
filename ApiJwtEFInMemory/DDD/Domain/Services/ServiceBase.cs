
using ApiJwtEFInMemory.DDD.Domain.Entities;
using ApiJwtEFInMemory.DDD.Domain.Interfaces;
using ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.DDD.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ApiJwtEFInMemory.DDD.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected IUnitOfWork _unitOfWork { get; }
        protected IRepositoryBase<TEntity> _repository { get; }

        public ServiceBase(IUnitOfWork unitOfWork, IRepositoryBase<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
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

        public virtual int Commit() { return _unitOfWork.Commit(); }
    }
}

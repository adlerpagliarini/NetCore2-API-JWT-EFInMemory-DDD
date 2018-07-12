using ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.DDD.Domain.Entities;
using ApiJwtEFInMemory.DDD.Infra.Context;
using ApiJwtEFInMemory.DDD.Domain.Interfaces;

namespace ApiJwtEFInMemory.DDD.Infra.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Usuario GetById(string id)
        {
            return UnitOfWork.Set<Usuario>().Find(id);
        }
    }
}

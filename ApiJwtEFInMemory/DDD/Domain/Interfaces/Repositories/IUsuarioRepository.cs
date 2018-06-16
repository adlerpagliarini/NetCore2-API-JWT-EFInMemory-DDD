using ApiJwtEFInMemory.DDD.Domain.Entities;

namespace ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario GetById(string id);
    }
}

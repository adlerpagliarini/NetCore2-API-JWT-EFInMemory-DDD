using ApiJwtEFInMemory.DDD.Domain.Entities;

namespace ApiJwtEFInMemory.DDD.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        bool Remove(string id, Usuario usuario);
        Usuario GetById(string id);
    }
}

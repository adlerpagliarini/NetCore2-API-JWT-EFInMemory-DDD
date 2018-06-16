using ApiJwtEFInMemory.DDD.Domain.Entities;

namespace ApiJwtEFInMemory.DDD.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        new bool Remove(Usuario usuario);
        Usuario GetById(string id);
    }
}

using ApiJwtEFInMemory.DDD.Domain.Interfaces.Services;
using ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.DDD.Domain.Entities;

namespace ApiJwtEFInMemory.DDD.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario GetById(string id)
        {
            return _usuarioRepository.GetById(id);
        }

        public new bool Remove(Usuario usuario)
        {
            var u = _usuarioRepository.GetById(usuario.ID);
            //var teste = Comparer.Compare<Usuario>(u, usuario);

            if (!(u is null) && u.Equals(usuario))
                base.Remove(u);
            else
                return false;

            return true;
        }

    }
}

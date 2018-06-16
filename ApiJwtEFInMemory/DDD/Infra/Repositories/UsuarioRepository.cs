using ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.DDD.Domain.Entities;
using ApiJwtEFInMemory.DDD.Infra.Context;

namespace ApiJwtEFInMemory.DDD.Infra.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly DataContext _context;
        public UsuarioRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Usuario GetById(string id)
        {
            return Context.Set<Usuario>().Find(id);
        }
    }
}

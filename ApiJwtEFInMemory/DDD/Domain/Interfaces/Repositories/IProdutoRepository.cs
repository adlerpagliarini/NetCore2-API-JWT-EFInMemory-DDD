using ApiJwtEFInMemory.DDD.Domain.Entities;
using System.Collections.Generic;

namespace ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
        IEnumerable<Produto> BuscarPorCodigoBarras(string codigoBarras);
    }
}

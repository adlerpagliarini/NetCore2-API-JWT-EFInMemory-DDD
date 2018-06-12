using ApiJwtEFInMemory.Domain.Models;
using System.Collections.Generic;

namespace ApiJwtEFInMemory.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
        IEnumerable<Produto> BuscarPorCodigoBarras(string codigoBarras);
    }
}

using ApiJwtEFInMemory.DDD.Domain.Entities;
using System.Collections.Generic;

namespace ApiJwtEFInMemory.DDD.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
        IEnumerable<Produto> BuscarPorCodigoBarras(string nome);
        bool Remove(string codigoBarras);
    }
}

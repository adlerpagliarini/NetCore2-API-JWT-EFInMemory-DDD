
using ApiJwtEFInMemory.Domain.Models;
using System.Collections.Generic;

namespace ApiJwtEFInMemory.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
        IEnumerable<Produto> BuscarPorCodigoBarras(string nome);
        bool Remove(string codigoBarras);
    }
}

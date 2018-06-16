using ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.DDD.Domain.Entities;
using ApiJwtEFInMemory.DDD.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace ApiJwtEFInMemory.DDD.Infra.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return Context.Produtos.Where(p => p.Nome == nome);
        }

        public IEnumerable<Produto> BuscarPorCodigoBarras(string codigoBarras)
        {
            return Context.Produtos.Where(p => p.CodigoBarras == codigoBarras);
        }
    }
}

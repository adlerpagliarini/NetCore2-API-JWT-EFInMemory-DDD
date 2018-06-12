using ApiJwtEFInMemory.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.Domain.Models;
using ApiJwtEFInMemory.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJwtEFInMemory.Infra.Repositories
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

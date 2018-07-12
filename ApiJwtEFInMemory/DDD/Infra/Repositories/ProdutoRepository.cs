using ApiJwtEFInMemory.DDD.Domain.Interfaces;
using ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.DDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ApiJwtEFInMemory.DDD.Infra.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return UnitOfWork.Set<Produto>().Where(p => p.Nome == nome);
        }

        public IEnumerable<Produto> BuscarPorCodigoBarras(string codigoBarras)
        {
            return UnitOfWork.Set<Produto>().Where(p => p.CodigoBarras == codigoBarras);
        }
    }
}

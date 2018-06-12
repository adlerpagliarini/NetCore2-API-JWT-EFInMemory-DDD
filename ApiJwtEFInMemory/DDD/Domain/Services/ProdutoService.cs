using ApiJwtEFInMemory.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.Domain.Interfaces.Services;
using ApiJwtEFInMemory.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiJwtEFInMemory.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepository.BuscarPorNome(nome);
        }

        public IEnumerable<Produto> BuscarPorCodigoBarras(string codigoBarras)
        {
            return _produtoRepository.BuscarPorCodigoBarras(codigoBarras);
        }

        public bool Remove(string codigoBarras)
        {
            var produto = _produtoRepository.BuscarPorCodigoBarras(codigoBarras).FirstOrDefault();
            if (produto == null)
                return false;
            else
                _produtoRepository.Remove(produto);

            return true;
        }
    }
}

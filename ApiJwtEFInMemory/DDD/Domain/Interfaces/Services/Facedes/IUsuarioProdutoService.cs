using ApiJwtEFInMemory.DDD.Domain.Entities;
using System.Collections.Generic;

namespace ApiJwtEFInMemory.DDD.Domain.Interfaces.Services.Facedes
{
    public interface IUsuarioProdutoService
    {
        IUsuarioService UsuarioService { get; }
        IProdutoService ProdutoService { get; }

        int Commit();
    }
}

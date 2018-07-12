using ApiJwtEFInMemory.DDD.Domain.Interfaces.Services;
using ApiJwtEFInMemory.DDD.Domain.Interfaces.Services.Facedes;
using ApiJwtEFInMemory.DDD.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.DDD.Domain.Entities;
using ApiJwtEFInMemory.DDD.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ApiJwtEFInMemory.DDD.Domain.Services.Facedes
{
    public class UsuarioProdutoService : IUsuarioProdutoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioService _usuarioService;
        private readonly IProdutoService _produtoService;

        public UsuarioProdutoService(IUnitOfWork unitOfWork, IUsuarioService usuarioService, IProdutoService produtoService)
        {
            _unitOfWork = unitOfWork;
            _usuarioService = usuarioService;
            _produtoService = produtoService;
        }

        public IUsuarioService UsuarioService => _usuarioService;
        public IProdutoService ProdutoService => _produtoService;

        public int Commit()
        {
            return _unitOfWork.Commit();
        }
    }
}

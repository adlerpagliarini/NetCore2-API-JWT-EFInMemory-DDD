using System.Collections.Generic;
using ApiJwtEFInMemory.DDD.Domain.Interfaces.Services;
using ApiJwtEFInMemory.DDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiJwtEFInMemory.DDD.Domain.Interfaces;
using System;
using ApiJwtEFInMemory.DDD.Domain.Interfaces.Services.Facedes;

namespace ApiJwtEFInMemory.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsuarioProdutoController : Controller
    {
        private readonly IUsuarioProdutoService _usuarioProdutoService;

        public UsuarioProdutoController(IUsuarioProdutoService usuarioProdutoService)
        {
            _usuarioProdutoService = usuarioProdutoService;
        }

        [HttpPost]
        public IActionResult Post()
        {
            Random rnd = new Random();
            var aux = rnd.Next();
            var id = "admin" + aux;
            var usrTeste = new Usuario() { ID = id, ChaveAcesso = "admin" };
            _usuarioProdutoService.UsuarioService.Add(usrTeste);
            _usuarioProdutoService.ProdutoService.Add(new Produto() { Nome = "produto", CodigoBarras = aux.ToString(), Preco = 1, Usuario = usrTeste });
            _usuarioProdutoService.Commit();
            return Ok();
        }
        
    }
}
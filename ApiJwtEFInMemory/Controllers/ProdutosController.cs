using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiJwtEFInMemory.Domain.Interfaces.Services;
using ApiJwtEFInMemory.Domain.Models;
using ApiJwtEFInMemory.Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace ApiJwtEFInMemory.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _produtoService.GetAll();
        }

        [HttpGet("{nome}")]
        public IActionResult Get(string nome)
        {
            var produto = _produtoService.BuscarPorNome(nome);
            if (produto != null)
                return new ObjectResult(produto);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Produto produto)
        {
            _produtoService.Add(produto);
            return Ok(produto);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Produto produto)
        {
            _produtoService.Update(produto);
            return Ok(produto);
        }

        [HttpDelete("{codigoBarras}")]
        public IActionResult Delete(string codigoBarras)
        {
            if (_produtoService.Remove(codigoBarras))
                return Ok();
            else
                return NotFound();
        }
    }
}
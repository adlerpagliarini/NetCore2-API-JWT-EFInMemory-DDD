﻿using System.Collections.Generic;
using ApiJwtEFInMemory.DDD.Domain.Interfaces.Services;
using ApiJwtEFInMemory.DDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiJwtEFInMemory.DDD.Domain.Interfaces;

namespace ApiJwtEFInMemory.Controllers
{
    [Authorize("Bearer")]
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
            _produtoService.Commit();
            return Ok(produto);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Produto produto)
        {
            _produtoService.Update(produto);
            _produtoService.Commit();
            return Ok(produto);
        }

        [HttpDelete("{codigoBarras}")]
        public IActionResult Delete(string codigoBarras)
        {
            if (_produtoService.Remove(codigoBarras))
            {
                _produtoService.Commit();
                return Ok();
            }                
            else
                return NotFound();
        }
    }
}
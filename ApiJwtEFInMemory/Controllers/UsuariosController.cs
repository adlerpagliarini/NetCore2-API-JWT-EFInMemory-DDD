using ApiJwtEFInMemory.DDD.Domain.Interfaces.Services;
using ApiJwtEFInMemory.DDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiJwtEFInMemory.Controllers
{
    [Authorize("Bearer")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario != null)
                return new ObjectResult(usuario);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Usuario usuario)
        {
            _usuarioService.Add(usuario);
            return Ok(usuario);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Usuario usuario)
        {
            _usuarioService.Update(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] string id,[FromBody] Usuario usuario)
        {
            if (id == usuario.ID && _usuarioService.Remove(usuario))
                return Ok();
            else
                return NotFound();
        }
    }
}
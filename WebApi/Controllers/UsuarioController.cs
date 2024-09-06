using dominio.Interfaces.Generics;
using Entities.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using webApi.Controllers.Dtos;
using Application.Services;
using Domain.Interfaces.InterfaceServico;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> AddUsuario([FromBody] UsuarioCreateDTO novoUsuario)
        {
            await _usuarioService.AddUsuario(novoUsuario);
            return Ok("Usuário cadastrado com sucesso.");
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ListUsuarios()
        {
            return Ok(await _usuarioService.ListUsuarios());
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] UsuarioCreateDTO usuarioAtualizado)
        {
            await _usuarioService.UpdateUsuario(id, usuarioAtualizado);
            return Ok("Usuário atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarioService.DeleteUsuario(id);
            return NoContent();

        }
    }
}

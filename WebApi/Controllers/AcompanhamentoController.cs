using Domain.Interfaces.InterfaceServico;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcompanhamentoController : ControllerBase
    {
        private readonly IAcompanhamentoService _acompanhamentoService;

        public AcompanhamentoController(IAcompanhamentoService acompanhamentoService)
        {
            _acompanhamentoService = acompanhamentoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAcompanhamento([FromBody] AcompanhamentoCreateDTO acompanhamentoDto)
        {
            await _acompanhamentoService.AddAcompanhamento(acompanhamentoDto);
            return Ok("Acompanhamento cadastrado com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAcompanhamento(int id, [FromBody] AcompanhamentoCreateDTO acompanhamentoDto)
        {
            await _acompanhamentoService.UpdateAcompanhamento(id, acompanhamentoDto);
            return Ok("Acompanhamento atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcompanhamento(int id)
        {
            await _acompanhamentoService.DeleteAcompanhamento(id);
            return Ok("Acompanhamento excluído com sucesso.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcompanhamentoById(int id)
        {
            var acompanhamento = await _acompanhamentoService.GetAcompanhamentoById(id);
            if (acompanhamento == null)
            {
                return NotFound("Acompanhamento não encontrado.");
            }
            return Ok(acompanhamento);
        }

        [HttpGet]
        public async Task<ActionResult<List<AcompanhamentoDTO>>> ListAcompanhamentos()
        {
            var acompanhamentos = await _acompanhamentoService.ListAcompanhamentos();
            return Ok(acompanhamentos);
        }
    }
}

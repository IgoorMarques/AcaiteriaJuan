using Domain.Interfaces.InterfaceServico;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoEntregaController : ControllerBase
    {
        private readonly IEnderecoEntregaService _enderecoEntregaService;

        public EnderecoEntregaController(IEnderecoEntregaService enderecoEntregaService)
        {
            _enderecoEntregaService = enderecoEntregaService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EndEntregaCreateDTO endEntregaDto)
        {
            await _enderecoEntregaService.Add(endEntregaDto);
            return Ok("Endereço de entrega cadastrado com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EndEntregaCreateDTO endEntregaDto)
        {
            await _enderecoEntregaService.Update(id, endEntregaDto);
            return Ok("Endereço de entrega atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _enderecoEntregaService.Delete(id);
            return Ok("Endereço de entrega excluído com sucesso.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var endereco = await _enderecoEntregaService.GetById(id);
            return Ok(endereco);
        }

        [HttpGet]
        public async Task<ActionResult<List<EndEntregaDTO>>> List()
        {
            var enderecos = await _enderecoEntregaService.List();
            return Ok(enderecos);
        }
    }
}

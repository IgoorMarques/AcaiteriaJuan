using Domain.Interfaces.InterfaceServico;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcaiController : ControllerBase
    {
        private readonly IAcaiService _acaiService;

        public AcaiController(IAcaiService acaiService)
        {
            _acaiService = acaiService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAcai([FromBody] AcaiCreateDTO acaiDto)
        {
            await _acaiService.AddAcai(acaiDto);
            return Ok("Açai cadastrado com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAcai(int id, [FromBody] AcaiCreateDTO acaiDto)
        {
            await _acaiService.UpdateAcai(id, acaiDto);
            return Ok("Açai atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcai(int id)
        {
            await _acaiService.DeleteAcai(id);
            return Ok("Açai excluído com sucesso.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcaiById(int id)
        {
            var acai = await _acaiService.GetAcaiById(id);
            if (acai == null)
            {
                return NotFound("Açai não encontrado.");
            }
            return Ok(acai);
        }

        [HttpGet]
        public async Task<ActionResult<List<AcaiDTO>>> ListAcai()
        {
            var acais = await _acaiService.ListAcai();
            return Ok(acais);
        }
    }
}

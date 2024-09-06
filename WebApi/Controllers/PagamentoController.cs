using Domain.Interfaces.InterfaceServico;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPagamento([FromBody] PagamentoCreateDTO pagamentoDto)
        {
            await _pagamentoService.AddPagamento(pagamentoDto);
            return Ok("Pagamento cadastrado com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePagamento(int id, [FromBody] PagamentoCreateDTO pagamentoDto)
        {
            await _pagamentoService.UpdatePagamento(id, pagamentoDto);
            return Ok("Pagamento atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamento(int id)
        {
            await _pagamentoService.DeletePagamento(id);
            return Ok("Pagamento excluído com sucesso.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPagamentoById(int id)
        {
            var pagamento = await _pagamentoService.GetPagamentoById(id);
            return Ok(pagamento);
        }

        [HttpGet]
        public async Task<ActionResult<List<PagamentoDTO>>> ListPagamentos()
        {
            var pagamentos = await _pagamentoService.ListPagamentos();
            return Ok(pagamentos);
        }
    }
}

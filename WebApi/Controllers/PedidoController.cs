using Domain.Interfaces.InterfaceServico;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPedido([FromBody] PedidoCreateDTO pedidoDto)
        {
            await _pedidoService.AddPedido(pedidoDto);
            return Ok("Pedido cadastrado com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePedido(int id, [FromBody] PedidoCreateDTO pedidoDto)
        {
            await _pedidoService.UpdatePedido(id, pedidoDto);
            return Ok("Pedido atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            await _pedidoService.DeletePedido(id);
            return Ok("Pedido excluído com sucesso.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoById(int id)
        {
            var pedido = await _pedidoService.GetPedidoById(id);
            return Ok(pedido);
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoDTO>>> ListPedidos()
        {
            var pedidos = await _pedidoService.ListPedidos();
            return Ok(pedidos);
        }
    }
}

using Domain.Interfaces;
using Domain.Interfaces.InterfaceServico;
using dominio.Interfaces.Generics;
using Entities.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly InterfacePedido _interfacePedido;

        public PedidoService(InterfacePedido interfacePedido)
        {
            _interfacePedido = interfacePedido;
        }

        public async Task AddPedido(PedidoCreateDTO pedidoDto)
        {
            var pedido = new Pedido
            {
                Status = pedidoDto.Status,
                DataPedido = pedidoDto.DataPedido,
                FormaPagamento = pedidoDto.FormaPagamento,
                IdUsuario_FK = pedidoDto.IdUsuario
            };

            await _interfacePedido.Add(pedido);
        }

        public async Task UpdatePedido(int id, PedidoCreateDTO pedidoDto)
        {
            var pedido = await _interfacePedido.GetEntityByID(id);
            if (pedido == null)
                throw new KeyNotFoundException("Pedido não encontrado.");

            pedido.Status = pedidoDto.Status;
            pedido.DataPedido = pedidoDto.DataPedido;
            pedido.FormaPagamento = pedidoDto.FormaPagamento;
            pedido.IdUsuario_FK = pedidoDto.IdUsuario;

            await _interfacePedido.Update(pedido);
        }

        public async Task DeletePedido(int id)
        {
            var pedido = await _interfacePedido.GetEntityByID(id);
            if (pedido == null)
                throw new KeyNotFoundException("Pedido não encontrado.");

            await _interfacePedido.Delete(pedido);
        }

        public async Task<PedidoDTO> GetPedidoById(int id)
        {
            var pedido = await _interfacePedido.GetEntityByID(id);
            if (pedido == null)
                throw new KeyNotFoundException("Pedido não encontrado.");

            return new PedidoDTO
            {
                IdPedido = pedido.IdPedido,
                Status = pedido.Status,
                DataPedido = pedido.DataPedido,
                FormaPagamento = pedido.FormaPagamento,
                IdUsuario = pedido.IdUsuario_FK
            };
        }

        public async Task<List<PedidoDTO>> ListPedidos()
        {
            var pedidos = await _interfacePedido.List();
            return pedidos.Select(pedido => new PedidoDTO
            {
                IdPedido = pedido.IdPedido,
                Status = pedido.Status,
                DataPedido = pedido.DataPedido,
                FormaPagamento = pedido.FormaPagamento,
                IdUsuario = pedido.IdUsuario_FK
            }).ToList();
        }
    }
}

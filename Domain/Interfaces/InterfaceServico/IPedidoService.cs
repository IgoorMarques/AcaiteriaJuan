using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace Domain.Interfaces.InterfaceServico
{
    public interface IPedidoService
    {
        Task AddPedido(PedidoCreateDTO pedidoDto);
        Task UpdatePedido(int id, PedidoCreateDTO pedidoDto);
        Task DeletePedido(int id);
        Task<PedidoDTO> GetPedidoById(int id);
        Task<List<PedidoDTO>> ListPedidos();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace Domain.Interfaces.InterfaceServico
{
    public interface IPagamentoService
    {
        Task AddPagamento(PagamentoCreateDTO pagamentoDto);
        Task UpdatePagamento(int id, PagamentoCreateDTO pagamentoDto);
        Task DeletePagamento(int id);
        Task<PagamentoDTO> GetPagamentoById(int id);
        Task<List<PagamentoDTO>> ListPagamentos();
    }
}

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
    public class PagamentoService : IPagamentoService
    {
        private readonly InterfacePagamento _interfacePagamento;

        public PagamentoService(InterfacePagamento interfacePagamento)
        {
            _interfacePagamento = interfacePagamento;
        }

        public async Task AddPagamento(PagamentoCreateDTO pagamentoDto)
        {
            var pagamento = new Pagamento
            {
                Valor = pagamentoDto.Valor,
                Status = pagamentoDto.Status,
                Descricao = pagamentoDto.Descricao,
                IdPedido_FK = pagamentoDto.IdPedido
            };

            await _interfacePagamento.Add(pagamento);
        }

        public async Task UpdatePagamento(int id, PagamentoCreateDTO pagamentoDto)
        {
            var pagamento = await _interfacePagamento.GetEntityByID(id);
            if (pagamento == null)
                throw new KeyNotFoundException("Pagamento não encontrado.");

            pagamento.Valor = pagamentoDto.Valor;
            pagamento.Status = pagamentoDto.Status;
            pagamento.Descricao = pagamentoDto.Descricao;
            pagamento.IdPedido_FK = pagamentoDto.IdPedido;

            await _interfacePagamento.Update(pagamento);
        }

        public async Task DeletePagamento(int id)
        {
            var pagamento = await _interfacePagamento.GetEntityByID(id);
            if (pagamento == null)
                throw new KeyNotFoundException("Pagamento não encontrado.");

            await _interfacePagamento.Delete(pagamento);
        }

        public async Task<PagamentoDTO> GetPagamentoById(int id)
        {
            var pagamento = await _interfacePagamento.GetEntityByID(id);
            if (pagamento == null)
                throw new KeyNotFoundException("Pagamento não encontrado.");

            return new PagamentoDTO
            {
                IdPagamento = pagamento.IdPagamento,
                Valor = pagamento.Valor,
                Status = pagamento.Status,
                Descricao = pagamento.Descricao,
                IdPedido = pagamento.IdPedido_FK
            };
        }

        public async Task<List<PagamentoDTO>> ListPagamentos()
        {
            var pagamentos = await _interfacePagamento.List();
            return pagamentos.Select(pagamento => new PagamentoDTO
            {
                IdPagamento = pagamento.IdPagamento,
                Valor = pagamento.Valor,
                Status = pagamento.Status,
                Descricao = pagamento.Descricao,
                IdPedido = pagamento.IdPedido_FK
            }).ToList();
        }
    }
}

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
    public class AcompanhamentoService : IAcompanhamentoService
    {
        private readonly InterfaceAcompanhamento _interfaceAcompanhamento;

        public AcompanhamentoService(InterfaceAcompanhamento interfaceAcompanhamento)
        {
            _interfaceAcompanhamento = interfaceAcompanhamento;
        }

        public async Task AddAcompanhamento(AcompanhamentoCreateDTO acompanhamentoDto)
        {
            var acompanhamento = new Acompanhamento
            {
                Nome = acompanhamentoDto.Nome,
                Descricao = acompanhamentoDto.Descricao,
                Valor = acompanhamentoDto.Valor,
                Tipo = acompanhamentoDto.Tipo
            };

            await _interfaceAcompanhamento.Add(acompanhamento);
        }

        public async Task UpdateAcompanhamento(int id, AcompanhamentoCreateDTO acompanhamentoDto)
        {
            var acompanhamento = await _interfaceAcompanhamento.GetEntityByID(id);
            if (acompanhamento == null)
                throw new KeyNotFoundException("Acompanhamento não encontrado.");

            acompanhamento.Nome = acompanhamentoDto.Nome;
            acompanhamento.Descricao = acompanhamentoDto.Descricao;
            acompanhamento.Valor = acompanhamentoDto.Valor;
            acompanhamento.Tipo = acompanhamentoDto.Tipo;

            await _interfaceAcompanhamento.Update(acompanhamento);
        }

        public async Task DeleteAcompanhamento(int id)
        {
            var acompanhamento = await _interfaceAcompanhamento.GetEntityByID(id);
            if (acompanhamento == null)
                throw new KeyNotFoundException("Acompanhamento não encontrado.");

            await _interfaceAcompanhamento.Delete(acompanhamento);
        }

        public async Task<AcompanhamentoDTO> GetAcompanhamentoById(int id)
        {
            var acompanhamento = await _interfaceAcompanhamento.GetEntityByID(id);
            if (acompanhamento == null)
                throw new KeyNotFoundException("Acompanhamento não encontrado.");

            return new AcompanhamentoDTO
            {
                IdAcompanhamento = acompanhamento.IdAcompanhamento,
                Nome = acompanhamento.Nome,
                Descricao = acompanhamento.Descricao,
                Valor = acompanhamento.Valor,
                Tipo = acompanhamento.Tipo
            };
        }

        public async Task<List<AcompanhamentoDTO>> ListAcompanhamentos()
        {
            var acompanhamentos = await _interfaceAcompanhamento.List();
            return acompanhamentos.Select(acompanhamento => new AcompanhamentoDTO
            {
                IdAcompanhamento = acompanhamento.IdAcompanhamento,
                Nome = acompanhamento.Nome,
                Descricao = acompanhamento.Descricao,
                Valor = acompanhamento.Valor,
                Tipo = acompanhamento.Tipo
            }).ToList();
        }
    }
}

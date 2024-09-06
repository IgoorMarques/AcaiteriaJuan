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
    public class AcaiService : IAcaiService
    {
        private readonly InterfaceAcai _interfaceAcai;

        public AcaiService(InterfaceAcai interfaceAcai)
        {
            _interfaceAcai = interfaceAcai;
        }

        public async Task AddAcai(AcaiCreateDTO acaiDto)
        {
            var acai = new Acai
            {
                Nome = acaiDto.Nome,
                Descricao = acaiDto.Descricao,
                MaxAcompahamentoGratuito = acaiDto.MaxAcompahamentoGratuito,
                Valor = acaiDto.Valor,
                MaxAdicional = acaiDto.MaxAdicional
            };

            await _interfaceAcai.Add(acai);
        }

        public async Task UpdateAcai(int id, AcaiCreateDTO acaiDto)
        {
            var acai = await _interfaceAcai.GetEntityByID(id);
            if (acai == null)
                throw new KeyNotFoundException("Açai não encontrado.");

            acai.Nome = acaiDto.Nome;
            acai.Descricao = acaiDto.Descricao;
            acai.MaxAcompahamentoGratuito = acaiDto.MaxAcompahamentoGratuito;
            acai.Valor = acaiDto.Valor;
            acai.MaxAdicional = acaiDto.MaxAdicional;

            await _interfaceAcai.Update(acai);
        }

        public async Task DeleteAcai(int id)
        {
            var acai = await _interfaceAcai.GetEntityByID(id);
            if (acai == null)
                throw new KeyNotFoundException("Açai não encontrado.");

            await _interfaceAcai.Delete(acai);
        }

        public async Task<AcaiDTO> GetAcaiById(int id)
        {
            var acai = await _interfaceAcai.GetEntityByID(id);
            if (acai == null)
                throw new KeyNotFoundException("Açai não encontrado.");

            return new AcaiDTO
            {
                IdAcai = acai.IdAcai,
                Nome = acai.Nome,
                Descricao = acai.Descricao,
                MaxAcompahamentoGratuito = acai.MaxAcompahamentoGratuito,
                Valor = acai.Valor,
                MaxAdicional = acai.MaxAdicional
            };
        }

        public async Task<List<AcaiDTO>> ListAcai()
        {
            var acais = await _interfaceAcai.List();
            return acais.Select(acai => new AcaiDTO
            {
                IdAcai = acai.IdAcai,
                Nome = acai.Nome,
                Descricao = acai.Descricao,
                MaxAcompahamentoGratuito = acai.MaxAcompahamentoGratuito,
                Valor = acai.Valor,
                MaxAdicional = acai.MaxAdicional
            }).ToList();
        }
    }
}

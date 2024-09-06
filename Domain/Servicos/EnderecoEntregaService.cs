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
    public class EnderecoEntregaService : IEnderecoEntregaService
    {
        private readonly InterfaceEnderecoEntrega _interfaceEnderecoEntrega;

        public EnderecoEntregaService(InterfaceEnderecoEntrega interfaceEnderecoEntrega)
        {
            _interfaceEnderecoEntrega = interfaceEnderecoEntrega;
        }

        public async Task Add(EndEntregaCreateDTO endEntregaDto)
        {
            var endEntrega = new EnderocoEntrega
            {
                EnderecoEntrega = endEntregaDto.EnderecoEntrega,
                IdUsuario_FK = endEntregaDto.IdUsuario
            };

            await _interfaceEnderecoEntrega.Add(endEntrega);
        }

        public async Task Update(int id, EndEntregaCreateDTO endEntregaDto)
        {
            var endEntrega = await _interfaceEnderecoEntrega.GetEntityByID(id);
            if (endEntrega == null)
                throw new KeyNotFoundException("Endereço de entrega não encontrado.");

            endEntrega.EnderecoEntrega = endEntregaDto.EnderecoEntrega;
            endEntrega.IdUsuario_FK = endEntregaDto.IdUsuario;

            await _interfaceEnderecoEntrega.Update(endEntrega);
        }

        public async Task Delete(int id)
        {
            var endEntrega = await _interfaceEnderecoEntrega.GetEntityByID(id);
            if (endEntrega == null)
                throw new KeyNotFoundException("Endereço de entrega não encontrado.");

            await _interfaceEnderecoEntrega.Delete(endEntrega);
        }

        public async Task<EndEntregaDTO> GetById(int id)
        {
            var endEntrega = await _interfaceEnderecoEntrega.GetEntityByID(id);
            if (endEntrega == null)
                throw new KeyNotFoundException("Endereço de entrega não encontrado.");

            return new EndEntregaDTO
            {
                EndEntrega_PK = endEntrega.EndEntrega_PK,
                EnderecoEntrega = endEntrega.EnderecoEntrega,
                IdUsuario = endEntrega.IdUsuario_FK
            };
        }

        public async Task<List<EndEntregaDTO>> List()
        {
            var endEntregas = await _interfaceEnderecoEntrega.List();
            return endEntregas.Select(endEntrega => new EndEntregaDTO
            {
                EndEntrega_PK = endEntrega.EndEntrega_PK,
                EnderecoEntrega = endEntrega.EnderecoEntrega,
                IdUsuario = endEntrega.IdUsuario_FK
            }).ToList();
        }
    }
}

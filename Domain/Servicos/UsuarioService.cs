using Domain.Interfaces.InterfaceServico;
using Domain.Interfaces;
using dominio.Interfaces;
using Entities.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly InterfaceUsuario _usuarioRepository;

        public UsuarioService(InterfaceUsuario usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task AddUsuario(UsuarioCreateDTO usuarioDto)
        {
            var usuario = new Usuario
            {
                NomeCompleto = usuarioDto.NomeCompleto,
                Telefone1 = usuarioDto.Telefone1,
                Telefone2 = usuarioDto.Telefone2,
                TaxaEntrega = usuarioDto.TaxaEntrega
            };

            await _usuarioRepository.Add(usuario);
        }

        public async Task UpdateUsuario(int id, UsuarioCreateDTO usuarioDto)
        {
            var usuario = await _usuarioRepository.GetEntityByID(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            usuario.NomeCompleto = usuarioDto.NomeCompleto;
            usuario.Telefone1 = usuarioDto.Telefone1;
            usuario.Telefone2 = usuarioDto.Telefone2;
            usuario.TaxaEntrega = usuarioDto.TaxaEntrega;

            await _usuarioRepository.Update(usuario);
        }

        public async Task DeleteUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetEntityByID(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            await _usuarioRepository.Delete(usuario);
        }

        public async Task<UsuarioDTO> GetUsuarioById(int id)
        {
            var usuario = await _usuarioRepository.GetEntityByID(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            return new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                NomeCompleto = usuario.NomeCompleto,
                Telefone1 = usuario.Telefone1,
                Telefone2 = usuario.Telefone2,
                TaxaEntrega = usuario.TaxaEntrega
            };
        }

        public async Task<List<UsuarioDTO>> ListUsuarios()
        {
            var usuarios = await _usuarioRepository.List();
            return usuarios.Select(u => new UsuarioDTO
            {
                IdUsuario = u.IdUsuario,
                NomeCompleto = u.NomeCompleto,
                Telefone1 = u.Telefone1,
                Telefone2 = u.Telefone2,
                TaxaEntrega = u.TaxaEntrega
            }).ToList();
        }
    }
}

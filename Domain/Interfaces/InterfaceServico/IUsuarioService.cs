using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace Domain.Interfaces.InterfaceServico
{
    public interface IUsuarioService
    {
        Task AddUsuario(UsuarioCreateDTO usuarioDto);
        Task UpdateUsuario(int id, UsuarioCreateDTO usuarioDto);
        Task DeleteUsuario(int id);
        Task<UsuarioDTO> GetUsuarioById(int id);
        Task<List<UsuarioDTO>> ListUsuarios();
    }
}

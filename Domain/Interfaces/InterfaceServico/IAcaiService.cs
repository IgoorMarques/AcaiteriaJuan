using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace Domain.Interfaces.InterfaceServico
{
    public interface IAcaiService
    {
        Task AddAcai(AcaiCreateDTO usuarioDto);
        Task UpdateAcai(int id, AcaiCreateDTO usuarioDto);
        Task DeleteAcai(int id);
        Task<AcaiDTO> GetAcaiById(int id);
        Task<List<AcaiDTO>> ListAcai();
    }
}

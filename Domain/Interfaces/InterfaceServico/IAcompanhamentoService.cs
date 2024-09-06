using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace Domain.Interfaces.InterfaceServico
{
    public interface IAcompanhamentoService
    {
        Task AddAcompanhamento(AcompanhamentoCreateDTO acompanhamentoDto);
        Task UpdateAcompanhamento(int id, AcompanhamentoCreateDTO acompanhamentoDto);
        Task DeleteAcompanhamento(int id);
        Task<AcompanhamentoDTO> GetAcompanhamentoById(int id);
        Task<List<AcompanhamentoDTO>> ListAcompanhamentos();
    }
}

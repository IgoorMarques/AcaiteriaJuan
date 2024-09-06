using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webApi.Controllers.Dtos;

namespace Domain.Interfaces.InterfaceServico
{
    public interface IEnderecoEntregaService
    {
        Task Add(EndEntregaCreateDTO acompanhamentoDto);
        Task Update(int id, EndEntregaCreateDTO acompanhamentoDto);
        Task Delete(int id);
        Task<EndEntregaDTO> GetById(int id);
        Task<List<EndEntregaDTO>> List();
    }
}

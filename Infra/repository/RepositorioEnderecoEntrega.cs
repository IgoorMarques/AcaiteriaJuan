using Domain.Interfaces;
using Entities.Context;
using Entities.Entidades;
using Infra.repository.generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.repository
{
    public class RepositorioEnderecoEntrega : RepositorioGeneric<EnderocoEntrega>, InterfaceEnderecoEntrega
    {
        public RepositorioEnderecoEntrega(ContextBase context) : base(context)
        {
        }
    }
}

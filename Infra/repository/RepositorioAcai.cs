using Domain.Interfaces;
using dominio.Interfaces.Generics;
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
    public class RepositorioAcai : RepositorioGeneric<Acai>, InterfaceAcai
    {
        public RepositorioAcai(ContextBase context) : base(context)
        {
        }
    }
}

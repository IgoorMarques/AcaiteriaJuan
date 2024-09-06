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
    public class RepositorioPagamento : RepositorioGeneric<Pagamento>, InterfacePagamento
    {
        public RepositorioPagamento(ContextBase context) : base(context)
        {
        }
    }
}

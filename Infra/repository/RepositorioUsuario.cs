using Domain.Interfaces;
using dominio.Interfaces;
using Entities.Context;
using Entities.Entidades;
using Infra.repository.generics;

namespace Infra.repository
{
    public class RepositorioUsuario : RepositorioGeneric<Usuario>, InterfaceUsuario
    {
        public RepositorioUsuario(ContextBase context) : base(context)
        {
        }
    }
}

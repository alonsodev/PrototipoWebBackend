using ProtoWeb.Infra.CrossCutting.Net.Constantes;
using System;

namespace ProtoWeb.Domain.Core.Exceptions
{
    public class NombreNullException: DomainException
    {
        public NombreNullException(string message)
            : base(Guid.NewGuid(), ReglaNegocio.RN0002, TipoException.ReglaNegocio, message, string.Empty, null)
        {
        }
    }
}

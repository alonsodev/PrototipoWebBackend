using ProtoWeb.Infra.CrossCutting.Net.Constantes;
using System;

namespace ProtoWeb.Infra.CrossCutting.Net.Exceptions
{
    public class FileNotFoundException: InfrastructureException
    {
        public FileNotFoundException(string message)
            : base(Guid.NewGuid(), ReglaNegocio.RN0003, TipoException.ReglaNegocio, message, string.Empty, null)
        {
        }
    }
}

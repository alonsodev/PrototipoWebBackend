using ProtoWeb.Application.Core.Labels;
using ProtoWeb.Infra.CrossCutting.Net.Constantes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Application.Core.Exceptions
{
    public class ClienteExistenteException : ApplicationException
    {
        public ClienteExistenteException()
           : base(Guid.NewGuid(), ReglaNegocio.RN0002, TipoException.ReglaNegocio, Messages.Cliente_YaExistente, string.Empty, null)
        {
        }
    }
}

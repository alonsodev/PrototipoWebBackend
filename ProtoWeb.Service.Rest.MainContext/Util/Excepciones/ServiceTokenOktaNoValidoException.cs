using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Service.Rest.MainContext.Util.Excepciones
{
    public class ServiceTokenOktaNoValidoException : ServiceException
    {
        public ServiceTokenOktaNoValidoException() : base("El token de Okta no pudo ser validado", null) { }
    }
}

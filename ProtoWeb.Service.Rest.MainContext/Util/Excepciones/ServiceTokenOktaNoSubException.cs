using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Service.Rest.MainContext.Util.Excepciones
{
    public class ServiceTokenOktaNoSubException : ServiceException
    {
        public ServiceTokenOktaNoSubException() : base("No se encontró el claim SUB en el token de okta", null) { }
    }
}

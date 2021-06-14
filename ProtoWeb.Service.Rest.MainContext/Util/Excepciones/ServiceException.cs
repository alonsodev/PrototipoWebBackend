using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Service.Rest.MainContext.Util.Excepciones
{
    public class ServiceException : Exception
    {
        public ServiceException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}

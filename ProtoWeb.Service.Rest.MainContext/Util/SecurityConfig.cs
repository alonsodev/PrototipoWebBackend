using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Service.Rest.MainContext.Util
{
    public class SecurityConfig
    {
        public string Issuer { get; set; }

        public SecurityConfig(
            string domain) 
        {
            Issuer = $"{domain}/oauth2/default";
        }
    }
}

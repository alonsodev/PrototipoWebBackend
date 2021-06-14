using ProtoWeb.Application.MainContext.Commands.Get;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace ProtoWeb.Service.Rest.MainContext.Util
{
    public class SecurityHelper
    {
        readonly ConfigurationManager<OpenIdConnectConfiguration> configurationManager;        
        readonly SecurityConfig oktaSecurityConfig;
        readonly IHttpContextAccessor httpContextAccessor;

        readonly IHttpContextAccessor accessor;

        public SecurityHelper(
            ConfigurationManager<OpenIdConnectConfiguration> configurationManager,
            IHttpContextAccessor httpContextAccessor,
            SecurityConfig oktaSecurityConfig,
           
            IHttpContextAccessor accessor)
        {
            this.configurationManager = configurationManager;
            this.httpContextAccessor = httpContextAccessor;
            this.oktaSecurityConfig = oktaSecurityConfig;
            this.accessor = accessor;
        }

        
    }
}

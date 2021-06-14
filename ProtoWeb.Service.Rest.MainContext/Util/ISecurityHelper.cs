
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProtoWeb.Service.Rest.MainContext.Util
{
    public interface ISecurityHelper
    {

        Task<JwtSecurityToken> ValidarToken(string token = null, CancellationToken ct = default);
    }
}

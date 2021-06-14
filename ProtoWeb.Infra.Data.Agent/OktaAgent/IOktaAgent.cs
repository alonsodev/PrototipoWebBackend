using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.Data.Agent.OktaAgent
{
    public interface IOktaAgent
    {
        List<OktaUser> ObtenerUsuarios(string filtro, int top);
        OktaUser ObtenerUsuarioPorLogin(string login);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.Data.Agent.OktaAgent
{
    public class OktaUser
    {
        public string id { get; set; }
        public string status { get; set; }
        public string created { get; set; }
        public OktauserType type { get; set; }
        public OktaUserProfile profile { get; set; }
    }

    public class OktauserType
    {
        public string id { get; set; }
    }

    public class OktaUserProfile
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string login { get; set; }
        public string email { get; set; }
    }
}

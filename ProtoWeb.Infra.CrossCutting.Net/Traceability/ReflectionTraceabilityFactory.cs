using System;
using ProtoWeb.Infra.CrossCutting.Traceability;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Net.Traceability
{
    public class ReflectionTraceabilityFactory: IEntityTraceabilityFactory
    {

        public IEntityTraceability Create()
        {
            return new ReflectionTraceability();
        }
    }
}

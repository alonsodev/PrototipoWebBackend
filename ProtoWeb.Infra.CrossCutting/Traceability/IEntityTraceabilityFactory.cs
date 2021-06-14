using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Traceability
{
    public interface IEntityTraceabilityFactory
    {
        IEntityTraceability Create();
    }
}

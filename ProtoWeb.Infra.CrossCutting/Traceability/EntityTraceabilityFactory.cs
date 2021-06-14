using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Traceability
{
    public static class EntityTraceabilityFactory
    {
        static IEntityTraceabilityFactory _currentEntityTraceabilityFactory = null;

        public static void SetCurrent(IEntityTraceabilityFactory traceabilityFactory)
        {
            _currentEntityTraceabilityFactory = traceabilityFactory;
        }

        public static IEntityTraceability CreateAdapter()
        {
            return _currentEntityTraceabilityFactory.Create();
        }
    }
}

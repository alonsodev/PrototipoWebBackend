using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Logging
{
    public static class LoggingFactory
    {
        static ILoggingFactory _currentLogFactory = null;

        public static void SetCurrent(ILoggingFactory logFactory)
        {
            _currentLogFactory = logFactory;
        }

        public static ILogging CreateLog()
        {
            return (_currentLogFactory != null) ? _currentLogFactory.Create() : null;
        }
    }
}

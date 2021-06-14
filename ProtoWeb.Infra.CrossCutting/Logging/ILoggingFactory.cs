using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Logging
{
    public interface ILoggingFactory
    {
        ILogging Create();
    }
}

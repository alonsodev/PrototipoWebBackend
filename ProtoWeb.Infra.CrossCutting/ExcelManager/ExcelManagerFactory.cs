using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.ExcelManager
{
    public static class ExcelManagerFactory
    {
        static IExcelManagerFactory _factory = null;

        public static void SetCurrent(IExcelManagerFactory factory)
        {
            _factory = factory;
        }

        public static IExcelManager CreateExcelManager()
        {
            return (_factory != null) ? _factory.Create() : null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.ExcelManager
{
    public interface IExcelManagerFactory
    {
        IExcelManager Create();
    }
}

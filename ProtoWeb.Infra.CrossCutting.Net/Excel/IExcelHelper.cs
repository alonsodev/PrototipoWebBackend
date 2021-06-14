using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Infra.CrossCutting.Net.Excel
{
    public interface IExcelHelper
    {
        public void OpenTemplate(string pathFormatName);
        public byte[] ToByte();
        ExcelWorksheet GetSheet(string sheetName);
        public void PopulateSheet(string sheetName, ExcelCell[,] cells);
        public void SheetZoom(string sheetName, int zoom);
    }
}

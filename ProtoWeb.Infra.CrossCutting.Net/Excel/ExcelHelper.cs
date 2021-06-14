using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Infra.CrossCutting.Net.Excel
{
    public class ExcelHelper: IExcelHelper
    {
        private string RutaApi { get; set; }
        private ExcelPackage Excel { get; set; }



        public ExcelHelper(string rutaApi)
        {
            RutaApi = rutaApi;
        }

        public void OpenTemplate(string pathFormatName)
        {
            Excel = new ExcelPackage(new FileInfo(@$"{RutaApi}\{pathFormatName}.xlsx"), false);
        }

        public void PopulateSheet(string sheetName, ExcelCell[,] cells)
        {
            var worksheet = Excel.Workbook.Worksheets[sheetName];
            worksheet.View.ZoomScale = 100;
            FillSheetInfo(worksheet, cells);
        }

        public ExcelWorksheet GetSheet(string sheetName)
        {
            return Excel.Workbook.Worksheets[sheetName];
        }


        private void FillSheetInfo(ExcelWorksheet worksheet, ExcelCell[,] cells)
        {
            var rows = cells.GetLength(0);
            var columns = cells.GetLength(1);
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    var epplusRow = i + 1;
                    var epplusColumns = j + 1;
                    var epplusCell = cells[i, j];
                    if (epplusCell != null)
                    {
                        FillCellInfo(worksheet.Cells, epplusCell, epplusRow, epplusColumns);
                        if (epplusCell.ColSpan != 1) j += epplusCell.ColSpan - 1;
                    }
                }
            }
        }

        private void FillCellInfo(ExcelRange excelRange, ExcelCell epplusCell, int fila, int columna)
        {
            var hasColSpan = epplusCell.ColSpan != 1 || epplusCell.RowSpan != 1;
            var excelCell = excelRange[fila, columna, fila + epplusCell.RowSpan - 1, columna + epplusCell.ColSpan - 1];
            if (hasColSpan) excelCell.Merge = true;
            excelCell.Value = epplusCell.Value;
            if (epplusCell.HasStyle)
            {
                excelCell.Style.Font.Size = epplusCell.Styling.FontSize;
                excelCell.Style.Font.Bold = epplusCell.Styling.Bold;
                excelCell.Style.Font.Name = "Arial";
                excelCell.Style.Font.Color.SetColor(ColorTranslator.FromHtml(epplusCell.Styling.HexFontColor));
                excelCell.Style.WrapText = epplusCell.Styling.WrapText;
                excelCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                excelCell.Style.Indent = epplusCell.Styling.Indent;
                if (epplusCell.Styling.HasBorder)
                {
                    if (epplusCell.Styling.BorderStyle != BorderStyle.Ignore)
                    {
                        excelCell.Style.Border.Top.Style = (ExcelBorderStyle)epplusCell.Styling.BorderStyle;
                        excelCell.Style.Border.Bottom.Style = (ExcelBorderStyle)epplusCell.Styling.BorderStyle;
                        excelCell.Style.Border.Left.Style = (ExcelBorderStyle)epplusCell.Styling.BorderStyle;
                        excelCell.Style.Border.Right.Style = (ExcelBorderStyle)epplusCell.Styling.BorderStyle;
                    }
                    else
                    {
                        excelCell.Style.Border.Top.Style = (ExcelBorderStyle)epplusCell.Styling.BorderTopStyle;
                        excelCell.Style.Border.Bottom.Style = (ExcelBorderStyle)epplusCell.Styling.BorderBottomStyle;
                        excelCell.Style.Border.Left.Style = (ExcelBorderStyle)epplusCell.Styling.BorderLeftStyle;
                        excelCell.Style.Border.Right.Style = (ExcelBorderStyle)epplusCell.Styling.BorderRightStyle;
                    }
                    if (excelCell.Style.Border.Top.Style != ExcelBorderStyle.None)
                        excelCell.Style.Border.Top.Color.SetColor(ColorTranslator.FromHtml(epplusCell.Styling.HexBorderColor));
                    if (excelCell.Style.Border.Bottom.Style != ExcelBorderStyle.None)
                        excelCell.Style.Border.Bottom.Color.SetColor(ColorTranslator.FromHtml(epplusCell.Styling.HexBorderColor));
                    if (excelCell.Style.Border.Left.Style != ExcelBorderStyle.None)
                        excelCell.Style.Border.Left.Color.SetColor(ColorTranslator.FromHtml(epplusCell.Styling.HexBorderColor));
                    if (excelCell.Style.Border.Right.Style != ExcelBorderStyle.None)
                        excelCell.Style.Border.Right.Color.SetColor(ColorTranslator.FromHtml(epplusCell.Styling.HexBorderColor));
                }
                if (epplusCell.Styling.HasBackground)
                {
                    excelCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    excelCell.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(epplusCell.Styling.HexBackgroundColor));
                }
                switch (epplusCell.Styling.Alignment)
                {
                    case CellAlignment.Center:
                        excelCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        break;
                    case CellAlignment.Left:
                        excelCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        break;
                    case CellAlignment.Right:
                        excelCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        break;
                    case CellAlignment.Justifiy:
                        excelCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Justify;
                        break;
                }
            }
            if (epplusCell.ValidationList != null && epplusCell.ValidationList.Any())
            {
                var dataValidationList = excelCell.DataValidation.AddListDataValidation();

                dataValidationList.ShowErrorMessage = epplusCell.OnlyAcceptFromValidationList;

                if (!string.IsNullOrEmpty(epplusCell.RangeValidationData))
                {
                    dataValidationList.Formula.ExcelFormula = epplusCell.RangeValidationData;
                }
                else
                {
                    epplusCell.ValidationList.ForEach(x => dataValidationList.Formula.Values.Add(x));
                }
            }
            if (!string.IsNullOrEmpty(epplusCell.Comments))
            {
                var comments = excelCell.AddComment(epplusCell.Comments, "ENGIE");
                comments.AutoFit = true;
            }

        }

        public byte[] ToByte()
        {
            return Excel.GetAsByteArray();
        }

        public void SheetZoom(string sheetName, int zoom)
        {
            var worksheet = Excel.Workbook.Worksheets[sheetName];
            worksheet.View.ZoomScale = zoom;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Net.Excel
{
    public class ExcelCell
    {
        public CellStyling Styling { get; set; }
        public string Format { get; set; }
        public object Value { get; set; }
        public int ColSpan { get; set; }
        public int RowSpan { get; set; }
        public List<string> ValidationList { get; set; }
        public bool OnlyAcceptFromValidationList { get; set; }
        public string Comments { get; set; }
        public string RangeValidationData { get; set; }
        public bool HasStyle { get; set; }
        public ExcelCell()
        {
            Styling = new CellStyling();
            HasStyle = true;
            ColSpan = 1;
            RowSpan = 1;
            Value = string.Empty;
            OnlyAcceptFromValidationList = false;
        }

        public ExcelCell Clone()
        {
            var styling = this.Styling.Clone();
            var entity = (ExcelCell)this.MemberwiseClone();
            entity.Styling = styling;
            return entity;
        }
    }

    public enum CellAlignment
    {
        Justifiy,
        Center,
        Left,
        Right
    }

    public enum BorderStyle
    {
        Ignore = -1,
        None = 0,
        Hair = 1,
        Dotted = 2,
        DashDot = 3,
        Thin = 4,
        DashDotDot = 5,
        Dashed = 6,
        MediumDashDotDot = 7,
        MediumDashed = 8,
        MediumDashDot = 9,
        Thick = 10,
        Medium = 11,
        Double = 12
    }

    public class CellStyling
    {
        public CellAlignment Alignment { get; set; }
        public bool Bold { get; set; }
        public int FontSize { get; set; }
        public bool WrapText { get; set; }
        public string HexFontColor { get; set; }
        public string HexBackgroundColor { get; set; }
        public string HexBorderColor { get; set; }
        public BorderStyle BorderStyle { get; set; }
        public BorderStyle BorderTopStyle { get; set; }
        public BorderStyle BorderBottomStyle { get; set; }
        public BorderStyle BorderLeftStyle { get; set; }
        public BorderStyle BorderRightStyle { get; set; }
        public int Indent { get; set; }

        public bool HasBackground { get { return !string.IsNullOrEmpty(HexBackgroundColor); } }
        public bool HasBorder { get { return !string.IsNullOrEmpty(HexBorderColor); } }

        public CellStyling()
        {
            Alignment = CellAlignment.Left;
            Bold = false;
            FontSize = 10;
            WrapText = true;
            HexFontColor = "#000000";
            BorderStyle = BorderStyle.Thin;
            BorderTopStyle = BorderStyle.Thin;
            BorderBottomStyle = BorderStyle.Thin;
            BorderLeftStyle = BorderStyle.Thin;
            BorderRightStyle = BorderStyle.Thin;
            Indent = 0;
        }

        public CellStyling Clone()
        {
            return (CellStyling)this.MemberwiseClone();
        }
    }
}

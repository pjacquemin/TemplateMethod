using System.Collections.Generic;
using IronPdf;


namespace Classes
{
    public class PDFGenerator : Generator
    {
        protected ChromePdfRenderer renderer { get; set; }
        protected PdfDocument pdf { get; set; }
        protected string html { get; set; }

        public PDFGenerator(IEnumerable<Data> datas) : base(datas) { }

        protected override void DoInitFile()
        {
            renderer = new ChromePdfRenderer();
        }

        protected override void DoAddData()
        {
            double firstQuarterResult = currentProcessedData.FirstQuarterVolume * currentProcessedData.UnitPrice;
            double secondQuarterResult = currentProcessedData.FirstQuarterVolume * currentProcessedData.UnitPrice;
            double thirdQuarterResult = currentProcessedData.FirstQuarterVolume * currentProcessedData.UnitPrice;
            double totalYearResult = firstQuarterResult + secondQuarterResult + thirdQuarterResult;

            html = $"<h1>{currentProcessedData.CustomerName}</h1>";

            html += "<div>";
            html += $"First quarter results : {firstQuarterResult} ";
            html += $"Second quarter results : {secondQuarterResult} ";
            html += $"Third quarter results : {thirdQuarterResult} ";
            html += $"Total year results : {totalYearResult}";
            html += "</div>";
        }

        protected override void DoSaveFile()
        {
            pdf = renderer.RenderHtmlAsPdf(html);
            pdf.SaveAs($"output_{currentProcessedData.CustomerName}.pdf");
        }
    }
}


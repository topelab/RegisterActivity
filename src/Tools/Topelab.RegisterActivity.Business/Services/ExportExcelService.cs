using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;

namespace Topelab.RegisterActivity.Business.Services
{
    public class ExportExcelService : IExportExcelService
    {
        public void WriteToExcel<T>(IEnumerable<T> datos, string outputFile) where T : class
        {
            var hoja = typeof(T).Name;

            using var pack = new ExcelPackage(new System.IO.FileInfo(outputFile));
            var old = pack.Workbook.Worksheets.FirstOrDefault(w => w.Name == hoja);
            if (old != null)
            {
                old.Name = $"{hoja}-back";
            }

            var ws = pack.Workbook.Worksheets.Add(hoja);
            pack.Workbook.Worksheets.MoveToStart(hoja);
            if (old != null)
            {
                pack.Workbook.Worksheets.Delete(old);
            }
            ws.Cells["A1"].LoadFromCollection(datos, true);

            var filas = 2 + datos.Count();
            ws.Cells[$"D2:E{filas}"].Style.Numberformat.Format = "dd/mm/yyyy hh:mm";
            ws.Cells[$"G2:G{filas}"].Style.Numberformat.Format = "dd/mm/yyyy";
            var style = ws.Cells["A1:H1"].Style;
            style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            style.Font.Bold = true;

            ws.Column(2).Width = 30;
            ws.Column(3).Width = 30;
            ws.Column(4).AutoFit();
            ws.Column(5).AutoFit();
            ws.Column(7).AutoFit();
            ws.Column(8).Width = 90;

            pack.Save();
        }

    }
}

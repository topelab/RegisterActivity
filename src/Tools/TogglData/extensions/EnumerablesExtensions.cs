using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Linq;
using TogglData.context;
using TogglData.dto;

namespace System.Collections.Generic
{
    public static class EnumerablesExtensions
    {
        public static void WriteToExcel(this IEnumerable<TimelineEventsDTO> datos, string outputFile)
        {
            string hoja = "timeline_events";

            using ExcelPackage pack = new ExcelPackage(new System.IO.FileInfo(outputFile));
            var old = pack.Workbook.Worksheets.Where(w => w.Name == hoja).FirstOrDefault();
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

        public static List<TimelineEventsDTO> ReadDB(this string file)
        {
            var connString = $"Data Source={file}";
            var options = new DbContextOptionsBuilder<TogglContext>()
                .UseSqlite(connString)
                .Options;

            using var db = new TogglContext(options);
            var datos = db.TimelineEvents
                .Select(r => new TimelineEventsDTO
                {
                    LocalId = r.LocalId,
                    Title = r.Title,
                    StartTime = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(r.StartTime).ToLocalTime(),
                    EndTime = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds((long)r.EndTime).ToLocalTime(),
                    Filename = r.Filename,
                }).ToList();

            return datos;

        }


    }
}

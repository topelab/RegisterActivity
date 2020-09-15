using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using TogglData.context;
using TogglData.dto;

namespace TogglExport
{
    class Program
    {
        static void Main(string[] args)
        {
            var connString = args.Length > 0 ? args[0] : "toggl";
            var options = new DbContextOptionsBuilder<TogglContext>()
                .UseSqlite(ConfigHelper.GetConnectionString(connString))
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


            string hoja = "timeline_events";
            string filename = Path.GetFileNameWithoutExtension(ConfigHelper.GetConnectionString(connString).GetPart("Data Source"));
            var outputFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\{filename}.xlsx";

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
            // rango C2:D9999 - fila 2, columna 3 (C) hasta fila 2 + datos.Count, columna 4 (D)
            using (ExcelRange col = ws.Cells[2, 4, 2 + datos.Count, 5])
            {
                col.Style.Numberformat.Format = "dd/mm/yyyy hh:mm";
            }
            using (ExcelRange col = ws.Cells[2, 7, 2 + datos.Count, 7])
            {
                col.Style.Numberformat.Format = "dd/mm/yyyy";
            }
            using (ExcelRange col = ws.Cells[1, 1, 1, 8])
            {
                col.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                col.Style.Font.Bold = true;
            }
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

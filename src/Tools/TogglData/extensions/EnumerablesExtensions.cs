using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.IO;
using System.Linq;
using System.Text;
using TogglData.dto;
using Tools.TogglData.Adapters.Context;
using Tools.TogglData.Domain.Entities;

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

        public static void WriteToCSV(this IEnumerable<TimelineEventsDTO> datos, string outputFile)
        {
            var content = datos.ToCsv();
            File.WriteAllText(outputFile, content);
        }

        public static List<TimelineEventsDTO> ReadDB(this string file, Func<Winlog, bool> criteria = null, Action<TogglDataDbContext, IEnumerable<Winlog>> action = null)
        {
            var connString = $"Data Source={file}";
            var options = new DbContextOptionsBuilder<TogglDataDbContext>()
                .UseSqlite(connString)
                .Options;

            using var db = new TogglDataDbContext(options);
            IEnumerable<Winlog> datosDB = db.Winlog;

            if (criteria != null)
                datosDB = datosDB.Where(criteria);

            var datos = datosDB
                .Select(r => new TimelineEventsDTO
                {
                    LocalId = r.LocalId,
                    Title = r.Title,
                    StartTime = DateTime.Parse(r.StartTime),
                    EndTime = DateTime.Parse(r.EndTime),
                    Filename = r.Filename,
                    TotalTime = (double)r.TotalTime / 60.0,
                }).ToList();

            action?.Invoke(db, datosDB);
            db.SaveChanges();
            return datos;
        }

        private static readonly string Separator = ",";

        public static string ToCsv<T>(this IEnumerable<T> items)
            where T : class
        {
            var csvBuilder = new StringBuilder();
            var properties = typeof(T).GetProperties();

            csvBuilder.AppendLine(string.Join(Separator, properties.Select(p => p.Name)));

            foreach (T item in items)
            {
                string line = string.Join(Separator, properties.Select(p => p.GetValue(item, null).ToCsvValue()).ToArray());
                csvBuilder.AppendLine(line);
            }
            return csvBuilder.ToString();
        }

        private static string ToCsvValue<T>(this T item)
        {
            if (item == null) return "\"\"";

            string value = item.ToString();

            if (item is string)
            {
                return string.Format("\"{0}\"", item.ToString().Replace("\"", "\"\"").Replace("\r\n", " ").Replace('\n', ' '));
            }
            if (item is double || item is float || item is decimal)
            {
                return value.Contains(",") ? $"\"{value}\"" : value;
            }
            if (item is DateTime)
            {
                return (item as DateTime?).Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(" 00:00:00", "");
            }
            return string.Format("{0}", item);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Topelab.RegisterActivity.Business.Services
{
    public class ExportCsvService : IExportCsvService
    {
        public void WriteToFile<T>(IEnumerable<T> datos, string outputFile) where T : class
        {
            var content = ToCsv(datos);
            File.WriteAllText(outputFile, content);
        }

        private const string Separator = ",";

        private string ToCsv<T>(IEnumerable<T> items)
            where T : class
        {
            var csvBuilder = new StringBuilder();
            var properties = typeof(T).GetProperties();

            csvBuilder.AppendLine(string.Join(Separator, properties.Select(p => p.Name)));

            foreach (var item in items)
            {
                var line = string.Join(Separator, properties.Select(p => ToCsvValue(p.GetValue(item, null))).ToArray());
                csvBuilder.AppendLine(line);
            }
            return csvBuilder.ToString();
        }

        private string ToCsvValue<T>(T item)
        {
            if (item == null) return "\"\"";

            var value = item.ToString();

            if (item is string)
            {
                return string.Format("\"{0}\"", item.ToString().Replace("\"", "\"\"").Replace("\r\n", " ").Replace('\n', ' '));
            }
            if (item is double || item is float || item is decimal)
            {
                return value.Contains(',') ? $"\"{value}\"" : value;
            }
            if (item is DateTime)
            {
                return (item as DateTime?).Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(" 00:00:00", "");
            }
            return string.Format("{0}", item);
        }
    }
}

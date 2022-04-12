using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace TogglExport
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var format = args.Length > 0 && args[0].Equals("-e", StringComparison.CurrentCultureIgnoreCase) ? "xlsx" : "csv";
            var connString = args.Length > 1 ? args[1] : "toggl";
            var dbFileName = ConfigHelper.GetConnectionString(connString).GetPart("Data Source");
            string filename = Path.GetFileNameWithoutExtension(dbFileName);
            var outputFile = (ConfigHelper.Config["OutputDirectory"] ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + $"\\{ filename}.{format}";

            var list = dbFileName
                .ReadDB();

            if (format.Equals("csv"))
            {
                list.WriteToCSV(outputFile);
            }
            else
            {
                list.WriteToExcel(outputFile);
            }
        }
    }
}

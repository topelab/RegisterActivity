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
            var connString = args.Length > 0 ? args[0] : "toggl";
            var dbFileName = ConfigHelper.GetConnectionString(connString).GetPart("Data Source");
            string filename = Path.GetFileNameWithoutExtension(dbFileName);
            var outputFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\{filename}.xlsx";

            dbFileName
                .ReadDB()
                .WriteToExcel(outputFile);

        }
    }
}

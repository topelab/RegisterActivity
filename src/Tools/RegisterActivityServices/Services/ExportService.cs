using Microsoft.EntityFrameworkCore;
using RegisterActivityServices.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace RegisterActivityServices.Services
{
    public class ExportService : IExportService
    {
        public void Start(ExportFormat format)
        {
            var dbFileName = ConfigHelper.GetConnectionString(Constants.ConnStringKey).GetPart("Data Source");
            var filename = Path.GetFileNameWithoutExtension(dbFileName);
            var filePath = (ConfigHelper.Config[Constants.OutputDirectory] ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            var list = dbFileName.ReadDB();
            var outputFile = Path.Combine(filePath, filename);

            switch (format)
            {
                case ExportFormat.CSV:
                    outputFile += ".csv";
                    list.WriteToCSV(outputFile);
                    break;
                case ExportFormat.Excel:
                    outputFile += ".xlsx";
                    list.WriteToExcel(outputFile);
                    break;
            }

            Process process = new();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = $"/c start {outputFile}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }
    }
}

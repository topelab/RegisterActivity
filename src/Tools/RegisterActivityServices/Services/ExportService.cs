using Microsoft.EntityFrameworkCore;
using RegisterActivityServices.DTO;
using System;
using System.Collections.Generic;
using System.IO;

namespace RegisterActivityServices.Services
{
    public class ExportService : IExportService
    {
        public void Start(ExportFormat format)
        {
            var dbFileName = ConfigHelper.GetConnectionString(Constants.ConnStringKey).GetPart("Data Source");
            string filename = Path.GetFileNameWithoutExtension(dbFileName);
            string outputFile = (ConfigHelper.Config[Constants.OutputDirectory] ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + $"\\{ filename}.{format}";

            var list = dbFileName.ReadDB();

            switch (format)
            {
                case ExportFormat.CSV:
                    list.WriteToCSV(outputFile);
                    break;
                case ExportFormat.Excel:
                    list.WriteToExcel(outputFile);
                    break;
            }
        }
    }
}

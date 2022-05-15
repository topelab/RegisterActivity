using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.IO;
using Topelab.RegisterActivity.Business.DTO;
using Topelab.RegisterActivity.Business.Services.Entities;

namespace Topelab.RegisterActivity.Business.Services
{
    public class ExportService : IExportService
    {
        private readonly IWinlogService winlogService;
        private readonly IExportCsvService csvService;
        private readonly IExportExcelService excelService;

        public ExportService(IWinlogService winlogReaderService, IExportCsvService csvService, IExportExcelService excelService)
        {
            winlogService = winlogReaderService ?? throw new ArgumentNullException(nameof(winlogReaderService));
            this.csvService = csvService ?? throw new ArgumentNullException(nameof(csvService));
            this.excelService = excelService ?? throw new ArgumentNullException(nameof(excelService));
        }

        public void Start(ExportFormat format)
        {
            var dbFileName = ConfigHelper.GetConnectionString(Constants.ConnStringKey).GetPart("Data Source");
            var filename = $"{Path.GetFileNameWithoutExtension(dbFileName)}";
            var outputFileName = ConfigHelper.Config[Constants.OutputFileName] ?? filename;
            var filePath = ConfigHelper.Config[Constants.OutputDirectory] ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var list = winlogService.GetTimeLineEvents();
            var outputFile = Path.Combine(filePath, outputFileName);

            switch (format)
            {
                case ExportFormat.CSV:
                    outputFile += ".csv";
                    csvService.WriteToCSV(list, outputFile);
                    break;
                case ExportFormat.Excel:
                    outputFile += ".xlsx";
                    excelService.WriteToExcel(list, outputFile);
                    break;
            }

            Process process = new();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = $"/c start {filePath}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }
    }
}

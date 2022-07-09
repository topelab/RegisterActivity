using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.IO;
using Topelab.RegisterActivity.Business.Enums;
using Topelab.RegisterActivity.Business.Services.Entities;
using Topelab.RegisterActivity.Business.Services.Interfaces;

namespace Topelab.RegisterActivity.Business.Services
{
    public class ExportService : IExportService
    {
        private readonly IWinlogService winlogService;
        private readonly IExportFileServiceResolver exportFileServiceResolver;

        public ExportService(IWinlogService winlogReaderService, IExportFileServiceResolver exportFileServiceResolver)
        {
            winlogService = winlogReaderService ?? throw new ArgumentNullException(nameof(winlogReaderService));
            this.exportFileServiceResolver = exportFileServiceResolver ?? throw new ArgumentNullException(nameof(exportFileServiceResolver));
        }

        public void Start(ExportFormat format)
        {
            var fileService = exportFileServiceResolver.GetExportFileService(format);
            var fileExtension = exportFileServiceResolver.GetExportFileExtension(format);

            var dbFileName = ConfigHelper.GetConnectionString(Constants.ConnStringKey).GetPart("Data Source");
            var filename = $"{Path.GetFileNameWithoutExtension(dbFileName)}";
            var outputFileName = ConfigHelper.Config[Constants.OutputFileName] ?? filename;
            var filePath = ConfigHelper.Config[Constants.OutputDirectory] ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var list = winlogService.GetTimeLineEvents();
            var outputFile = string.Concat(Path.Combine(filePath, outputFileName), ".", fileExtension);

            fileService.WriteToFile(list, outputFile);

            Process process = new();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = $"/c start {filePath}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }
    }
}

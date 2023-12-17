using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Topelab.RegisterActivity.BaseBusiness.Enums;
using Topelab.RegisterActivity.BaseBusiness.Services;
using Topelab.RegisterActivity.Business.Enums;
using Topelab.RegisterActivity.Business.Services.Entities;

namespace Topelab.RegisterActivity.Business.Services
{
    public class ExportDataService : IExportDataService
    {
        private readonly IWinlogService winlogService;
        private readonly IExportService exportService;

        public ExportDataService(IWinlogService winlogReaderService, IExportService exportService)
        {
            winlogService = winlogReaderService ?? throw new ArgumentNullException(nameof(winlogReaderService));
            this.exportService = exportService ?? throw new ArgumentNullException(nameof(exportService));
        }

        public void Start(ExportFormat format)
        {
            var dbFileName = ConfigHelper.GetConnectionString(Constants.ConnStringKey).GetPart("Data Source");
            var filename = $"{Path.GetFileNameWithoutExtension(dbFileName)}";
            var outputFileName = Environment.ExpandEnvironmentVariables(ConfigHelper.Config[Constants.OutputFileName] ?? filename);
            var filePath = Environment.ExpandEnvironmentVariables(ConfigHelper.Config[Constants.OutputDirectory] ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            exportService.Export(() => winlogService.GetTimeLineEvents(), format, outputFileName, filePath);
        }
    }
}

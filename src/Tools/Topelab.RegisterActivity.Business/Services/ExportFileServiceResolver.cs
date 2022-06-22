using System;
using System.Collections.Generic;
using Topelab.RegisterActivity.Business.Enums;
using Topelab.RegisterActivity.Business.Services.Interfaces;

namespace Topelab.RegisterActivity.Business.Services
{
    /// <summary>
    /// Resolve export file service
    /// </summary>
    public class ExportFileServiceResolver : IExportFileServiceResolver
    {
        private readonly Dictionary<ExportFormat, IExportFileService> exportServices = new Dictionary<ExportFormat, IExportFileService>();
        private readonly Dictionary<ExportFormat, string> exportExtensions = new Dictionary<ExportFormat, string>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="csvService">CSV File export service</param>
        /// <param name="excelService">Excel File export service</param>
        public ExportFileServiceResolver(IExportCsvService csvService, IExportExcelService excelService)
        {
            exportServices.Add(ExportFormat.CSV, csvService ?? throw new ArgumentNullException(nameof(csvService)));
            exportExtensions.Add(ExportFormat.CSV, "csv");

            exportServices.Add(ExportFormat.Excel, excelService ?? throw new ArgumentNullException(nameof(excelService)));
            exportExtensions.Add(ExportFormat.Excel, "xlsx");
        }

        /// <summary>
        /// Get export file service
        /// </summary>
        /// <param name="exportFormat">Format to export</param>
        /// <returns>Export file service</returns>
        public string GetExportFileExtension(ExportFormat exportFormat) => exportExtensions[exportFormat];

        /// <summary>
        /// Get export file extension
        /// </summary>
        /// <param name="exportFormat">Format to export</param>
        /// <returns>Export file extension</returns>
        public IExportFileService GetExportFileService(ExportFormat exportFormat) => exportServices[exportFormat];
    }
}

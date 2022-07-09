using System;
using System.Collections.Generic;
using Topelab.Core.Helpers.Extensions;
using Topelab.Core.Resolver.Interfaces;
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
        /// <param name="resolver">Resolver for DI</param>
        public ExportFileServiceResolver(IResolver resolver)
        {
            foreach (var value in Enum.GetValues<ExportFormat>())
            {
                exportServices.Add(value, resolver.Get<IExportFileService>(value.ToString()));
                exportExtensions.Add(value, value.GetDescription());
            }
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

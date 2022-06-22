using Topelab.RegisterActivity.Business.Enums;

namespace Topelab.RegisterActivity.Business.Services.Interfaces
{
    /// <summary>
    /// Define implementation to resolve export file service
    /// </summary>
    public interface IExportFileServiceResolver
    {
        /// <summary>
        /// Get export file service
        /// </summary>
        /// <param name="exportFormat">Format to export</param>
        /// <returns>Export file service</returns>
        IExportFileService GetExportFileService(ExportFormat exportFormat);

        /// <summary>
        /// Get export file extension
        /// </summary>
        /// <param name="exportFormat">Format to export</param>
        /// <returns>Export file extension</returns>
        string GetExportFileExtension(ExportFormat exportFormat);
    }
}

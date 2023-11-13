using Topelab.RegisterActivity.Business.Enums;

namespace Topelab.RegisterActivity.Business.Services
{
    public interface IExportDataService
    {
        void Start(ExportFormat format);
    }
}

using Topelab.RegisterActivity.Business.Enums;

namespace Topelab.RegisterActivity.Business.Services
{
    public interface IExportService
    {
        void Start(ExportFormat format);
    }
}

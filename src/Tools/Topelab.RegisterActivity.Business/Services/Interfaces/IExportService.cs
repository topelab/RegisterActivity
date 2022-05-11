using Topelab.RegisterActivity.Business.DTO;

namespace Topelab.RegisterActivity.Business.Services
{
    public interface IExportService
    {
        void Start(ExportFormat format);
    }
}

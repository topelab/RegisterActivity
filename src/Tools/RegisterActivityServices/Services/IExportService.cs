using RegisterActivityServices.DTO;

namespace RegisterActivityServices.Services
{
    public interface IExportService
    {
        void Start(ExportFormat format);
    }
}

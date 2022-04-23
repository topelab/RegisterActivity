using System.Collections.Generic;

namespace RegisterActivityServices.Services
{
    public interface IExportExcelService
    {
        void WriteToExcel<T>(IEnumerable<T> datos, string outputFile) where T : class;
    }
}
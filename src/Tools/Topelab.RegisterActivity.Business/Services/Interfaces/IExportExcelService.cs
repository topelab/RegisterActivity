using System.Collections.Generic;

namespace Topelab.RegisterActivity.Business.Services
{
    public interface IExportExcelService
    {
        void WriteToExcel<T>(IEnumerable<T> datos, string outputFile) where T : class;
    }
}
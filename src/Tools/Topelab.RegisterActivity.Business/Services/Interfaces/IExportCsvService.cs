using System.Collections.Generic;

namespace Topelab.RegisterActivity.Business.Services
{
    public interface IExportCsvService
    {
        string ToCsv<T>(IEnumerable<T> items) where T : class;
        void WriteToCSV<T>(IEnumerable<T> datos, string outputFile) where T : class;
    }
}
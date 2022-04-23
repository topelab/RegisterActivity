using System.Collections.Generic;

namespace RegisterActivityServices.Services
{
    public interface IExportCsvService
    {
        string ToCsv<T>(IEnumerable<T> items) where T : class;
        void WriteToCSV<T>(IEnumerable<T> datos, string outputFile) where T : class;
    }
}
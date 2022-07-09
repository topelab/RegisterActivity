using System.Collections.Generic;

namespace Topelab.RegisterActivity.Business.Services
{
    public interface IExportFileService
    {
        void WriteToFile<T>(IEnumerable<T> datos, string outputFile) where T : class;
    }
}
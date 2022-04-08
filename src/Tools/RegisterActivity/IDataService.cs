using System.Collections.Generic;

namespace RegisterActivity
{
    internal interface IDataService
    {
        void CalculateData(IEnumerable<ProcessDTO> processes);
    }
}
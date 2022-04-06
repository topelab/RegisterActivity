using System.Collections.Generic;

namespace RegisterActivity
{
    internal interface IDataService
    {
        void SaveData(IEnumerable<ProcessDTO> processes);
    }
}
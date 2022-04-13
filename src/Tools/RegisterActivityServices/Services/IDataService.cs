using RegisterActivity.DTO;
using System;

namespace RegisterActivity.Services
{
    public interface IDataService
    {
        void CalculateData(ProcessDTO currentProcess, Action<ProcessDTO> afterSave = null);
    }
}
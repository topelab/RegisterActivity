using RegisterActivityServices.DTO;
using System;

namespace RegisterActivityServices.Services
{
    public interface IDataService
    {
        void CalculateData(ProcessDTO currentProcess, Action<ProcessDTO> afterSave = null);
    }
}
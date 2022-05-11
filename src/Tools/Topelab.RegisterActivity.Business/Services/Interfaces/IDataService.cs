using System;
using Topelab.RegisterActivity.Business.DTO;

namespace Topelab.RegisterActivity.Business.Services
{
    public interface IDataService
    {
        void CalculateData(ProcessDTO currentProcess, Action<ProcessDTO> afterSave = null);
    }
}
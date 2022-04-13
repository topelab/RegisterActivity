using RegisterActivity.DTO;
using System;

namespace RegisterActivity.Services
{
    public interface IProcessService
    {
        void Start(Action<ProcessDTO> onNewProcesses);
        void Stop();
    }
}
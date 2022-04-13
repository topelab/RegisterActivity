using RegisterActivityServices.DTO;
using System;

namespace RegisterActivityServices.Services
{
    public interface IProcessService
    {
        void Start(Action<ProcessDTO> onNewProcesses);
        void Stop();
    }
}
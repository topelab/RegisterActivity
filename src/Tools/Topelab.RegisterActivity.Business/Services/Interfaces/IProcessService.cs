using System;
using Topelab.RegisterActivity.Business.DTO;

namespace Topelab.RegisterActivity.Business.Services
{
    public interface IProcessService
    {
        void Start(Action<ProcessDTO> onNewProcesses);
        void Stop();
    }
}
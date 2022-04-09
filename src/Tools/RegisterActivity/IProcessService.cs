using System;

namespace RegisterActivity
{
    internal interface IProcessService
    {
        void Start(Action<ProcessDTO> onNewProcesses);
        void Stop();
    }
}
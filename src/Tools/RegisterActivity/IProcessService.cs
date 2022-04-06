using System;
using System.Collections.Generic;

namespace RegisterActivity
{
    internal interface IProcessService
    {
        void Start(Action<IEnumerable<ProcessDTO>> onNewProcesses, double interval = 5000);
        void Stop();
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace RegisterActivity
{
    internal class ProcessService : IProcessService
    {
        private bool timerRunning;
        private readonly Timer timer;
        private Action<ProcessDTO> onNewProcesses;

        public ProcessService()
        {
            timer = new Timer();
            timer.Elapsed += OnTimerElapsed;
        }

        public void Start(Action<ProcessDTO> onNewProcesses)
        {
            timer.Interval = 5000;
            this.onNewProcesses = onNewProcesses;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (!timerRunning)
            {
                timerRunning = true;

                try
                {
                    var activeWindow = WindowTools.GetActiveWindowProcessId();
                    ProcessDTO currentProcess = new ProcessDTO(Process.GetProcessById(activeWindow.processId));
                    onNewProcesses?.Invoke(currentProcess);
                }
                finally
                {
                    timerRunning = false;
                }
            }
        }

        private bool CanGetProcess(Process process)
        {
            bool result;

            try
            {
                var ptr = process.Handle;
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}

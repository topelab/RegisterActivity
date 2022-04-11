using System;
using System.Diagnostics;
using System.Timers;

namespace RegisterActivity
{
    internal class ProcessService : IProcessService
    {
        private double interval = 5000;
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
            timer.Interval = interval;
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
                    string activeWindow = WindowTools.GetActiveWindowTitle();
                    int processId = WindowTools.GetActiveWindowProcessId();
                    Process process = Process.GetProcessById(processId);
                    if (process != null)
                    {
                        ProcessDTO currentProcess = new ProcessDTO(process, activeWindow);
                        DateTime previousInstance = DateTime.Now.AddMilliseconds(-interval);
                        currentProcess.LastTimeActive = process.StartTime > previousInstance ? process.StartTime : previousInstance;
                        onNewProcesses?.Invoke(currentProcess);
                    }
                }
                finally
                {
                    timerRunning = false;
                }
            }
        }
    }
}

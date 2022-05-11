using System;
using System.Diagnostics;
using System.Timers;
using Topelab.RegisterActivity.Business.DTO;
using Topelab.RegisterActivity.Business.Tools;

namespace Topelab.RegisterActivity.Business.Services
{
    public class ProcessService : IProcessService
    {
        private double interval = 1000;
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
                string activeWindow = null;

                try
                {
                    activeWindow = WindowTools.GetActiveWindowTitle();
                    var processId = WindowTools.GetActiveWindowProcessId();
                    if (activeWindow != null && processId > 0)
                    {
                        var process = Process.GetProcessById(processId);
                        ProcessDTO currentProcess = new(process, activeWindow);
                        var discount = process.StartTime > DateTime.Now.AddMilliseconds(-interval) ? (DateTime.Now - process.StartTime).TotalMilliseconds : interval;
                        currentProcess.LastTimeActive = DateTime.Now.AddMilliseconds(-discount);
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

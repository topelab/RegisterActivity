using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace RegisterActivity
{
    internal class ProcessService
    {
        private bool timerRunning;
        private readonly Timer timer;
        private Action<IEnumerable<ProcessDTO>> onNewProcesses;

        public ProcessService()
        {
            timer = new Timer();
            timer.Elapsed += OnTimerElapsed;
        }

        public void Start(Action<IEnumerable<ProcessDTO>> onNewProcesses, double interval = 5000)
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
                    IEnumerable<ProcessDTO> processes = Process.GetProcesses()
                        .Where(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle))
                        .Select(p => new ProcessDTO(p.MainWindowTitle, p.ProcessName, p.StartTime, p.MainModule.FileName));
                    onNewProcesses?.Invoke(processes);
                }
                finally
                {
                    timerRunning = false;
                }
            }
        }
    }
}

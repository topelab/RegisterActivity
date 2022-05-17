using System;
using System.Diagnostics;
using System.Timers;
using Topelab.RegisterActivity.Business.DTO;
using Topelab.RegisterActivity.Business.Factories;
using Topelab.RegisterActivity.Business.Tools;

namespace Topelab.RegisterActivity.Business.Services
{
    public class ProcessService : IProcessService
    {
        private bool timerRunning;
        private readonly Timer timer;
        private readonly IProcessDTOFactory processDTOFactory;
        private Action<ProcessDTO> onNewProcesses;

        public const double PickDataInterval = 1000;

        public ProcessService(IProcessDTOFactory processDTOFactory)
        {
            this.processDTOFactory = processDTOFactory ?? throw new ArgumentNullException(nameof(processDTOFactory));

            timer = new Timer();
            timer.Elapsed += OnTimerElapsed;
        }

        public void Start(Action<ProcessDTO> onNewProcesses)
        {
            timer.Interval = PickDataInterval;
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
                    var processId = WindowTools.GetActiveWindowProcessId();
                    if (activeWindow != null && processId > 0)
                    {
                        var process = Process.GetProcessById(processId);
                        ProcessDTO currentProcess = processDTOFactory.Create(process, activeWindow, timer.Interval);
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

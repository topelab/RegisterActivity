using Microsoft.Data.Sqlite;
using System;
using System.Diagnostics;
using System.Timers;
using Topelab.RegisterActivity.BaseBusiness.Services.Interfaces;
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
        private readonly ILogService logService;
        private Action<ProcessDTO> onNewProcesses;

        public const double PickDataInterval = 1000;

        public ProcessService(IProcessDTOFactory processDTOFactory, ILogService logService)
        {
            this.processDTOFactory = processDTOFactory ?? throw new ArgumentNullException(nameof(processDTOFactory));
            this.logService = logService ?? throw new ArgumentNullException(nameof(logService));
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
            SqliteConnection.ClearAllPools();
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
                        ProcessDTO currentProcess = processDTOFactory.Create(process, activeWindow, DateTime.Now, timer.Interval);
                        onNewProcesses?.Invoke(currentProcess);
                    }
                }
                catch (Exception ex)
                {
                    logService.Error(ex.Message);
                }
                finally
                {
                    timerRunning = false;
                }
            }
        }
    }
}

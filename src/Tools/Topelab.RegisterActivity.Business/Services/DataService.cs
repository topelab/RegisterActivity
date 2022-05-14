using System;
using System.Collections.Generic;
using Topelab.RegisterActivity.Business.DTO;
using Topelab.RegisterActivity.Business.Services.Entities;
using Topelab.RegisterActivity.Domain.Entities;

namespace Topelab.RegisterActivity.Business.Services
{
    public class DataService : IDataService
    {
        private readonly Dictionary<int, ProcessDTO> processData;
        private readonly IWinlogService winlogService;
        private ProcessDTO lastProcess = null;


        public DataService(IWinlogService winlogService)
        {
            processData = new Dictionary<int, ProcessDTO>();
            this.winlogService = winlogService ?? throw new ArgumentNullException(nameof(winlogService));
        }

        public void CalculateData(ProcessDTO currentProcess, Action<ProcessDTO> afterSave = null)
        {
            var hashCode = currentProcess.GetHashCode();
            if (processData.TryGetValue(hashCode, out var process))
            {
                currentProcess.Duration = process.Duration;
                currentProcess.StartTime = process.StartTime;
            }

            var lastMoment = currentProcess.LastTimeActive ?? DateTime.Now;
            currentProcess.LastTimeActive = DateTime.Now;
            currentProcess.Duration += DateTime.Now - lastMoment;

            if (lastProcess != null)
            {
                var lastHashCode = lastProcess.GetHashCode();
                if (lastHashCode != hashCode)
                {
                    lastProcess.LastTimeActive = null;
                    SaveData(lastProcess);
                    processData.Remove(lastHashCode);
                    afterSave?.Invoke(lastProcess);
                }
            }
            processData[hashCode] = currentProcess;
            lastProcess = currentProcess;
        }

        private void SaveData(ProcessDTO process)
        {
            process.LocalId = winlogService.Save(Map(process));
        }

        private static Winlog Map(ProcessDTO item)
        {
            return new Winlog
            {
                EndTime = DateTime.Now.AddMilliseconds(-item.Discount).ToString("s"),
                StartTime = item.StartTime.ToString("s"),
                Program = item.ProcessName,
                Title = item.MainWindowTitle,
                Filename = item.FileName,
                TotalTime = item.DurationInSeconds,
                HashCode = item.GetHashCode()
            };
        }
    }
}

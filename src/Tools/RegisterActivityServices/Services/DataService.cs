using Microsoft.EntityFrameworkCore;
using RegisterActivityServices.DTO;
using RegisterActivityServices.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using Topelab.RegisterActivity.Adapters.Context;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.Domain.Entities;
using Topelab.Core.Resolver.Interfaces;

namespace RegisterActivityServices.Services
{
    public class DataService : IDataService
    {
        private readonly DbContextOptions<RegisterActivityDbContext> options;
        private readonly IResolver resolver;
        private readonly Dictionary<int, ProcessDTO> processData;

        private ProcessDTO lastProcess = null;

        public DataService(IResolver resolver, IOptionsFactory optionsFactory)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            options = optionsFactory.Create(Constants.ConnStringKey);
            processData = new Dictionary<int, ProcessDTO>();
        }

        public void CalculateData(ProcessDTO currentProcess, Action<ProcessDTO> afterSave = null)
        {
            var hashCode = currentProcess.GetHashCode();
            if (processData.TryGetValue(hashCode, out var process))
            {
                currentProcess = process;
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
                    processData[lastHashCode] = lastProcess;
                    afterSave?.Invoke(lastProcess);
                }
            }
            processData[hashCode] = currentProcess;
            lastProcess = currentProcess;
        }

        private void SaveData(ProcessDTO process)
        {
            using var db = resolver.Get<IRegisterActivityDbContext, DbContextOptions<RegisterActivityDbContext>>(options);
            var winlog = db.Winlog.Where(r => r.HashCode == process.GetHashCode()).OrderByDescending(r => r.StartTime).FirstOrDefault();

            if (winlog != null)
            {
                winlog.TotalTime = process.DurationInSeconds;
                winlog.EndTime = DateTime.Now.ToString("s");
                db.Update(winlog);
            }
            else
            {
                winlog = Map(process);
                db.Add(winlog);
            }

            db.SaveChanges();
            process.LocalId = winlog.LocalId;
        }

        private static Winlog Map(ProcessDTO item)
        {
            return new Winlog
            {
                EndTime = DateTime.Now.ToString("s"),
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

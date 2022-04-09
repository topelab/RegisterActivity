using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Tools.TogglData.Adapters.Context;
using Tools.TogglData.Adapters.Interfaces;
using Tools.TogglData.Domain.Entities;
using Topelab.Core.Resolver.Interfaces;

namespace RegisterActivity
{
    internal class DataService : IDataService
    {
        private DbContextOptions<TogglDataDbContext> options;
        private readonly IResolver resolver;
        private readonly Dictionary<int, ProcessDTO> processData;

        public DataService(IResolver resolver, IOptionsFactory optionsFactory)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            options = optionsFactory.Create("toggl");
            processData = new Dictionary<int, ProcessDTO>();
        }

        public void CalculateData(ProcessDTO currentProcess)
        {
            if (currentProcess != null)
            {
                if (processData.TryGetValue(currentProcess.Id, out ProcessDTO process))
                {
                    currentProcess = process;
                }
                DateTime lastMoment = currentProcess.LastTimeActive ?? DateTime.Now;
                TimeSpan duration = currentProcess.Duration.Add(DateTime.Now - lastMoment);
                currentProcess.Duration = duration;
                currentProcess.LastTimeActive = DateTime.Now;

                SaveData(currentProcess);
                processData[currentProcess.Id] = currentProcess;
            }
        }

        private void SaveData(ProcessDTO process)
        {
            using ITogglDataDbContext db = resolver.Get<ITogglDataDbContext, DbContextOptions<TogglDataDbContext>>(options);
            Winlog winlog;

            if (process.LocalId > 0)
            {
                winlog = db.Find<Winlog>(process.LocalId);
                if (winlog != null)
                {
                    winlog.TotalTime = process.Duration.TotalSeconds.ToString();
                    winlog.Date = DateTime.UtcNow.ToString("u");
                }
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
                Date = DateTime.UtcNow.ToString("u"),
                StartTime = item.StartTime.ToString("u"),
                Program = item.ProcessName,
                Title = item.MainWindowTitle,
                Filename = item.FileName,
                TotalTime = item.Duration.TotalSeconds.ToString()
            };
        }
    }
}

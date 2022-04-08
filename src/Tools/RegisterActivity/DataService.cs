using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private DateTime lastTime;

        public DataService(IResolver resolver, IOptionsFactory optionsFactory)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            options = optionsFactory.Create("toggl");
            processData = new Dictionary<int, ProcessDTO>();
            lastTime = DateTime.Now;
        }

        public void CalculateData(IEnumerable<ProcessDTO> processes)
        {
            (IntPtr intPtr, string title) activeWindow = WindowTools.GetActiveWindowTitle();
            ProcessDTO currentProcess = processes.Where(p => p.MainWindowHandle == activeWindow.intPtr).FirstOrDefault();
            if (currentProcess != null)
            {
                TimeSpan duration = DateTime.Now - lastTime;
                lastTime = DateTime.Now;
                if (processData.TryGetValue(currentProcess.Id, out ProcessDTO process))
                {
                    currentProcess = process;
                }

                currentProcess.Duration = currentProcess.Duration.Add(duration);
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

        private void SaveData(IEnumerable<ProcessDTO> processes)
        {
            using ITogglDataDbContext db = resolver.Get<ITogglDataDbContext, DbContextOptions<TogglDataDbContext>>(options);
            foreach (ProcessDTO item in processes)
            {
                Winlog winlog = Map(item);
                db.Add(winlog);
            }
            db.SaveChanges();
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

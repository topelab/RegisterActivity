﻿using Microsoft.EntityFrameworkCore;
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

        private ProcessDTO lastProcess = null;

        public DataService(IResolver resolver, IOptionsFactory optionsFactory)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            options = optionsFactory.Create("toggl");
            processData = new Dictionary<int, ProcessDTO>();
        }

        public void CalculateData(ProcessDTO currentProcess)
        {
            int hashCode = currentProcess.GetHashCode();
            if (processData.TryGetValue(hashCode, out ProcessDTO process))
            {
                currentProcess = process;
            }
            DateTime lastMoment = currentProcess.LastTimeActive ?? DateTime.Now;
            currentProcess.LastTimeActive = DateTime.Now;
            currentProcess.Duration += DateTime.Now - lastMoment;

            if (lastProcess != null)
            {
                int lastHashCode = lastProcess.GetHashCode();
                if (lastHashCode != hashCode)
                {
                    SaveData(lastProcess);
                    processData[lastHashCode] = lastProcess;
                }
            }
            processData[hashCode] = currentProcess;
            lastProcess = currentProcess;
        }

        private void SaveData(ProcessDTO process)
        {
            using ITogglDataDbContext db = resolver.Get<ITogglDataDbContext, DbContextOptions<TogglDataDbContext>>(options);
            Winlog winlog = db.Winlog.Where(r => r.HashCode == process.GetHashCode()).OrderByDescending(r => r.StartTime).FirstOrDefault();

            if (winlog != null)
            {
                winlog.TotalTime = process.DurationInSeconds.ToString();
                winlog.Date = DateTime.Now.ToString("u");
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
                Date = DateTime.Now.ToString("u"),
                StartTime = item.StartTime.ToString("u"),
                Program = item.ProcessName,
                Title = item.MainWindowTitle,
                Filename = item.FileName,
                TotalTime = item.DurationInSeconds.ToString(),
                HashCode = item.GetHashCode()
            };
        }
    }
}

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

        public DataService(IResolver resolver, IOptionsFactory optionsFactory)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            options = optionsFactory.Create("toggl");
        }

        public void CalculateData(IEnumerable<ProcessDTO> processes)
        {

        }

        public void SaveData(IEnumerable<ProcessDTO> processes)
        {
            using ITogglDataDbContext db = resolver.Get<ITogglDataDbContext, DbContextOptions<TogglDataDbContext>>(options);
            foreach (ProcessDTO item in processes)
            {
                Winlog winlog = new Winlog
                {
                    Date = DateTime.UtcNow.ToString("u"),
                    StartTime = item.StartTime.ToString("u"),
                    Program = item.ProcessName,
                    Title = item.MainWindowTitle,
                    Filename = item.FileName
                };
                db.Add(winlog);
            }
            db.SaveChanges();
        }
    }
}

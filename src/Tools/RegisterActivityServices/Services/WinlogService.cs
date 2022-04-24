using Microsoft.EntityFrameworkCore;
using RegisterActivityServices.DTO;
using RegisterActivityServices.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using Topelab.Core.Resolver.Interfaces;
using Topelab.RegisterActivity.Adapters.Context;
using Topelab.RegisterActivity.Adapters.Interfaces;

namespace RegisterActivityServices.Services
{
    public class WinlogService : IWinlogService
    {
        private readonly IResolver resolver;
        private readonly IOptionsFactory optionsFactory;

        public WinlogService(IResolver resolver, IOptionsFactory optionsFactory)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            this.optionsFactory = optionsFactory ?? throw new ArgumentNullException(nameof(optionsFactory));
        }

        public List<TimelineEventsDTO> ReadDB(string file)
        {
            var connString = $"Data Source={file}";
            var options = optionsFactory.Create(connString);
            using var db = resolver.Get<IRegisterActivityDbContext, DbContextOptions<RegisterActivityDbContext>>(options);

            var datos = db.Winlog
                .Select(r => new TimelineEventsDTO
                {
                    LocalId = r.LocalId,
                    Title = r.Title,
                    StartTime = DateTime.Parse(r.StartTime),
                    EndTime = DateTime.Parse(r.EndTime),
                    Filename = r.Filename,
                    TotalTime = (double)r.TotalTime / 60.0,
                }).ToList();

            return datos;
        }

        public IEnumerable<TIn> GetAll<TIn>(string file) where TIn : class
        {
            var connString = $"Data Source={file}";
            var options = optionsFactory.Create(connString);
            using var db = resolver.Get<IRegisterActivityDbContext, DbContextOptions<RegisterActivityDbContext>>(options);
            var dbSet = db.Set<TIn>();

            return dbSet.AsNoTracking();
        }
    }
}

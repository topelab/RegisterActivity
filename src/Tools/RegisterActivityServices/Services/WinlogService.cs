using Microsoft.EntityFrameworkCore;
using RegisterActivityServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Topelab.RegisterActivity.Adapters.Interfaces;

namespace RegisterActivityServices.Services
{
    public class WinlogService : IWinlogService
    {
        private readonly IRegisterActivityDbContextFactory registerActivityDbContextFactory;

        public WinlogService(IRegisterActivityDbContextFactory registerActivityDbContextFactory)
        {
            this.registerActivityDbContextFactory = registerActivityDbContextFactory ?? throw new ArgumentNullException(nameof(registerActivityDbContextFactory));
        }

        public List<TimelineEventsDTO> GetTimeLineEvents()
        {
            using var db = registerActivityDbContextFactory.Create();

            var datos = db.Winlog.AsNoTracking()
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
    }
}

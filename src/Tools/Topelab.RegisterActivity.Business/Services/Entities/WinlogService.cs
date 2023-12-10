using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.Business.DTO;
using Topelab.RegisterActivity.Domain.Entities;

namespace Topelab.RegisterActivity.Business.Services.Entities
{
    /// <summary>
    /// Winlog service
    /// </summary>
    public class WinlogService : IWinlogService
    {
        /// <summary>
        /// The context database
        /// </summary>
        protected readonly IRegisterActivityDbContextFactory contextFactory;

        /// <summary>
        /// Initializes a new instance of the Winlog Service class.
        /// </summary>
        /// <param name="contextFactory">The context factory for service.</param>
        /// <param name="logService">The log service for service.</param>
        public WinlogService(IRegisterActivityDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        /// <summary>
        /// Get time line events from DB
        /// </summary>
        public List<TimelineEventsDTO> GetTimeLineEvents()
        {
            using var db = contextFactory.Create();

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

        /// <summary>
        /// Save winlog data with new duration
        /// </summary>
        /// <param name="winlogToSave">Register to save</param>
        /// <returns>The Id for the saved record</returns>
        public int Save(Winlog winlogToSave)
        {
            using var db = contextFactory.Create();
            db.Add(winlogToSave);
            db.SaveChanges();
            return winlogToSave.LocalId;
        }

    }
}
using Tools.TogglData.Business.Services;
using Tools.TogglData.Business.Services.Interfaces;
using Tools.TogglData.Domain.Dtos;
using System;
using Topelab.Core.Resolver.Entities;
using Topelab.Core.Resolver.Enums;

namespace Tools.TogglData.Business.SetupDI
{
    /// <summary>
    /// Di Services
    /// </summary>
    public static class BusinessSetupDI
    {
        /// <summary>
        /// Module dependencies to init on DI module
        /// </summary>
        public static ResolveInfoCollection ModuleDependencies { get => baseDependencies; }

        private static readonly ResolveInfoCollection baseDependencies = new ResolveInfoCollection()
            // Business Dependencies for TimelineEvent
            .AddScoped<ITimelineEventService, TimelineEventService>()
            // Business Dependencies for Winlog
            .AddScoped<IWinlogService, WinlogService>()

            // Other dependencies
            .Add<ILogService, LogService>()
            .Add<ICriteriaService, CriteriaService>();
    }
}

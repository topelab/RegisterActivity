using Topelab.RegisterActivity.Business.Services;
using Topelab.RegisterActivity.Business.Services.Entities;
using Topelab.RegisterActivity.Business.Services.Interfaces;
using Topelab.RegisterActivity.Domain.Dtos;
using System;
using Topelab.Core.Resolver.Entities;
using Topelab.Core.Resolver.Enums;

namespace Topelab.RegisterActivity.Business.SetupDI
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
            // Business Dependencies for Winlog
            .AddSingleton<IWinlogService, WinlogService>()

            // Other dependencies
            .AddSingleton<ILogService, LogService>()
            .AddSingleton<ICriteriaService, CriteriaService>();
    }
}

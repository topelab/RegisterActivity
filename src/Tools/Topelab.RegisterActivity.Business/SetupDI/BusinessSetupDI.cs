using Topelab.RegisterActivity.Business.Services;
using Topelab.RegisterActivity.Business.Services.Entities;
using Topelab.RegisterActivity.Business.Services.Interfaces;
using Topelab.RegisterActivity.Domain.Dtos;
using Topelab.RegisterActivity.Adapters.Context;
using Topelab.RegisterActivity.Adapters.Interfaces;
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
        public static ResolveInfoCollection ModuleDependencies => BaseDependencies();

        private static ResolveInfoCollection BaseDependencies()
        {
            return new ResolveInfoCollection()
            // Business Dependencies for Winlog
            .AddSingleton<IWinlogService, WinlogService>()

            // Other dependencies
            .AddSingleton<ILogService, LogService>()
            .AddSingleton<ICriteriaService, CriteriaService>()
            .AddSingleton<IRegisterActivityDbContextFactory, RegisterActivityDbContextFactory>();
        }
    }
}

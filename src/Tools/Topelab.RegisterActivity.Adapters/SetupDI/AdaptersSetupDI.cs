using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Topelab.Core.Resolver.Entities;
using Topelab.RegisterActivity.Adapters.Context;
using Topelab.RegisterActivity.Adapters.Interfaces;

namespace Topelab.RegisterActivity.Adapters.SetupDI
{
    /// <summary>
    /// Di Services
    /// </summary>
    public static class AdaptersSetupDI
    {
        /// <summary>
        /// Module dependencies to init on DI module
        /// </summary>
        public static ResolveInfoCollection ModuleDependencies => BaseDependencies();

        private static ResolveInfoCollection BaseDependencies()
        {
            return new ResolveInfoCollection()
                .AddSingleton<ILoggerFactory, LoggerFactory>()
                .AddScoped<IRegisterActivityDbContextOptionsFactory, RegisterActivityDbContextOptionsFactory>()
                .AddScoped<IRegisterActivityDbContextFactory, RegisterActivityDbContextFactory>()
                .AddScoped<IRegisterActivityDbContext, RegisterActivityDbContext>(typeof(DbContextOptions<RegisterActivityDbContext>), typeof(ILogger));
        }
    }
}

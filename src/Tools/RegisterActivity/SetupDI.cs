using Microsoft.EntityFrameworkCore;
using NLog;
using Tools.TogglData.Adapters.Context;
using Tools.TogglData.Adapters.Interfaces;
using Topelab.Core.Resolver.Entities;

namespace RegisterActivity
{
    internal class SetupDI
    {
        public static ResolveInfoCollection Register()
        {
            return new ResolveInfoCollection()
                .AddInstance<ILogger>(LogManager.GetCurrentClassLogger())
                .AddSingleton<IProcessService, ProcessService>()
                .AddSingleton<IOptionsFactory, OptionsFactory>()
                .AddSingleton<IDataService, DataService>()
                .Add<ITogglDataDbContext, TogglDataDbContext>(typeof(DbContextOptions<TogglDataDbContext>))
                ;
        }
    }
}

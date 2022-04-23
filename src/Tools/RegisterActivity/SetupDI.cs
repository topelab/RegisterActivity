using Microsoft.EntityFrameworkCore;
using NLog;
using RegisterActivity.Main;
using RegisterActivityServices.Factories;
using RegisterActivityServices.Services;
using Topelab.RegisterActivity.Adapters.Context;
using Topelab.RegisterActivity.Adapters.Interfaces;
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
                .AddSingleton<IExportService, ExportService>()
                .AddSingleton<IExportCsvService, ExportCsvService>()
                .AddSingleton<IExportExcelService, ExportExcelService>()
                .AddSingleton<IWinlogService, WinlogService>()
                .Add<IRegisterActivityDbContext, RegisterActivityDbContext>(typeof(DbContextOptions<RegisterActivityDbContext>))
                .Add<IMainWindowFactory, MainWindowFactory>()
                .Add<IMainWindowInitializer, MainWindowInitializer>()
                .AddSelf<MainWindow>(typeof(MainWindowVM))
                .AddSelf<MainWindowVM>()
                ;
        }
    }
}

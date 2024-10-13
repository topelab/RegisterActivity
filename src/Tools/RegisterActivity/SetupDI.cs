using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using RegisterActivity.Base;
using RegisterActivity.Main;
using System;
using System.Windows.Input;
using Topelab.Core.Resolver.Entities;
using Topelab.Core.Resolver.Interfaces;
using Topelab.RegisterActivity.BaseBusiness.Enums;
using Topelab.RegisterActivity.Business.Services;
using Topelab.RegisterActivity.Business.Services.Entities;
using Topelab.RegisterActivity.Business.SetupDI;

namespace RegisterActivity
{
    internal static class SetupDI
    {
        public static ResolveInfoCollection Register()
        {
            return new ResolveInfoCollection()
                .AddCollection(BusinessSetupDI.ModuleDependencies)
                .AddSingleton<IProcessService, ProcessService>()
                .AddSingleton<IDataService, DataService>()
                .AddSingleton<ICommand, BaseCommand<ExportFormat>>(nameof(ExportFormat), typeof(Action<ExportFormat>))
                .AddSingleton<IWinlogService, WinlogService>()
                .AddSingleton<ILoggerFactory, LoggerFactory>()
                .AddFactory(s => GetLogger(s))
                .AddTransient<IMainWindowFactory, MainWindowFactory>()
                .AddTransient<IMainWindowInitializer, MainWindowInitializer>()
                .AddSelf<MainWindow>(typeof(MainWindowVM))
                .AddSelf<MainWindowVM>()
                ;
        }

        private static ILogger GetLogger(IResolver resolver)
        {
            var factory = resolver.Get<ILoggerFactory>();
            factory.AddProvider(new NLogLoggerProvider());
            return factory.CreateLogger("RegisterActivity");
        }

    }
}

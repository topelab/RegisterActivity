using Microsoft.EntityFrameworkCore;
using RegisterActivity.Factories;
using System;
using System.Reflection;
using Topelab.Core.Helpers.Extensions;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.BaseBusiness.Enums;
using Topelab.RegisterActivity.Business.DTO;
using Topelab.RegisterActivity.Business.Services;

namespace RegisterActivity.Main
{
    internal class MainWindowInitializer : IMainWindowInitializer
    {
        private readonly IProcessService processService;
        private readonly IDataService dataService;
        private readonly IExportDataService exportService;
        private readonly ICommandFactory commandFactory;
        private readonly IRegisterActivityDbContextFactory dbContextFactory;

        public MainWindowInitializer(IProcessService processService, IDataService dataService, IExportDataService exportService, ICommandFactory commandFactory, IRegisterActivityDbContextFactory dbContextFactory)
        {
            this.processService = processService ?? throw new ArgumentNullException(nameof(processService));
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            this.exportService = exportService ?? throw new ArgumentNullException(nameof(exportService));
            this.commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
            this.dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public void Initialize(MainWindowVM mainWindowVM)
        {
            SetTitle(mainWindowVM);
            SetCommands(mainWindowVM);
            StartServices(mainWindowVM);
        }

        private DateTime lastDate;

        private void UpdateEnvironment(DateTime date, bool isFirstTime)
        {
            if (date.Date > lastDate)
            {
                if (!isFirstTime)
                {
                    using var oldDB = dbContextFactory.Create();
                    oldDB.Database.CloseConnection();
                }
                lastDate = date.Date;
                Environment.SetEnvironmentVariable("YEAR", date.ToString("yyyy"));
                Environment.SetEnvironmentVariable("MONTH", date.ToString("MM"));
                Environment.SetEnvironmentVariable("DAY", date.ToString("dd"));
                using var db = dbContextFactory.Create();
                db.Database.EnsureCreated();
            }
        }

        private void StartServices(MainWindowVM mainWindowVM)
        {
            bool isFirstTime = true;
            void RegisterData(ProcessDTO currentProcess)
            {
                UpdateEnvironment(DateTime.Today, isFirstTime);
                dataService.CalculateData(currentProcess, o => mainWindowVM.AddMessage($"{o.StartTime:g} - {o.MainWindowTitle}"));
                isFirstTime = false;
            }

            processService.Start(RegisterData);
            App.Current.Exit += Current_Exit;
        }

        private void SetCommands(MainWindowVM mainWindowVM)
        {
            mainWindowVM.ExportCommand = commandFactory.Create<ExportFormat>(exportService.Start);
        }

        private void SetTitle(MainWindowVM mainWindowVM)
        {
            var version = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion.Piece(0,'+');
            mainWindowVM.Title = $"Register activities ({version})";
        }

        private void Current_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            App.Current.Exit -= Current_Exit;
            processService.Stop();
        }
    }
}

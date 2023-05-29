using System;
using System.Reflection;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.Business.DTO;
using Topelab.RegisterActivity.Business.Enums;
using Topelab.RegisterActivity.Business.Services;
using Topelab.RegisterActivity.Domain.Factories;

namespace RegisterActivity.Main
{
    internal class MainWindowInitializer : IMainWindowInitializer
    {
        private readonly IProcessService processService;
        private readonly IDataService dataService;
        private readonly IExportService exportService;
        private readonly ICommandFactory commandFactory;
        private readonly IRegisterActivityDbContextFactory dbContextFactory;

        public MainWindowInitializer(IProcessService processService, IDataService dataService, IExportService exportService, ICommandFactory commandFactory, IRegisterActivityDbContextFactory dbContextFactory)
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
            InitializeData();
            StartServices(mainWindowVM);
        }

        private void InitializeData()
        {
            Environment.SetEnvironmentVariable("YEAR", DateTime.Now.ToString("yyyy"));
            Environment.SetEnvironmentVariable("MONTH", DateTime.Now.ToString("MM"));
            Environment.SetEnvironmentVariable("DAY", DateTime.Now.ToString("dd"));
            using var db = dbContextFactory.Create();
            db.Database.EnsureCreated();
        }

        private void StartServices(MainWindowVM mainWindowVM)
        {
            void RegisterData(ProcessDTO currentProcess) => dataService.CalculateData(currentProcess, o => mainWindowVM.AddMessage($"{o.StartTime:g} - {o.MainWindowTitle}"));
            processService.Start(RegisterData);
            App.Current.Exit += Current_Exit;
        }

        private void SetCommands(MainWindowVM mainWindowVM)
        {
            mainWindowVM.ExportCommand = commandFactory.Create<ExportFormat>(exportService.Start);
        }

        private void SetTitle(MainWindowVM mainWindowVM)
        {
            var version = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            mainWindowVM.Title = $"Register activities ({version})";
        }

        private void Current_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            App.Current.Exit -= Current_Exit;
            processService.Stop();
        }
    }
}

using System;
using System.Reflection;
using System.Windows.Input;
using Topelab.Core.Resolver.Interfaces;
using Topelab.RegisterActivity.Business.DTO;
using Topelab.RegisterActivity.Business.Enums;
using Topelab.RegisterActivity.Business.Services;

namespace RegisterActivity.Main
{
    internal class MainWindowInitializer : IMainWindowInitializer
    {
        private readonly IResolver resolver;
        private readonly IProcessService processService;
        private readonly IDataService dataService;
        private readonly IExportService exportService;

        private MainWindowVM mainWindowVM;


        public MainWindowInitializer(IResolver resolver, IProcessService processService, IDataService dataService, IExportService exportService)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            this.processService = processService ?? throw new System.ArgumentNullException(nameof(processService));
            this.dataService = dataService ?? throw new System.ArgumentNullException(nameof(dataService));
            this.exportService = exportService ?? throw new System.ArgumentNullException(nameof(exportService));
        }

        public void Initialize(MainWindowVM mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
            var version = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            mainWindowVM.Title = $"Register activities ({version})";


            var exportCommand = resolver.Get<ICommand, Action<ExportFormat>>(MainCommandsEnum.ExportCommand.ToString(), exportService.Start);
            mainWindowVM.SetCommands(exportCommand);

            processService.Start(RegisterData);
            App.Current.Exit += Current_Exit;
        }

        private void RegisterData(ProcessDTO currentPocess)
        {
            dataService.CalculateData(currentPocess, o => mainWindowVM.AddMessage($"{o.StartTime:g} - {o.MainWindowTitle}"));
        }

        private void Current_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            App.Current.Exit -= Current_Exit;
            processService.Stop();

        }
    }
}

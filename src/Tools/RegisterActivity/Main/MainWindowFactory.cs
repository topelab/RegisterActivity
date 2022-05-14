using System;
using Topelab.Core.Resolver.Interfaces;
using Topelab.RegisterActivity.Business.DTO;
using Topelab.RegisterActivity.Business.Services;
using Topelab.RegisterActivity.Domain.Base;

namespace RegisterActivity.Main
{
    internal class MainWindowFactory : IMainWindowFactory
    {
        private MainWindow mainWindow;
        private MainWindowVM mainWindowVM;

        private readonly IMainWindowInitializer mainWindowInitializer;
        private readonly IResolver resolver;
        private readonly IProcessService processService;
        private readonly IDataService dataService;
        private readonly IExportService exportService;

        public MainWindowFactory(IResolver resolver, IMainWindowInitializer mainWindowInitializer, IProcessService processService, IDataService dataService, IExportService exportService)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            this.mainWindowInitializer = mainWindowInitializer ?? throw new ArgumentNullException(nameof(mainWindowInitializer));
            this.processService = processService ?? throw new ArgumentNullException(nameof(processService));
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            this.exportService = exportService ?? throw new ArgumentNullException(nameof(exportService));
        }

        public MainWindow Create()
        {
            mainWindowVM = resolver.Get<MainWindowVM>();
            mainWindow = resolver.Get<MainWindow, MainWindowVM>(mainWindowVM);
            mainWindowInitializer.Initialize(mainWindow.WindowVM);

            var exportCommand = new BaseCommand<ExportFormat>(exportService.Start);
            mainWindowVM.SetCommands(exportCommand);

            processService.Start(RegisterData);
            App.Current.Exit += Current_Exit;
            return mainWindow;
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

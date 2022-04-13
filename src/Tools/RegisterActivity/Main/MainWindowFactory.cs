using RegisterActivity.DTO;
using RegisterActivity.Services;
using System;
using Topelab.Core.Resolver.Interfaces;

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

        public MainWindowFactory(IResolver resolver, IMainWindowInitializer mainWindowInitializer, IProcessService processService, IDataService dataService)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            this.mainWindowInitializer = mainWindowInitializer ?? throw new ArgumentNullException(nameof(mainWindowInitializer));
            this.processService = processService ?? throw new ArgumentNullException(nameof(processService));
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public MainWindow Create()
        {
            mainWindowVM = this.resolver.Get<MainWindowVM>();
            mainWindow = this.resolver.Get<MainWindow, MainWindowVM>(mainWindowVM);
            mainWindowInitializer.Initialize(mainWindow.WindowVM);

            processService.Start(RegisterData);
            App.Current.Exit += Current_Exit;
            return mainWindow;
        }

        private void RegisterData(ProcessDTO currentPocess)
        {
            dataService.CalculateData(currentPocess, o => mainWindowVM.AddMessage(o.MainWindowTitle));
        }

        private void Current_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            App.Current.Exit -= Current_Exit;
            processService.Stop();
        }
    }
}

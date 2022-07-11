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

        public MainWindowFactory(IResolver resolver, IMainWindowInitializer mainWindowInitializer)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            this.mainWindowInitializer = mainWindowInitializer ?? throw new ArgumentNullException(nameof(mainWindowInitializer));
        }

        public MainWindow Create()
        {
            mainWindowVM = resolver.Get<MainWindowVM>();
            mainWindowInitializer.Initialize(mainWindowVM);
            mainWindow = resolver.Get<MainWindow, MainWindowVM>(mainWindowVM);
            return mainWindow;
        }
    }
}

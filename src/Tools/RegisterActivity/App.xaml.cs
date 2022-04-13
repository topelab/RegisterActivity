using RegisterActivity.Main;
using System.Windows;
using Topelab.Core.Resolver.Interfaces;
using Topelab.Core.Resolver.Microsoft;

namespace RegisterActivity
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IResolver resolver;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            resolver = ResolverFactory.Create(SetupDI.Register());
            var mainWindowFactory = resolver.Get<IMainWindowFactory>();
            MainWindow = mainWindowFactory.Create();
        }

        public static IResolver Resolver => resolver;
    }
}

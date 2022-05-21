using System.Reflection;

namespace RegisterActivity.Main
{
    internal class MainWindowInitializer : IMainWindowInitializer
    {
        public void Initialize(MainWindowVM mainWindowVM)
        {
            string version = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            mainWindowVM.Title = $"Register activities ({version})";
        }
    }
}

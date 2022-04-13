using System.Collections.ObjectModel;

namespace RegisterActivity.Main
{
    internal class MainWindowInitializer : IMainWindowInitializer
    {
        public void Initialize(MainWindowVM mainWindowVM)
        {
            mainWindowVM.Title = "Register activities";
        }
    }
}

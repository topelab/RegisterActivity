using RegisterActivity.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace RegisterActivity.Main
{
    public class MainWindowVM : BaseModel<string>
    {
        public ObservableCollection<string> Messages { get; }

        private string title;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private ICommand exportCommand;
        public ICommand ExportCommand
        {
            get => exportCommand;
            set => SetProperty(ref exportCommand, value);
        }

        private readonly Dispatcher dispatcher;

        public MainWindowVM()
        {
            Messages = new ObservableCollection<string>();
            dispatcher = App.Current.Dispatcher;
        }

        public void AddMessage(string message)
        {
            dispatcher.BeginInvoke(() =>
            {
                Messages.Insert(0, message);
                if (Messages.Count > 30)
                {
                    Messages.RemoveAt(Messages.Count - 1);
                }
            });
        }
    }
}
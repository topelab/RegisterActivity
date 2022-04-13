using System.Collections.ObjectModel;
using System.Windows.Threading;
using Tools.TogglData.Domain.Base;

namespace RegisterActivity.Main
{
    public class MainWindowVM : BaseModel
    {
        private ObservableCollection<string> messages;

        public ObservableCollection<string> Messages
        {
            get => messages;
        }

        private string title;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private readonly Dispatcher dispatcher; 

        public MainWindowVM()
        {
            this.messages = new ObservableCollection<string>();
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
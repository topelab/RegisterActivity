using System;
using System.Windows.Input;

namespace RegisterActivity.Base
{
    /// <summary>
    /// Base command
    /// </summary>
    /// <typeparam name="T">Type for parameter</typeparam>
    public class BaseCommand<T> : ICommand
    {
        /// <summary>
        /// Event handler triggered when can execute property changed
        /// </summary>
        public event EventHandler CanExecuteChanged;

        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;
        private bool canExecuteLastResult;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute">Command Execute</param>
        public BaseCommand(Action<T> execute) : this(execute, null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute">Command Execute</param>
        /// <param name="canExecute">Command can execute</param>
        public BaseCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Test if command can execute
        /// </summary>
        /// <param name="parameter"></param>
        public bool CanExecute(object parameter)
        {
            var result = canExecute?.Invoke((T)parameter) ?? true;
            if (result != canExecuteLastResult)
            {
                canExecuteLastResult = result;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
            return result;
        }

        /// <summary>
        /// Command execute
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            execute?.Invoke((T)parameter);
        }

        /// <summary>
        /// Trigger can execute changed
        /// </summary>
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

using System;
using System.Windows.Input;

namespace Topelab.RegisterActivity.Domain.Factories
{
    /// <summary>
    /// Interface representing a command factory
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Creates an ICommand with an execute action
        /// </summary>
        /// <typeparam name="T">Parameter type for execute action</typeparam>
        /// <param name="execute">Execute action</param>
        ICommand Create<T>(Action<T> execute);
        /// <summary>
        /// Creates an ICommand with an execute action and a canExecute function
        /// </summary>
        /// <typeparam name="T">Parameter type for execute action and canExecute function</typeparam>
        /// <param name="execute">Execute action</param>
        /// <param name="canExecute">CanExecute function</param>
        ICommand Create<T>(Action<T> execute, Func<T, bool> canExecute = null);
    }
}
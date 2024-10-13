using System;
using System.Windows.Input;
using Topelab.Core.Resolver.Interfaces;

namespace RegisterActivity.Factories
{
    /// <summary>
    /// Command factory
    /// </summary>
    public class CommandFactory : ICommandFactory
    {
        private readonly IResolver resolver;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resolver">Resolver</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CommandFactory(IResolver resolver)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        /// <summary>
        /// Creates an ICommand with an execute action
        /// </summary>
        /// <typeparam name="T">Parameter type for execute action</typeparam>
        /// <param name="execute">Execute action</param>
        public ICommand Create<T>(Action<T> execute)
        {
            var resolverName = typeof(T).Name;
            return resolver.Get<ICommand, Action<T>>(resolverName, execute);
        }

        /// <summary>
        /// Creates an ICommand with an execute action and a canExecute function
        /// </summary>
        /// <typeparam name="T">Parameter type for execute action and canExecute function</typeparam>
        /// <param name="execute">Execute action</param>
        /// <param name="canExecute">CanExecute function</param>
        public ICommand Create<T>(Action<T> execute, Func<T, bool> canExecute = null)
        {
            var resolverName = typeof(T).Name;
            return resolver.Get<ICommand, Action<T>, Func<T, bool>>(resolverName, execute, canExecute);
        }
    }
}

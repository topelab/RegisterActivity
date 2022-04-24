using System;
using System.Runtime.CompilerServices;
using Topelab.RegisterActivity.Business.Enums;
using Topelab.RegisterActivity.Business.Services.Interfaces;

namespace Topelab.RegisterActivity.Business.Services
{
    /// <summary>
    /// Log service class: has the responsability to log different types of message
    /// </summary>
    public class LogService : ILogService
    {
        private IEmailerService emailerService;

        /// <summary>
        /// Gets the last error.
        /// </summary>
        public string LastError => LogServiceStaticImpl.LastError;
        /// <summary>
        /// Gets a value indicating whether this instance has errors.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has errors; otherwise, <c>false</c>.
        /// </value>
        public bool HasErrors => LogServiceStaticImpl.HasErrors;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogService"/> class.
        /// </summary>
        public LogService() : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogService"/> class.
        /// </summary>
        /// <param name="emailerService">The emailer service.</param>
        public LogService(IEmailerService emailerService)
        {
            this.emailerService = emailerService;
        }

        /// <summary>
        /// Errors the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        public void Error(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            LogServiceStaticImpl.Error(text, memberName, sourceFilePath);
            emailerService?.SendEmailError(LastError);
        }

        /// <summary>
        /// Informations the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Info(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            LogServiceStaticImpl.Info(text, memberName, sourceFilePath);
        }

        /// <summary>
        /// Logs the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="tipo">The tipo.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Log(string text, LogType tipo = LogType.Info, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            LogServiceStaticImpl.Log(text, tipo, memberName, sourceFilePath);
        }

        /// <summary>
        /// Screens the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="color">The color.</param>
        /// <param name="tipo">The tipo.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Screen(string text, ConsoleColor? color = null, LogType? tipo = null, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            LogServiceStaticImpl.Screen(text, color, tipo, memberName, sourceFilePath);
        }

        /// <summary>
        /// Traces the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Trace(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            LogServiceStaticImpl.Trace(text, memberName, sourceFilePath);
        }

        /// <summary>
        /// Warns the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Warn(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            LogServiceStaticImpl.Warn(text, memberName, sourceFilePath);
        }

        /// <summary>
        /// Sets the emailer.
        /// </summary>
        /// <param name="emailerService">The emailer service.</param>
        public void SetEmailer(IEmailerService emailerService)
        {
            this.emailerService = emailerService;
        }
    }
}

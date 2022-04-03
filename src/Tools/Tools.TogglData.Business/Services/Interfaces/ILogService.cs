using System;
using System.Runtime.CompilerServices;
using Tools.TogglData.Business.Enums;

namespace Tools.TogglData.Business.Services.Interfaces
{
    /// <summary>
    /// Interface to log service
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// Gets the last error.
        /// </summary>
        string LastError { get; }
        /// <summary>
        /// Gets a value indicating whether this instance has errors.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has errors; otherwise, <c>false</c>.
        /// </value>
        bool HasErrors { get; }

        /// <summary>
        /// Logs the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="tipo">The tipo.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        void Log(string text, LogType tipo = LogType.Info,
                     [CallerMemberName] string memberName = "",
                     [CallerFilePath] string sourceFilePath = "");

        /// <summary>
        /// Screens the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="color">The color.</param>
        /// <param name="tipo">The tipo.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        void Screen(string text, ConsoleColor? color = null, LogType? tipo = null,
                     [CallerMemberName] string memberName = "",
                     [CallerFilePath] string sourceFilePath = "");

        /// <summary>
        /// Traces the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        void Trace(string text,
                     [CallerMemberName] string memberName = "",
                     [CallerFilePath] string sourceFilePath = "");

        /// <summary>
        /// Informations the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        void Info(string text,
                     [CallerMemberName] string memberName = "",
                     [CallerFilePath] string sourceFilePath = "");

        /// <summary>
        /// Warns the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        void Warn(string text,
                     [CallerMemberName] string memberName = "",
                     [CallerFilePath] string sourceFilePath = "");

        /// <summary>
        /// Errors the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        void Error(string text,
                     [CallerMemberName] string memberName = "",
                     [CallerFilePath] string sourceFilePath = "");

        /// <summary>
        /// Sets the emailer.
        /// </summary>
        /// <param name="emailerService">The emailer service.</param>
        void SetEmailer(IEmailerService emailerService);
    }
}

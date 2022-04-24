using NLog;
using System;
using System.Runtime.CompilerServices;
using Topelab.RegisterActivity.Business.Enums;

namespace Topelab.RegisterActivity.Business.Services
{
    /// <summary>
    /// Static implementation for the log service
    /// </summary>
    public class LogServiceStaticImpl
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets the last error.
        /// </summary>
        public static string LastError { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance has errors.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has errors; otherwise, <c>false</c>.
        /// </value>
        public static bool HasErrors => !string.IsNullOrWhiteSpace(LastError);

        /// <summary>
        /// Logs the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="tipo">The tipo.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        public static void Log(string text, LogType tipo = LogType.Info,
                     [CallerMemberName] string memberName = "",
                     [CallerFilePath] string sourceFilePath = "")
        {
            var Terminal = $"{Environment.GetEnvironmentVariable("CLIENTNAME")} {Environment.GetEnvironmentVariable("COMPUTERNAME")}".Trim();
            var Usuario = Environment.GetEnvironmentVariable("USERNAME");

            string module = $"{System.IO.Path.GetFileNameWithoutExtension(sourceFilePath)}.{memberName}";
            string output = $"{Usuario} {Terminal} {module}: {text}";

            LastError = string.Empty;
            switch (tipo)
            {
                case LogType.Trace:
                    _logger.Trace(output);
                    break;
                case LogType.Info:
                    _logger.Info(output);
                    break;
                case LogType.Warnning:
                    _logger.Warn(output);
                    break;
                case LogType.Error:
                    _logger.Error(output);
                    LastError = text;
                    break;
                case LogType.Critical:
                    _logger.Error(output);
                    LastError = text;
                    break;

            }

        }

        /// <summary>
        /// Screens the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="color">The color.</param>
        /// <param name="tipo">The tipo.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        public static void Screen(string text, ConsoleColor? color = null, LogType? tipo = null,
                     [CallerMemberName] string memberName = "",
                     [CallerFilePath] string sourceFilePath = "")
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color ?? currentColor;
            Console.WriteLine(text);
            Console.ResetColor();

            if (tipo != null)
            {
                Log(text, tipo.Value, memberName, sourceFilePath);
            }
        }

        /// <summary>
        /// Traces the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        public static void Trace(string text,
                     [CallerMemberName] string memberName = "",
                     [CallerFilePath] string sourceFilePath = "")
        {
            Log(text, LogType.Trace, memberName, sourceFilePath);
        }
        /// <summary>
        /// Informations the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        public static void Info(string text,
                     [CallerMemberName] string memberName = "",
                     [CallerFilePath] string sourceFilePath = "")
        {
            Log(text, LogType.Info, memberName, sourceFilePath);
        }
        /// <summary>
        /// Warns the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        public static void Warn(string text,
                     [CallerMemberName] string memberName = "",
                     [CallerFilePath] string sourceFilePath = "")
        {
            Log(text, LogType.Warnning, memberName, sourceFilePath);
        }
        /// <summary>
        /// Errors the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        public static void Error(string text,
                     [CallerMemberName] string memberName = "",
                     [CallerFilePath] string sourceFilePath = "")
        {
            Log(text, LogType.Error, memberName, sourceFilePath);
        }

    }
}

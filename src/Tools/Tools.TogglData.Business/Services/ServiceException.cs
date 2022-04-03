using System;
using System.Runtime.CompilerServices;
using Tools.TogglData.Business.Services.Interfaces;

namespace Tools.TogglData.Business.Services
{
    /// <summary>
    /// Service Exception class.
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the Service Exception class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ServiceException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Service Exception class with params.
        /// </summary>
        /// <param name="logService">The log service.</param>
        /// <param name="message">The message.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        public ServiceException(ILogService logService,
                                string message,
                                [CallerMemberName] string memberName = "",
                                [CallerFilePath] string sourceFilePath = "") : base(message)
        {
            logService.Error(message, memberName, sourceFilePath);
        }
    }
}

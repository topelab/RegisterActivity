using System;
using System.Runtime.CompilerServices;
using Topelab.RegisterActivity.Business.Services.Interfaces;

namespace Topelab.RegisterActivity.Business.Services
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

        /// <summary>
        /// Initializes a new instance of the Service Exception class with params.
        /// </summary>
        public ServiceException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Service Exception class with params.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">Inner exception.</param>
        public ServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

namespace Topelab.RegisterActivity.Business.Services.Interfaces
{
    /// <summary>
    /// Interface to implementation of service for emailing
    /// </summary>
    public interface IEmailerService
    {
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="to">To.</param>
        /// <param name="message">The message.</param>
        /// <param name="lastError">The last error.</param>
        /// <param name="bypassTest">if set to <c>true</c> [bypass test].</param>
        void SendEmail(string subject, string to, string message, string lastError = null, bool bypassTest = false);

        /// <summary>
        /// Sends the email error.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        void SendEmailError(string errorMessage);
    }
}

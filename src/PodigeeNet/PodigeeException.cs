using System;

namespace PodigeeNet
{
    /// <summary>
    /// Represents errors that occur during application execution.
    /// </summary>
    public class PodigeeException : Exception
    {
        #region Public Properties
        /// <summary>
        /// Gets the code that describes the error.
        /// </summary>
        public int Code { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PodigeeException"/> class with a specified
        /// error message.
        /// </summary>
        /// <param name="code">The code that describes the error.</param>
        /// <param name="message">The message that describes the error.</param>
        public PodigeeException(int code, string message)
            : this(code, message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PodigeeException"/> class with a specified
        /// error message and a reference to the inner exception that is the cause of this
        /// exception.
        /// </summary>
        /// <param name="code">The code that describes the error.</param>
        /// <param name="message">The error message that explains the reason for the
        /// exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception,
        /// or a null reference if no inner exception is specified.</param>
        public PodigeeException(int code, string message, Exception innerException)
            : base(message, innerException)
        {
            Code = code;
        }
        #endregion
    }
}
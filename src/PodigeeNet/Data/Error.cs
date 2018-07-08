namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a Podigee API error.
    /// </summary>
    internal class Error
    {
        #region Public Properties
        /// <summary>
        /// Gets the error code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Message { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        public Error()
        {
        }
        #endregion
    }
}
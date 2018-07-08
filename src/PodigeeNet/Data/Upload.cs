using Newtonsoft.Json;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a file upload result.
    /// </summary>
    public class Upload
    {
        #region Public Properties
        /// <summary>
        /// Gets the file upload URL.
        /// </summary>
        [JsonProperty]
        public string UploadUrl { get; internal set; }

        /// <summary>
        /// Gets the file content type.
        /// </summary>
        [JsonProperty]
        public string ContentType { get; internal set; }

        /// <summary>
        /// Gets the file URL.
        /// </summary>
        [JsonProperty]
        public string FileUrl { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Upload"/> class.
        /// </summary>
        internal Upload()
        {
        }
        #endregion

        #region Public Override Methods
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return FileUrl;
        }
        #endregion
    }
}
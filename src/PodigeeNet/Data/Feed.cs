using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a feed.
    /// </summary>
    public class Feed
    {
        #region Public Properties
        /// <summary>
        /// Gets the feed format.
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public FeedFormat Format { get; internal set; }

        /// <summary>
        /// Gets the feed URL.
        /// </summary>
        [JsonProperty]
        public string Url { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Feed"/> class.
        /// </summary>
        internal Feed()
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
            return Url;
        }
        #endregion
    }
}
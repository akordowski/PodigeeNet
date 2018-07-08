using Newtonsoft.Json;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a contributor link.
    /// </summary>
    public class ContributorLink
    {
        #region Public Properties
        /// <summary>
        /// Gets the link icon.
        /// </summary>
        [JsonProperty]
        public string Icon { get; internal set; }

        /// <summary>
        /// Gets the link URL.
        /// </summary>
        [JsonProperty]
        public string Url { get; internal set; }

        /// <summary>
        /// Gets the link text.
        /// </summary>
        [JsonProperty]
        public string Text { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ContributorLink"/> class.
        /// </summary>
        internal ContributorLink()
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
            return Text;
        }
        #endregion
    }
}
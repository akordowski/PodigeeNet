using Newtonsoft.Json;
using System;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a production file.
    /// </summary>
    public class ProductionFile
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets a fully qualified file URL.
        /// </summary>
        [JsonProperty]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a contributor ID.
        /// </summary>
        [JsonProperty]
        public int ContributorId { get; set; }

        /// <summary>
        /// Gets or sets a custom name for the track.
        /// </summary>
        [JsonProperty]
        public string CustomName { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductionFile"/> class.
        /// </summary>
        internal ProductionFile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductionFile"/> class.
        /// </summary>
        /// <param name="url">The fully qualified file URL.</param>
        /// <exception cref="ArgumentException"><em>url</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>url</em> is <strong>null</strong>.</exception>
        public ProductionFile(string url)
            : this(url, 0, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductionFile"/> class.
        /// </summary>
        /// <param name="url">A fully qualified file URL.</param>
        /// <param name="contributorId">A contributor ID.</param>
        /// <param name="customName">A custom name for the track.</param>
        /// <exception cref="ArgumentException"><em>url</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>url</em> is <strong>null</strong>.</exception>
        public ProductionFile(string url, int contributorId, string customName)
        {
            Precondition.IsNotNullOrWhiteSpace(url, nameof(url));

            Url = url;
            ContributorId = contributorId;
            CustomName = customName;
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
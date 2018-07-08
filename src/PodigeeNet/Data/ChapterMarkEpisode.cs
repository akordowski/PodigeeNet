using Newtonsoft.Json;
using System;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a episode chapter mark.
    /// </summary>
    public class ChapterMarkEpisode
    {
        #region Public Properties
        /// <summary>
        /// Gets the chapter mark ID.
        /// </summary>
        [JsonProperty]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets the chapter mark title.
        /// </summary>
        [JsonProperty]
        public string Title { get; internal set; }

        /// <summary>
        /// Gets the chapter mark start time.
        /// </summary>
        [JsonProperty]
        public TimeSpan StartTime { get; internal set; }

        /// <summary>
        /// Gets the URL to an external resource related to the chapter.
        /// </summary>
        [JsonProperty]
        public string Url { get; internal set; }

        /// <summary>
        /// Gets the chapter mark creation date.
        /// </summary>
        [JsonProperty]
        public DateTime CreatedAt { get; internal set; }

        /// <summary>
        /// Gets the chapter mark update date.
        /// </summary>
        [JsonProperty]
        public DateTime UpdatedAt { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ChapterMarkEpisode"/> class.
        /// </summary>
        internal ChapterMarkEpisode()
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
            return Title;
        }
        #endregion
    }
}
using Newtonsoft.Json;
using System;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a chapter mark.
    /// </summary>
    public class ChapterMark
    {
        #region Public Properties
        /// <summary>
        /// Gets the chapter mark ID.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets the episode ID.
        /// </summary>
        [JsonProperty]
        public long EpisodeId { get; internal set; }

        /// <summary>
        /// Gets or sets the chapter mark title.
        /// </summary>
        [JsonProperty]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the chapter mark start time.
        /// </summary>
        [JsonProperty]
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Gets or sets the URL to an external resource related to the chapter.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>
        /// Gets the chapter mark creation date.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public DateTime CreatedAt { get; internal set; }

        /// <summary>
        /// Gets the chapter mark update date.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public DateTime UpdatedAt { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ChapterMark"/> class.
        /// </summary>
        internal ChapterMark()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChapterMark"/> class.
        /// </summary>
        /// <param name="episodeId">The episode ID.</param>
        /// <param name="title">The chapter mark title.</param>
        /// <param name="startTime">The chapter mark start time.</param>
        /// <exception cref="ArgumentException"><em>title</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>title</em> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1, or
        /// <em>startTime</em> is less then 00:00:00.</exception>
        public ChapterMark(long episodeId, string title, TimeSpan startTime)
            : this(episodeId, title, startTime, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChapterMark"/> class.
        /// </summary>
        /// <param name="episodeId">The episode ID.</param>
        /// <param name="title">The chapter mark title.</param>
        /// <param name="startTime">The chapter mark start time.</param>
        /// <param name="url">URL to an external resource related to the chapter mark.</param>
        /// <exception cref="ArgumentException"><em>title</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>title</em> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1, or
        /// <em>startTime</em> is less then 00:00:00.</exception>
        public ChapterMark(long episodeId, string title, TimeSpan startTime, string url)
        {
            Precondition.IsGreater(episodeId, (long)0, nameof(episodeId));
            Precondition.IsNotNullOrWhiteSpace(title, nameof(title));
            Precondition.IsGreaterOrEqual(startTime, TimeSpan.Zero, nameof(startTime));

            EpisodeId = episodeId;
            Title = title;
            StartTime = startTime;
            Url = url;
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
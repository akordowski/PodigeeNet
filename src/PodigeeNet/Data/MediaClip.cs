using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a media clip.
    /// </summary>
    public class MediaClip
    {
        #region Public Properties
        /// <summary>
        /// Gets the media clip ID.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets the episode ID.
        /// </summary>
        [JsonProperty]
        public long EpisodeId { get; internal set; }

        /// <summary>
        /// Gets or sets the media clip format.
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public FileFormat FileFormat { get; set; }

        /// <summary>
        /// Gets or sets the media clip URL.
        /// </summary>
        [JsonProperty]
        public string Url { get; set; }

        /// <summary>
        /// Gets the media clip creation date.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public DateTime CreatedAt { get; internal set; }

        /// <summary>
        /// Gets the media clip size in bytes.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Size { get; internal set; }

        /// <summary>
        /// Gets the media clip duration in seconds.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Duration { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaClip"/> class.
        /// </summary>
        internal MediaClip()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaClip"/> class.
        /// </summary>
        /// <param name="episodeId">The episode ID.</param>
        /// <param name="fileFormat">The media clip file format.</param>
        /// <param name="url">The media clip URL.</param>
        /// <exception cref="ArgumentException"><em>url</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>url</em> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException"><em>fileFormat</em>
        /// is invalid enumeration.</exception>
        public MediaClip(long episodeId, FileFormat fileFormat, string url)
        {
            Precondition.IsGreater(episodeId, (long)0, nameof(episodeId));
            Precondition.IsValidEnum(fileFormat, nameof(fileFormat));
            Precondition.IsNotNullOrWhiteSpace(url, nameof(url));

            EpisodeId = episodeId;
            FileFormat = fileFormat;
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
            return Url;
        }
        #endregion
    }
}
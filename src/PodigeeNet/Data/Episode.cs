using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a episode.
    /// </summary>
    public class Episode
    {
        #region Public Properties
        /// <summary>
        /// Gets the episode ID.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets the episode GUID.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Guid { get; set; }

        /// <summary>
        /// Gets the podcast ID.
        /// </summary>
        [JsonProperty]
        public long PodcastId { get; internal set; }

        /// <summary>
        /// Gets the production ID.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public long? ProductionId { get; internal set; }

        /// <summary>
        /// Gets or sets the episode title.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the episode subtitle.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the episode description.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Gets the episode slug.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public string Slug { get; internal set; }

        /// <summary>
        /// Gets or sets the episode external URL.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalUrl { get; set; }

        /// <summary>
        /// Gets or sets the episode number.
        /// </summary>
        [JsonProperty]
        public long Number { get; set; }

        /// <summary>
        /// Gets or sets the episode season.
        /// </summary>
        [JsonProperty]
        public long Season { get; set; }

        /// <summary>
        /// Gets the episode permalink.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public string Permalink { get; internal set; }

        /// <summary>
        /// Gets or sets the episode publish date.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime PublishedAt { get; set; }

        /// <summary>
        /// Gets the episode creation date.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public DateTime CreatedAt { get; internal set; }

        /// <summary>
        /// Gets the episode update date.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public DateTime UpdatedAt { get; internal set; }

        /// <summary>
        /// Gets the episode keywords.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public List<string> Keywords { get; internal set; }

        /// <summary>
        /// Gets the episode chapter marks.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public List<ChapterMarkEpisode> ChapterMarks { get; internal set; }

        /// <summary>
        /// Gets or sets the episode show notes.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ShowNotes { get; set; }

        /// <summary>
        /// Gets or sets the episode authors.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Authors { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the episode content is explicit.
        /// </summary>
        [JsonProperty]
        public bool Explicit { get; set; }

        /// <summary>
        /// Gets or sets the episode cover image.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CoverImage { get; set; }

        /// <summary>
        /// Gets or sets the episode Facebook image.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FacebookImage { get; set; }

        /// <summary>
        /// Gets the episode transcription.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public List<Transcription> Transcription { get; internal set; }

        /// <summary>
        /// Gets the episode contributor IDs.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public List<int> ContributorIds { get; internal set; }

        /// <summary>
        /// Gets or sets the episode publication type.
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public EpisodePublicationType PublicationType { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Episode"/> class.
        /// </summary>
        internal Episode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Episode"/> class.
        /// </summary>
        /// <param name="podcastId">The podcast ID.</param>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        public Episode(long podcastId)
            : this(podcastId, null, null, null, null, null, 1, 1, null, null, false, null, null, EpisodePublicationType.Full)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Episode"/> class.
        /// </summary>
        /// <param name="podcastId">The podcast ID.</param>
        /// <param name="guid">The episode guid.</param>
        /// <param name="title">The episode title.</param>
        /// <param name="subtitle">The episode subtitle.</param>
        /// <param name="description">The episode description.</param>
        /// <param name="externalUrl">The episode external URL.</param>
        /// <param name="number">The episode number.</param>
        /// <param name="season">The episode season.</param>
        /// <param name="showNotes">The episode show notes.</param>
        /// <param name="authors">The episode authors.</param>
        /// <param name="explicit">A value that indicates whether the episode content is explicit.</param>
        /// <param name="coverImage">The episode cover image.</param>
        /// <param name="facebookImage">The episode Facebook image.</param>
        /// <param name="publicationType">The episode publication type.</param>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em>, <em>number</em> or
        /// <em>season</em> is less then 1.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException"><em>publicationType</em>
        /// is invalid enumeration.</exception>
        public Episode(long podcastId,
            string guid,
            string title,
            string subtitle,
            string description,
            string externalUrl,
            long number,
            long season,
            string showNotes,
            string authors,
            bool @explicit,
            string coverImage,
            string facebookImage,
            EpisodePublicationType publicationType)
        {
            Precondition.IsGreater(podcastId, (long)0, nameof(podcastId));
            Precondition.IsGreater(number, (long)0, nameof(number));
            Precondition.IsGreater(season, (long)0, nameof(season));
            Precondition.IsValidEnum(publicationType, nameof(publicationType));

            PodcastId = podcastId;
            Guid = guid;
            Title = title;
            Subtitle = subtitle;
            Description = description;
            ExternalUrl = externalUrl;
            Number = number;
            Season = season;
            ShowNotes = showNotes;
            Authors = authors;
            Explicit = @explicit;
            CoverImage = coverImage;
            FacebookImage = facebookImage;
            PublicationType = publicationType;
        }
        #endregion
    }
}
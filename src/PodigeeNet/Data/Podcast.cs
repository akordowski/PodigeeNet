using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a podcast.
    /// </summary>
    public class Podcast
    {
        #region Public Properties
        /// <summary>
        /// Gets the podcast ID.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets the podcast subdomain.
        /// </summary>
        [JsonProperty]
        public string Subdomain { get; set; }

        /// <summary>
        /// Gets or sets the podcast category.
        /// </summary>
        [JsonProperty("category_id")]
        public PodcastCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the podcast title.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the podcast subtitle.
        /// </summary>
        [JsonProperty]
        public string Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the podcast description.
        /// </summary>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the podcast intro/outro files.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ProductionFile> IntroOutroFiles { get; set; }

        /// <summary>
        /// Gets or sets the podcast quality.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PodcastQuality Quality { get; set; }

        /// <summary>
        /// Gets or sets the podcast language.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PodcastLanguage? Language { get; set; }

        /// <summary>
        /// Gets or sets the podcast authors.
        /// </summary>
        [JsonProperty]
        public string Authors { get; set; }

        /// <summary>
        /// Gets or sets the podcast cover image.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CoverImage { get; set; }

        /// <summary>
        /// Gets or sets the podcast website URL.
        /// </summary>
        [JsonProperty]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Gets or sets the owner email.
        /// </summary>
        [JsonProperty]
        public string OwnerEmail { get; set; }

        /// <summary>
        /// Gets or sets the podcast publish date.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime PublishedAt { get; set; }

        /// <summary>
        /// Gets the podcast creation date.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public DateTime CreatedAt { get; internal set; }

        /// <summary>
        /// Gets the podcast update date.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public DateTime UpdatedAt { get; internal set; }

        /// <summary>
        /// Gets the podcast keywords.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public List<string> Keywords { get; internal set; }

        /// <summary>
        /// Gets the podcast feeds.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public List<Feed> Feeds { get; internal set; }

        /// <summary>
        /// Gets or sets the podcast publication type.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PodcastPublicationType PublicationType { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the podcast content is explicit.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Explicit { get; set; }

        /// <summary>
        /// Gets or sets the Flatter ID.
        /// </summary>
        [JsonProperty]
        public string FlattrId { get; set; }

        /// <summary>
        /// Gets or sets the Twitter name.
        /// </summary>
        [JsonProperty]
        public string Twitter { get; set; }

        /// <summary>
        /// Gets or sets the Facebook name.
        /// </summary>
        [JsonProperty]
        public string Facebook { get; set; }

        /// <summary>
        /// Gets the iTunes ID.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public string ItunesId { get; internal set; }

        /// <summary>
        /// Gets the Spotify URL.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public string SpotifyUrl { get; internal set; }

        /// <summary>
        /// Gets the Deezer URL.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public string DeezerUrl { get; internal set; }

        /// <summary>
        /// Gets the Alexa URL.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public string AlexaUrl { get; internal set; }

        /// <summary>
        /// Gets or sets the podcast copyright text.
        /// </summary>
        [JsonProperty]
        public string CopyrightText { get; set; }

        /// <summary>
        /// Gets or sets the number of feed items.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int FeedItems { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the podcast transcription is enabled.
        /// </summary>
        [JsonProperty]
        public bool TranscriptionsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the podcast transcription language.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public TranscriptionLanguage? TranscriptionLanguage { get; set; }

        /// <summary>
        /// Gets or sets the podcast external site URL.
        /// </summary>
        [JsonProperty]
        public string ExternalSiteUrl { get; set; }

        /// <summary>
        /// Gets or sets the podcast domain.
        /// </summary>
        [JsonProperty]
        public string Domain { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Podcast"/> class.
        /// </summary>
        internal Podcast()
            : this(PodcastCategory.Other, PodcastQuality.High)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Podcast"/> class.
        /// </summary>
        /// <param name="category">The podcast category.</param>
        /// <param name="quality">The podcast quality.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException"><em>category</em>
        /// or <em>quality</em> is invalid enumeration.</exception>
        public Podcast(PodcastCategory category, PodcastQuality quality)
        {
            Precondition.IsValidEnum(category, nameof(category));
            Precondition.IsValidEnum(quality, nameof(quality));

            Category = category;
            Quality = quality;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Podcast"/> class.
        /// </summary>
        /// <param name="category">The podcast category.</param>
        /// <param name="quality">The podcast quality.</param>
        /// <param name="subdomain">The podcast subdomain.</param>
        /// <param name="title">The podcast title.</param>
        /// <param name="subtitle">The podcast subtitle.</param>
        /// <param name="description">The podcast description.</param>
        /// <param name="introOutroFiles">The podcast intro/outro files.</param>
        /// <param name="language">The podcast language.</param>
        /// <param name="authors">The podcast authors.</param>
        /// <param name="coverImage">The podcast cover image.</param>
        /// <param name="websiteUrl">The podcast website URL.</param>
        /// <param name="ownerEmail">The owner email.</param>
        /// <param name="publicationType">The podcast publication type.</param>
        /// <param name="explicit">A value that indicates whether the podcast content is explicit.</param>
        /// <param name="flattrId">The Flatter ID.</param>
        /// <param name="twitter">The Twitter name.</param>
        /// <param name="facebook">The Facebook name.</param>
        /// <param name="copyrightText">The podcast copyright text.</param>
        /// <param name="feedItems">The number of feed items.</param>
        /// <param name="transcriptionsEnabled">A value that indicates whether the podcast transcription is enabled.</param>
        /// <param name="transcriptionLanguage">The podcast transcription language.</param>
        /// <param name="externalSiteUrl">The podcast external site URL.</param>
        /// <param name="domain">The podcast domain.</param>
        /// <exception cref="ArgumentOutOfRangeException"><em>feedItems</em></exception> is less
        /// then 1 or greater then 999999.
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException"><em>category</em>
        /// or <em>quality</em> is invalid enumeration.</exception>
        public Podcast(
            PodcastCategory category,
            PodcastQuality quality,
            string subdomain,
            string title,
            string subtitle,
            string description,
            List<ProductionFile> introOutroFiles,
            PodcastLanguage? language,
            string authors,
            string coverImage,
            string websiteUrl,
            string ownerEmail,
            PodcastPublicationType publicationType,
            bool @explicit,
            string flattrId,
            string twitter,
            string facebook,
            string copyrightText,
            int feedItems,
            bool transcriptionsEnabled,
            TranscriptionLanguage? transcriptionLanguage,
            string externalSiteUrl,
            string domain)
        {
            Precondition.IsValidEnum(category, nameof(category));
            Precondition.IsValidEnum(quality, nameof(quality));
            Precondition.IsBetween(feedItems, 1, 999999, nameof(feedItems));

            Category = category;
            Quality = quality;
            Subdomain = subdomain;
            Title = title;
            Subtitle = subtitle;
            Description = description;
            IntroOutroFiles = introOutroFiles;
            Language = language;
            Authors = authors;
            CoverImage = coverImage;
            WebsiteUrl = websiteUrl;
            OwnerEmail = ownerEmail;
            PublicationType = publicationType;
            Explicit = @explicit;
            FlattrId = flattrId;
            Twitter = twitter;
            Facebook = facebook;
            CopyrightText = copyrightText;
            FeedItems = feedItems;
            TranscriptionsEnabled = transcriptionsEnabled;
            TranscriptionLanguage = transcriptionLanguage;
            ExternalSiteUrl = externalSiteUrl;
            Domain = domain;
        }
        #endregion
    }
}
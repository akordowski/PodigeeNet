using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a contributor.
    /// </summary>
    public class Contributor
    {
        #region Public Properties
        /// <summary>
        /// Gets the contributor ID.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets the podcast ID.
        /// </summary>
        [JsonProperty]
        public long PodcastId { get; internal set; }

        /// <summary>
        /// Gets the user ID.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public long? UserId { get; internal set; }

        /// <summary>
        /// Gets or sets the contributor name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the contributor email address.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the contributor biography.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Biography { get; set; }

        /// <summary>
        /// Gets or sets the contributor avatar URL.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Gets the contributor links.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public List<ContributorLink> Links { get; internal set; }

        /// <summary>
        /// Gets the contributor creation date.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public DateTime CreatedAt { get; internal set; }

        /// <summary>
        /// Gets the contributor update date.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public DateTime UpdatedAt { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Contributor"/> class.
        /// </summary>
        internal Contributor()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Contributor"/> class.
        /// </summary>
        /// <param name="podcastId">The podcast ID.</param>
        /// <param name="name">The contributor name.</param>
        /// <exception cref="ArgumentException"><em>name</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>name</em> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        public Contributor(long podcastId, string name)
            : this(podcastId, name, null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Contributor"/> class.
        /// </summary>
        /// <param name="podcastId">The podcast ID.</param>
        /// <param name="name">The contributor name.</param>
        /// <param name="email">The contributor email address.</param>
        /// <param name="biography">The contributor biography.</param>
        /// <param name="avatarUrl">The contributor avatar URL.</param>
        /// <exception cref="ArgumentException"><em>name</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>name</em> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        public Contributor(long podcastId, string name, string email, string biography, string avatarUrl)
        {
            Precondition.IsGreater(podcastId, (long)0, nameof(podcastId));
            Precondition.IsNotNullOrWhiteSpace(name, nameof(name));

            PodcastId = podcastId;
            Name = name;
            Email = email;
            Biography = biography;
            AvatarUrl = avatarUrl;
        }
        #endregion

        #region Public Override Methods
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
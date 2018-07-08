using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a production.
    /// </summary>
    public class Production
    {
        #region Public Properties
        /// <summary>
        /// Gets the production ID.
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
        /// Gets the production files.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public List<ProductionFile> Files { get; internal set; }

        /// <summary>
        /// Gets the production state.
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(ProductionEnumConverter))]
        public ProductionState State { get; internal set; }

        /// <summary>
        /// Gets the transcription URL.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public string TranscriptionUrl { get; internal set; }

        /// <summary>
        /// Gets the production creation date.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public DateTime CreatedAt { get; internal set; }

        /// <summary>
        /// Gets the production update date.
        /// </summary>
        [JsonIgnoreSerialization]
        [JsonProperty]
        public DateTime UpdatedAt { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Production"/> class.
        /// </summary>
        internal Production()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Production"/> class.
        /// </summary>
        /// <param name="episodeId">The production ID.</param>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        public Production(long episodeId)
        {
            Precondition.IsGreater(episodeId, (long)0, nameof(episodeId));

            EpisodeId = episodeId;
        }
        #endregion
    }
}
using Newtonsoft.Json;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a transcription import.
    /// </summary>
    public class TranscriptionImport
    {
        #region Public Properties
        /// <summary>
        /// Gets the episode ID.
        /// </summary>
        [JsonProperty]
        public long EpisodeId { get; internal set; }

        /// <summary>
        /// Gets the transcription.
        /// </summary>
        [JsonProperty]
        public string Transcription { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TranscriptionImport"/> class.
        /// </summary>
        internal TranscriptionImport()
        {
        }
        #endregion
    }
}
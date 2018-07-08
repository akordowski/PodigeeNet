using Newtonsoft.Json;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents a transcription.
    /// </summary>
    public class Transcription
    {
        #region Public Properties
        /// <summary>
        /// Gets the start of a text block.
        /// </summary>
        [JsonProperty]
        public float Start { get; internal set; }

        /// <summary>
        /// Gets the end of a text block.
        /// </summary>
        [JsonProperty]
        public float End { get; internal set; }

        /// <summary>
        /// Gets the transcribed audio.
        /// </summary>
        [JsonProperty]
        public string Text { get; internal set; }

        /// <summary>
        /// Gets the speaker ID.
        /// </summary>
        [JsonProperty]
        public long SpeakerId { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Transcription"/> class.
        /// </summary>
        internal Transcription()
        {
        }
        #endregion
    }
}
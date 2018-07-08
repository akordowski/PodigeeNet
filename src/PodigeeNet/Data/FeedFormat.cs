using System.Runtime.Serialization;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents the feed format.
    /// </summary>
    public enum FeedFormat
    {
        /// <summary>
        /// MP3
        /// </summary>
        [EnumMember(Value = "mp3")]
        Mp3 = 0,

        /// <summary>
        /// AAC
        /// </summary>
        [EnumMember(Value = "aac")]
        Aac = 1,

        /// <summary>
        /// Opus
        /// </summary>
        [EnumMember(Value = "opus")]
        Opus = 2,

        /// <summary>
        /// Vorbis
        /// </summary>
        [EnumMember(Value = "vorbis")]
        Vorbis = 3
    }
}
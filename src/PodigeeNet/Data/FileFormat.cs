using System.Runtime.Serialization;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents the media clip format.
    /// </summary>
    public enum FileFormat
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
        /// Vorbis
        /// </summary>
        [EnumMember(Value = "vorbis")]
        Vorbis = 2,

        /// <summary>
        /// Opus
        /// </summary>
        [EnumMember(Value = "opus")]
        Opus = 3
    }
}
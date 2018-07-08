using System.Runtime.Serialization;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents the podcast publication type.
    /// </summary>
    public enum PodcastPublicationType
    {
        /// <summary>
        /// Episodic
        /// </summary>
        [EnumMember(Value = "episodic")]
        Episodic = 0,

        /// <summary>
        /// Serial
        /// </summary>
        [EnumMember(Value = "serial")]
        Serial = 1,
    }
}
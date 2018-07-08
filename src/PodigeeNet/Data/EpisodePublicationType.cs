using System.Runtime.Serialization;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents the episode publication type.
    /// </summary>
    public enum EpisodePublicationType
    {
        /// <summary>
        /// Full
        /// </summary>
        [EnumMember(Value = "full")]
        Full = 0,

        /// <summary>
        /// Trailer
        /// </summary>
        [EnumMember(Value = "trailer")]
        Trailer = 1,

        /// <summary>
        /// Bonus
        /// </summary>
        [EnumMember(Value = "bonus")]
        Bonus = 2
    }
}
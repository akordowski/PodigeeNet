using System.Runtime.Serialization;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents the podcast quality.
    /// </summary>
    public enum PodcastQuality
    {
        /// <summary>
        /// Low Quality.
        /// </summary>
        [EnumMember(Value = "low")]
        Low = 0,

        /// <summary>
        /// High Quality.
        /// </summary>
        [EnumMember(Value = "high")]
        High = 1,

        /// <summary>
        /// Super High Quality.
        /// </summary>
        [EnumMember(Value = "super_high")]
        SuperHigh = 2
    }
}
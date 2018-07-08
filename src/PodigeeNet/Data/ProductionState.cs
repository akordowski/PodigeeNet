using System.Runtime.Serialization;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents the production state.
    /// </summary>
    public enum ProductionState
    {
        /// <summary>
        /// Null.
        /// </summary>
        [EnumMember(Value = null)]
        Null = 0,

        /// <summary>
        /// Initial.
        /// </summary>
        [EnumMember(Value = "initial")]
        Initial = 1,

        /// <summary>
        /// Encoding.
        /// </summary>
        [EnumMember(Value = "encoding")]
        Encoding = 2,

        /// <summary>
        /// Encoded.
        /// </summary>
        [EnumMember(Value = "encoded")]
        Encoded = 3,

        /// <summary>
        /// Error.
        /// </summary>
        [EnumMember(Value = "error")]
        Error = 4
    }
}
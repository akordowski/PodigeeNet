using System.Runtime.Serialization;

namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents the transcription format.
    /// </summary>
    public enum TranscriptionFormat
    {
        /// <summary>
        /// docx
        /// </summary>
        [EnumMember(Value = "docx")]
        Docx = 0,

        /// <summary>
        /// srt
        /// </summary>
        [EnumMember(Value = "srt")]
        Srt = 1,

        /// <summary>
        /// vtt
        /// </summary>
        [EnumMember(Value = "vtt")]
        Vtt = 2
    }
}
using NUnit.Framework;
using PodigeeNet.Data;
using System;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class TranscriptionImportTest : TestBase<TranscriptionImport>
    {
        #region Constructor
        public TranscriptionImportTest()
            : base("transcription_import.json")
        {
        }
        #endregion

        #region Tests
        [Test, Order(1)]
        public void Deserialize_Returns_Valid_Result()
        {
            Deserialize();

            Assert.That(Item, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(Item.EpisodeId, Is.EqualTo(123), "EpisodeId");
                Assert.That(Item.Transcription, Is.EqualTo("transcription"), "Transcription");
            });
        }

        [Test, Order(2)]
        public void Serialize_Returns_Valid_Result()
        {
            var json = Serialize();

            Assert.That(String.IsNullOrWhiteSpace(json), Is.False);
            Assert.Multiple(() =>
            {
                Assert.That(json.Contains("\"episode_id\":"), Is.True, "episode_id");
                Assert.That(json.Contains("\"transcription\":"), Is.True, "transcription");
            });
        }

        [Test]
        public void Initialize_Constructor()
        {
            TranscriptionImport transcriptionImport = null;

            Assert.That(() => transcriptionImport = new TranscriptionImport(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(transcriptionImport.EpisodeId, Is.EqualTo(0), "EpisodeId");
                Assert.That(transcriptionImport.Transcription, Is.Null, "Transcription");
            });
        }
        #endregion
    }
}
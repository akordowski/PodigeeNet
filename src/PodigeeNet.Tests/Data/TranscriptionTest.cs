using NUnit.Framework;
using PodigeeNet.Data;
using System;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class TranscriptionTest : TestBase<Transcription>
    {
        #region Constructor
        public TranscriptionTest()
            : base("transcription.json")
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
                Assert.That(Item.Start, Is.EqualTo(1.23f), "Start");
                Assert.That(Item.End, Is.EqualTo(4.56f), "End");
                Assert.That(Item.Text, Is.EqualTo("text"), "Text");
                Assert.That(Item.SpeakerId, Is.EqualTo(123), "SpeakerId");
            });
        }

        [Test, Order(2)]
        public void Serialize_Returns_Valid_Result()
        {
            var json = Serialize();

            Assert.That(String.IsNullOrWhiteSpace(json), Is.False);
            Assert.Multiple(() =>
            {
                Assert.That(json.Contains("\"start\":"), Is.True, "start");
                Assert.That(json.Contains("\"end\":"), Is.True, "end");
                Assert.That(json.Contains("\"text\":"), Is.True, "text");
                Assert.That(json.Contains("\"speaker_id\":"), Is.True, "speaker_id");
            });
        }

        [Test]
        public void Initialize_Constructor()
        {
            Transcription transcription = null;

            Assert.That(() => transcription = new Transcription(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(transcription.Start, Is.EqualTo(0), "Start");
                Assert.That(transcription.End, Is.EqualTo(0), "End");
                Assert.That(transcription.Text, Is.Null, "Text");
                Assert.That(transcription.SpeakerId, Is.EqualTo(0), "SpeakerId");
            });
        }
        #endregion
    }
}
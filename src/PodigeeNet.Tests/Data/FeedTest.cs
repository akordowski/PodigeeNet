using NUnit.Framework;
using PodigeeNet.Data;
using System;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class FeedTest : TestBase<Feed>
    {
        #region Constructor
        public FeedTest()
            : base("feed.json")
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
                Assert.That(Item.Format, Is.EqualTo(FeedFormat.Mp3), "Format");
                Assert.That(Item.Url, Is.EqualTo("url"), "Url");
            });
        }

        [Test, Order(2)]
        public void Serialize_Returns_Valid_Result()
        {
            var json = Serialize();

            Assert.That(String.IsNullOrWhiteSpace(json), Is.False);
            Assert.Multiple(() =>
            {
                Assert.That(json.Contains("\"format\":"), Is.True, "format");
                Assert.That(json.Contains("\"url\":"), Is.True, "url");
            });
        }

        [Test]
        public void Initialize_Constructor()
        {
            Feed feed = null;

            Assert.That(() => feed = new Feed(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(feed.Format, Is.EqualTo(FeedFormat.Mp3), "Format");
                Assert.That(feed.Url, Is.Null, "Url");
            });
        }

        [Test]
        public void Invoke_ToString_Returns_Valid_Result()
        {
            var feed = new Feed
            {
                Url = "Url"
            };

            Assert.That(feed.ToString(), Is.EqualTo(feed.Url));
        }
        #endregion
    }
}
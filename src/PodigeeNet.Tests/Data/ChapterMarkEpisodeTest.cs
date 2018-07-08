using NUnit.Framework;
using PodigeeNet.Data;
using System;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class ChapterMarkEpisodeTest : TestBase<ChapterMarkEpisode>
    {
        #region Constructor
        public ChapterMarkEpisodeTest()
            : base("chapter_mark_episode.json")
        {
        }
        #endregion

        #region Tests
        [Test, Order(1)]
        public void Deserialize_Returns_Valid_Result()
        {
            Deserialize();

            Assert.Multiple(() =>
            {
                Assert.That(Item.Id, Is.EqualTo(123), "Id");
                Assert.That(Item.Title, Is.EqualTo("title"), "Title");
                Assert.That(Item.StartTime, Is.EqualTo(new TimeSpan(12, 34, 56)), "StartTime");
                Assert.That(Item.Url, Is.EqualTo("url"), "Url");
                Assert.That(Item.CreatedAt, Is.EqualTo(new DateTime(2018, 01, 01, 0, 12, 34)), "CreatedAt");
                Assert.That(Item.UpdatedAt, Is.EqualTo(new DateTime(2018, 02, 02, 12, 34, 56)), "UpdatedAt");
            });
        }

        [Test, Order(2)]
        public void Serialize_Returns_Valid_Result()
        {
            var json = Serialize();

            Assert.That(String.IsNullOrWhiteSpace(json), Is.False);
            Assert.Multiple(() =>
            {
                Assert.That(json.Contains("\"id\":"), Is.True, "id");
                Assert.That(json.Contains("\"title\":"), Is.True, "title");
                Assert.That(json.Contains("\"start_time\":"), Is.True, "start_time");
                Assert.That(json.Contains("\"url\":"), Is.True, "url");
                Assert.That(json.Contains("\"created_at\":"), Is.True, "created_at");
                Assert.That(json.Contains("\"updated_at\":"), Is.True, "updated_at");
            });
        }

        [Test]
        public void Initialize_Constructor()
        {
            ChapterMarkEpisode chapterMarkEpisode = null;

            Assert.That(() => chapterMarkEpisode = new ChapterMarkEpisode(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(chapterMarkEpisode.Id, Is.EqualTo(0), "Id");
                Assert.That(chapterMarkEpisode.Title, Is.Null, "Title");
                Assert.That(chapterMarkEpisode.StartTime, Is.EqualTo(TimeSpan.Zero), "StartTime");
                Assert.That(chapterMarkEpisode.Url, Is.Null, "Url");
                Assert.That(chapterMarkEpisode.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                Assert.That(chapterMarkEpisode.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
            });
        }

        [Test]
        public void Invoke_ToString_Returns_Valid_Result()
        {
            var chapterMarkEpisode = new ChapterMarkEpisode
            {
                Title = "Title"
            };

            Assert.That(chapterMarkEpisode.ToString(), Is.EqualTo(chapterMarkEpisode.Title));
        }
        #endregion
    }
}
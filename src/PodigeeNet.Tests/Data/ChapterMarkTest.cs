using NUnit.Framework;
using PodigeeNet.Data;
using System;
using System.Collections;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class ChapterMarkTest : TestBase<ChapterMark>
    {
        #region Constructor
        public ChapterMarkTest()
            : base("chapter_mark.json")
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
                Assert.That(Item.Id, Is.EqualTo(123), "Id");
                Assert.That(Item.EpisodeId, Is.EqualTo(456), "EpisodeId");
                Assert.That(Item.Title, Is.EqualTo("title"), "Title");
                Assert.That(Item.StartTime, Is.EqualTo(new TimeSpan(0, 1, 23)), "StartTime");
                Assert.That(Item.Url, Is.EqualTo("url"), "Url");
                Assert.That(Item.CreatedAt, Is.EqualTo(new DateTime(2018, 1, 1, 0, 12, 34)), "CreatedAt");
                Assert.That(Item.UpdatedAt, Is.EqualTo(new DateTime(2018, 2, 2, 01, 23, 45)), "UpdatedAt");
            });
        }

        [Test, Order(2)]
        public void Serialize_Returns_Valid_Result()
        {
            var json = Serialize();

            Assert.That(String.IsNullOrWhiteSpace(json), Is.False);
            Assert.Multiple(() =>
            {
                Assert.That(json.Contains("\"id\":"), Is.False, "id");
                Assert.That(json.Contains("\"episode_id\":"), Is.True, "episode_id");
                Assert.That(json.Contains("\"title\":"), Is.True, "title");
                Assert.That(json.Contains("\"start_time\":"), Is.True, "start_time");
                Assert.That(json.Contains("\"url\":"), Is.True, "url");
                Assert.That(json.Contains("\"created_at\":"), Is.False, "created_at");
                Assert.That(json.Contains("\"updated_at\":"), Is.False, "updated_at");
            });
        }

        [Test]
        public void Initialize_Constructor_1()
        {
            ChapterMark chapterMark = null;

            Assert.That(() => chapterMark = new ChapterMark(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(chapterMark.Id, Is.EqualTo(0), "Id");
                Assert.That(chapterMark.EpisodeId, Is.EqualTo(0), "EpisodeId");
                Assert.That(chapterMark.Title, Is.Null, "Title");
                Assert.That(chapterMark.StartTime, Is.EqualTo(TimeSpan.Zero), "StartTime");
                Assert.That(chapterMark.Url, Is.Null, "Url");
                Assert.That(chapterMark.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                Assert.That(chapterMark.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
            });
        }

        [Test]
        public void Initialize_Constructor_2(
            [Values(0, 1)] long episodeId,
            [Values(null, "", "  ", "title")] string title,
            [ValueSource("TimeSpanValues")] TimeSpan startTime)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (episodeId < 1)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(episodeId);
            }
            else if (String.IsNullOrWhiteSpace(title))
            {
                expectedException = title == null ? typeof(ArgumentNullException) : typeof(ArgumentException);
                expectedParamName = nameof(title);
            }
            else if (startTime < TimeSpan.Zero)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(startTime);
            }

            if (expectedException == null)
            {
                ChapterMark chapterMark = null;

                Assert.That(() => chapterMark = new ChapterMark(episodeId, title, startTime), Throws.Nothing);
                Assert.Multiple(() =>
                {
                    Assert.That(chapterMark.Id, Is.EqualTo(0), "Id");
                    Assert.That(chapterMark.EpisodeId, Is.EqualTo(episodeId), "EpisodeId");
                    Assert.That(chapterMark.Title, Is.EqualTo(title), "Title");
                    Assert.That(chapterMark.StartTime, Is.EqualTo(startTime), "StartTime");
                    Assert.That(chapterMark.Url, Is.Null, "Url");
                    Assert.That(chapterMark.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                    Assert.That(chapterMark.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
                });
            }
            else
            {
                Assert.That(() => new ChapterMark(episodeId, title, startTime), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }

        [Test]
        public void Initialize_Constructor_3(
            [Values(0, 1)] long episodeId,
            [Values(null, "", "  ", "title")] string title,
            [ValueSource("TimeSpanValues")] TimeSpan startTime,
            [Values("url")] string url)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (episodeId < 1)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(episodeId);
            }
            else if (String.IsNullOrWhiteSpace(title))
            {
                expectedException = title == null ? typeof(ArgumentNullException) : typeof(ArgumentException);
                expectedParamName = nameof(title);
            }
            else if (startTime < TimeSpan.Zero)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(startTime);
            }

            if (expectedException == null)
            {
                ChapterMark chapterMark = null;

                Assert.That(() => chapterMark = new ChapterMark(episodeId, title, startTime, url), Throws.Nothing);
                Assert.Multiple(() =>
                {
                    Assert.That(chapterMark.Id, Is.EqualTo(0), "Id");
                    Assert.That(chapterMark.EpisodeId, Is.EqualTo(episodeId), "EpisodeId");
                    Assert.That(chapterMark.Title, Is.EqualTo(title), "Title");
                    Assert.That(chapterMark.StartTime, Is.EqualTo(startTime), "StartTime");
                    Assert.That(chapterMark.Url, Is.EqualTo(url), "Url");
                    Assert.That(chapterMark.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                    Assert.That(chapterMark.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
                });
            }
            else
            {
                Assert.That(() => new ChapterMark(episodeId, title, startTime, url), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }

        [Test]
        public void Invoke_ToString_Returns_Valid_Result()
        {
            var chapterMark = new ChapterMark
            {
                Title = "Title"
            };

            Assert.That(chapterMark.ToString(), Is.EqualTo(chapterMark.Title));
        }
        #endregion

        #region Value Source
        public static IEnumerable TimeSpanValues()
        {
            yield return TimeSpan.MinValue;
            yield return TimeSpan.Zero;
        }
        #endregion
    }
}
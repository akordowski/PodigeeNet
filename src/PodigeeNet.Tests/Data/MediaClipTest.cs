using NUnit.Framework;
using PodigeeNet.Data;
using System;
using System.ComponentModel;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class MediaClipTest : TestBase<MediaClip>
    {
        #region Constructor
        public MediaClipTest()
            : base("media_clip.json")
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
                Assert.That(Item.EpisodeId, Is.EqualTo(456), "EpisodeId");
                Assert.That(Item.FileFormat, Is.EqualTo(FileFormat.Mp3), "FileFormat");
                Assert.That(Item.Url, Is.EqualTo("url"), "Url");
                Assert.That(Item.CreatedAt, Is.EqualTo(new DateTime(2018, 1, 1, 0, 12, 34)), "CreatedAt");
                Assert.That(Item.Size, Is.EqualTo(654), "Size");
                Assert.That(Item.Duration, Is.EqualTo(321), "Duration");
            });
        }

        [Test, Order(2)]
        public void Serialize_Returns_Valid_Result()
        {
            var json = Serialize();

            Assert.Multiple(() =>
            {
                Assert.That(String.IsNullOrWhiteSpace(json), Is.False);
                Assert.That(json.Contains("\"id\":"), Is.False, "Id");
                Assert.That(json.Contains("\"episode_id\":"), Is.True, "EpisodeId");
                Assert.That(json.Contains("\"file_format\":"), Is.True, "FileFormat");
                Assert.That(json.Contains("\"url\":"), Is.True, "Url");
                Assert.That(json.Contains("\"created_at\":"), Is.False, "CreatedAt");
                Assert.That(json.Contains("\"size\":"), Is.True, "Size");
                Assert.That(json.Contains("\"duration\":"), Is.True, "Duration");
            });
        }

        [Test]
        public void Initialize_Constructor_1()
        {
            MediaClip mediaClip = null;

            Assert.That(() => mediaClip = new MediaClip(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(mediaClip.Id, Is.EqualTo(0), "Id");
                Assert.That(mediaClip.EpisodeId, Is.EqualTo(0), "EpisodeId");
                Assert.That(mediaClip.FileFormat, Is.EqualTo(FileFormat.Mp3), "FileFormat");
                Assert.That(mediaClip.Url, Is.Null, "Url");
                Assert.That(mediaClip.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                Assert.That(mediaClip.Size, Is.Null, "Size");
                Assert.That(mediaClip.Duration, Is.Null, "Duration");
            });
        }

        [Test]
        public void Initialize_Constructor_2(
            [Values(0, 1)] long episodeId,
            [Values(FileFormat.Mp3, (FileFormat)10)] FileFormat fileFormat,
            [Values(null, "", "  ", "url")] string url)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (episodeId < 1)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(episodeId);
            }
            else if (fileFormat == (FileFormat)10)
            {
                expectedException = typeof(InvalidEnumArgumentException);
                expectedParamName = nameof(fileFormat);
            }
            else if (String.IsNullOrWhiteSpace(url))
            {
                expectedException = url == null ? typeof(ArgumentNullException) : typeof(ArgumentException);
                expectedParamName = nameof(url);
            }

            if (expectedException == null)
            {
                MediaClip mediaClip = null;

                Assert.That(() => mediaClip = new MediaClip(episodeId, fileFormat, url), Throws.Nothing);
                Assert.Multiple(() =>
                {
                    Assert.That(mediaClip.Id, Is.EqualTo(0), "Id");
                    Assert.That(mediaClip.EpisodeId, Is.EqualTo(episodeId), "EpisodeId");
                    Assert.That(mediaClip.FileFormat, Is.EqualTo(fileFormat), "FileFormat");
                    Assert.That(mediaClip.Url, Is.EqualTo(url), "Url");
                    Assert.That(mediaClip.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                    Assert.That(mediaClip.Size, Is.Null, "Size");
                    Assert.That(mediaClip.Duration, Is.Null, "Duration");
                });
            }
            else
            {
                Assert.That(() => new MediaClip(episodeId, fileFormat, url), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }

        [Test]
        public void Invoke_ToString_Returns_Valid_Result()
        {
            var mediaClip = new MediaClip
            {
                Url = "Url"
            };

            Assert.That(mediaClip.ToString(), Is.EqualTo(mediaClip.Url));
        }
        #endregion
    }
}
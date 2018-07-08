using NUnit.Framework;
using PodigeeNet.Data;
using System;
using System.ComponentModel;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class EpisodeTest : TestBase<Episode>
    {
        #region Constructor
        public EpisodeTest()
            : base("episode.json")
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
                Assert.That(Item.Guid, Is.EqualTo("guid"), "Guid");
                Assert.That(Item.PodcastId, Is.EqualTo(456), "PodcastId");
                Assert.That(Item.ProductionId, Is.EqualTo(789), "ProductionId");
                Assert.That(Item.Title, Is.EqualTo("title"), "Title");
                Assert.That(Item.Subtitle, Is.EqualTo("subtitle"), "Subtitle");
                Assert.That(Item.Description, Is.EqualTo("description"), "Description");
                Assert.That(Item.Slug, Is.EqualTo("slug"), "Slug");
                Assert.That(Item.ExternalUrl, Is.EqualTo("external_url"), "ExternalUrl");
                Assert.That(Item.Number, Is.EqualTo(1), "Number");
                Assert.That(Item.Season, Is.EqualTo(2), "Season");
                Assert.That(Item.Permalink, Is.EqualTo("permalink"), "Permalink");
                Assert.That(Item.PublishedAt, Is.EqualTo(new DateTime(2018, 3, 3, 12, 34, 56)), "PublishedAt");
                Assert.That(Item.CreatedAt, Is.EqualTo(new DateTime(2018, 1, 1, 0, 12, 34)), "CreatedAt");
                Assert.That(Item.UpdatedAt, Is.EqualTo(new DateTime(2018, 2, 2, 01, 23, 45)), "UpdatedAt");
                Assert.That(Item.Keywords.Count, Is.EqualTo(0), "Keywords");
                Assert.That(Item.ChapterMarks.Count, Is.EqualTo(0), "ChapterMarks");
                Assert.That(Item.ShowNotes, Is.EqualTo("show_notes"), "ShowNotes");
                Assert.That(Item.Authors, Is.EqualTo("authors"), "Authors");
                Assert.That(Item.Explicit, Is.False, "Explicit");
                Assert.That(Item.CoverImage, Is.EqualTo("cover_image"), "CoverImage");
                Assert.That(Item.FacebookImage, Is.EqualTo("facebook_image"), "FacebookImage");
                Assert.That(Item.Transcription.Count, Is.EqualTo(0), "Transcription");
                Assert.That(Item.ContributorIds.Count, Is.EqualTo(0), "ContributorIds");
                Assert.That(Item.PublicationType, Is.EqualTo(EpisodePublicationType.Full), "PublicationType");
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
                Assert.That(json.Contains("\"guid\":"), Is.True, "Guid");
                Assert.That(json.Contains("\"podcast_id\":"), Is.True, "PodcastId");
                Assert.That(json.Contains("\"production_id\":"), Is.False, "ProductionId");
                Assert.That(json.Contains("\"title\":"), Is.True, "Title");
                Assert.That(json.Contains("\"subtitle\":"), Is.True, "Subtitle");
                Assert.That(json.Contains("\"description\":"), Is.True, "Description");
                Assert.That(json.Contains("\"slug\":"), Is.False, "Slug");
                Assert.That(json.Contains("\"external_url\":"), Is.True, "ExternalUrl");
                Assert.That(json.Contains("\"number\":"), Is.True, "Number");
                Assert.That(json.Contains("\"season\":"), Is.True, "Season");
                Assert.That(json.Contains("\"permalink\":"), Is.False, "Permalink");
                Assert.That(json.Contains("\"published_at\":"), Is.True, "PublishedAt");
                Assert.That(json.Contains("\"created_at\":"), Is.False, "CreatedAt");
                Assert.That(json.Contains("\"updated_at\":"), Is.False, "UpdatedAt");
                Assert.That(json.Contains("\"keywords\":"), Is.False, "Keywords");
                Assert.That(json.Contains("\"chapter_marks\":"), Is.False, "ChapterMarks");
                Assert.That(json.Contains("\"show_notes\":"), Is.True, "ShowNotes");
                Assert.That(json.Contains("\"authors\":"), Is.True, "Authors");
                Assert.That(json.Contains("\"explicit\":"), Is.True, "Explicit");
                Assert.That(json.Contains("\"cover_image\":"), Is.True, "CoverImage");
                Assert.That(json.Contains("\"facebook_image\":"), Is.True, "FacebookImage");
                Assert.That(json.Contains("\"transcription\":"), Is.False, "Transcription");
                Assert.That(json.Contains("\"contributor_ids\":"), Is.False, "ContributorIds");
                Assert.That(json.Contains("\"publication_type\":"), Is.True, "PublicationType");
            });
        }

        [Test]
        public void Initialize_Constructor_1()
        {
            Episode episode = null;

            Assert.That(() => episode = new Episode(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(episode.Id, Is.EqualTo(0), "Id");
                Assert.That(episode.Guid, Is.Null, "Guid");
                Assert.That(episode.PodcastId, Is.EqualTo(0), "PodcastId");
                Assert.That(episode.ProductionId, Is.Null, "ProductionId");
                Assert.That(episode.Title, Is.Null, "Title");
                Assert.That(episode.Subtitle, Is.Null, "Subtitle");
                Assert.That(episode.Description, Is.Null, "Description");
                Assert.That(episode.Slug, Is.Null, "Slug");
                Assert.That(episode.ExternalUrl, Is.Null, "ExternalUrl");
                Assert.That(episode.Number, Is.EqualTo(0), "Number");
                Assert.That(episode.Season, Is.EqualTo(0), "Season");
                Assert.That(episode.Permalink, Is.Null, "Permalink");
                Assert.That(episode.PublishedAt, Is.EqualTo(DateTime.MinValue), "PublishedAt");
                Assert.That(episode.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                Assert.That(episode.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
                Assert.That(episode.Keywords, Is.Null, "Keywords");
                Assert.That(episode.ChapterMarks, Is.Null, "ChapterMarks");
                Assert.That(episode.ShowNotes, Is.Null, "ShowNotes");
                Assert.That(episode.Authors, Is.Null, "Authors");
                Assert.That(episode.Explicit, Is.False, "Explicit");
                Assert.That(episode.CoverImage, Is.Null, "CoverImage");
                Assert.That(episode.FacebookImage, Is.Null, "FacebookImage");
                Assert.That(episode.Transcription, Is.Null, "Transcription");
                Assert.That(episode.ContributorIds, Is.Null, "ContributorIds");
                Assert.That(episode.PublicationType, Is.EqualTo(EpisodePublicationType.Full), "PublicationType");
            });
        }

        [Test]
        public void Initialize_Constructor_2(
            [Values(0, 1)] long podcastId)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (podcastId < 1)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(podcastId);
            }

            if (expectedException == null)
            {
                Episode episode = null;

                Assert.That(() => episode = new Episode(podcastId), Throws.Nothing);
                Assert.Multiple(() =>
                {
                    Assert.That(episode.Id, Is.EqualTo(0), "Id");
                    Assert.That(episode.Guid, Is.Null, "Guid");
                    Assert.That(episode.PodcastId, Is.EqualTo(podcastId), "PodcastId");
                    Assert.That(episode.ProductionId, Is.Null, "ProductionId");
                    Assert.That(episode.Title, Is.Null, "Title");
                    Assert.That(episode.Subtitle, Is.Null, "Subtitle");
                    Assert.That(episode.Description, Is.Null, "Description");
                    Assert.That(episode.Slug, Is.Null, "Slug");
                    Assert.That(episode.ExternalUrl, Is.Null, "ExternalUrl");
                    Assert.That(episode.Number, Is.EqualTo(1), "Number");
                    Assert.That(episode.Season, Is.EqualTo(1), "Season");
                    Assert.That(episode.Permalink, Is.Null, "Permalink");
                    Assert.That(episode.PublishedAt, Is.EqualTo(DateTime.MinValue), "PublishedAt");
                    Assert.That(episode.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                    Assert.That(episode.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
                    Assert.That(episode.Keywords, Is.Null, "Keywords");
                    Assert.That(episode.ChapterMarks, Is.Null, "ChapterMarks");
                    Assert.That(episode.ShowNotes, Is.Null, "ShowNotes");
                    Assert.That(episode.Authors, Is.Null, "Authors");
                    Assert.That(episode.Explicit, Is.False, "Explicit");
                    Assert.That(episode.CoverImage, Is.Null, "CoverImage");
                    Assert.That(episode.FacebookImage, Is.Null, "FacebookImage");
                    Assert.That(episode.Transcription, Is.Null, "Transcription");
                    Assert.That(episode.ContributorIds, Is.Null, "ContributorIds");
                    Assert.That(episode.PublicationType, Is.EqualTo(EpisodePublicationType.Full), "PublicationType");
                });
            }
            else
            {
                Assert.That(() => new Episode(podcastId), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }

        [Test]
        public void Initialize_Constructor_3(
            [Values(0, 1)] long podcastId,
            [Values("guid")] string guid,
            [Values("title")] string title,
            [Values("subtitle")] string subtitle,
            [Values("description")] string description,
            [Values("externalUrl")] string externalUrl,
            [Values(0, 1)] long number,
            [Values(0, 1)] long season,
            [Values("showNotes")] string showNotes,
            [Values("authors")] string authors,
            [Values(true)] bool @explicit,
            [Values("coverImage")] string coverImage,
            [Values("facebookImage")] string facebookImage,
            [Values(EpisodePublicationType.Full, (EpisodePublicationType)10)]
            EpisodePublicationType publicationType)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (podcastId < 1)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(podcastId);
            }
            else if (number < 1)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(number);
            }
            else if (season < 1)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(season);
            }
            else if (publicationType == (EpisodePublicationType)10)
            {
                expectedException = typeof(InvalidEnumArgumentException);
                expectedParamName = nameof(publicationType);
            }

            if (expectedException == null)
            {
                Episode episode = null;

                Assert.That(() => episode = new Episode(
                    podcastId,
                    guid,
                    title,
                    subtitle,
                    description,
                    externalUrl,
                    number,
                    season,
                    showNotes,
                    authors,
                    @explicit,
                    coverImage,
                    facebookImage,
                    publicationType), Throws.Nothing);

                Assert.Multiple(() =>
                {
                    Assert.That(episode.Id, Is.EqualTo(0), "Id");
                    Assert.That(episode.Guid, Is.EqualTo(guid), "Guid");
                    Assert.That(episode.PodcastId, Is.EqualTo(podcastId), "PodcastId");
                    Assert.That(episode.ProductionId, Is.Null, "ProductionId");
                    Assert.That(episode.Title, Is.EqualTo(title), "Title");
                    Assert.That(episode.Subtitle, Is.EqualTo(subtitle), "Subtitle");
                    Assert.That(episode.Description, Is.EqualTo(description), "Description");
                    Assert.That(episode.Slug, Is.Null, "Slug");
                    Assert.That(episode.ExternalUrl, Is.EqualTo(externalUrl), "ExternalUrl");
                    Assert.That(episode.Number, Is.EqualTo(number), "Number");
                    Assert.That(episode.Season, Is.EqualTo(season), "Season");
                    Assert.That(episode.Permalink, Is.Null, "Permalink");
                    Assert.That(episode.PublishedAt, Is.EqualTo(DateTime.MinValue), "PublishedAt");
                    Assert.That(episode.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                    Assert.That(episode.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
                    Assert.That(episode.Keywords, Is.Null, "Keywords");
                    Assert.That(episode.ChapterMarks, Is.Null, "ChapterMarks");
                    Assert.That(episode.ShowNotes, Is.EqualTo(showNotes), "ShowNotes");
                    Assert.That(episode.Authors, Is.EqualTo(authors), "Authors");
                    Assert.That(episode.Explicit, Is.EqualTo(@explicit), "Explicit");
                    Assert.That(episode.CoverImage, Is.EqualTo(coverImage), "CoverImage");
                    Assert.That(episode.FacebookImage, Is.EqualTo(facebookImage), "FacebookImage");
                    Assert.That(episode.Transcription, Is.Null, "Transcription");
                    Assert.That(episode.ContributorIds, Is.Null, "ContributorIds");
                    Assert.That(episode.PublicationType, Is.EqualTo(publicationType), "PublicationType");
                });
            }
            else
            {
                Assert.That(() => new Episode(podcastId,
                    guid,
                    title,
                    subtitle,
                    description,
                    externalUrl,
                    number,
                    season,
                    showNotes,
                    authors,
                    @explicit,
                    coverImage,
                    facebookImage,
                    publicationType), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }
        #endregion
    }
}
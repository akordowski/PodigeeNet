using NUnit.Framework;
using PodigeeNet.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class PodcastTest : TestBase<Podcast>
    {
        #region Constructor
        public PodcastTest()
            : base("podcast.json")
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
                Assert.That(Item.Subdomain, Is.EqualTo("subdomain"), "Subdomain");
                Assert.That(Item.Category, Is.EqualTo(PodcastCategory.Other), "Category");
                Assert.That(Item.Title, Is.EqualTo("title"), "Title");
                Assert.That(Item.Subtitle, Is.EqualTo("subtitle"), "Subtitle");
                Assert.That(Item.Description, Is.EqualTo("description"), "Description");
                Assert.That(Item.IntroOutroFiles.Count, Is.EqualTo(0), "IntroOutroFiles");
                Assert.That(Item.Quality, Is.EqualTo(PodcastQuality.High), "Quality");
                Assert.That(Item.Language, Is.EqualTo(PodcastLanguage.English), "Language");
                Assert.That(Item.Authors, Is.EqualTo("authors"), "Authors");
                Assert.That(Item.CoverImage, Is.EqualTo("cover_image"), "CoverImage");
                Assert.That(Item.WebsiteUrl, Is.EqualTo("website_url"), "WebsiteUrl");
                Assert.That(Item.OwnerEmail, Is.EqualTo("owner_email"), "OwnerEmail");
                Assert.That(Item.PublishedAt, Is.EqualTo(new DateTime(2018, 3, 3, 12, 34, 56)), "PublishedAt");
                Assert.That(Item.CreatedAt, Is.EqualTo(new DateTime(2018, 1, 1, 0, 12, 34)), "CreatedAt");
                Assert.That(Item.UpdatedAt, Is.EqualTo(new DateTime(2018, 2, 2, 01, 23, 45)), "UpdatedAt");
                Assert.That(Item.Keywords.Count, Is.EqualTo(0), "Keywords");
                Assert.That(Item.Feeds.Count, Is.EqualTo(4), "Feeds");
                Assert.That(Item.PublicationType, Is.EqualTo(PodcastPublicationType.Episodic), "PublicationType");
                Assert.That(Item.Explicit, Is.False, "Explicit");
                Assert.That(Item.FlattrId, Is.EqualTo("flattr_id"), "FlattrId");
                Assert.That(Item.Twitter, Is.EqualTo("twitter"), "Twitter");
                Assert.That(Item.Facebook, Is.EqualTo("facebook"), "Facebook");
                Assert.That(Item.ItunesId, Is.EqualTo("itunes_id"), "ItunesId");
                Assert.That(Item.SpotifyUrl, Is.EqualTo("spotify_url"), "SpotifyUrl");
                Assert.That(Item.DeezerUrl, Is.EqualTo("deezer_url"), "DeezerUrl");
                Assert.That(Item.AlexaUrl, Is.EqualTo("alexa_url"), "AlexaUrl");
                Assert.That(Item.CopyrightText, Is.EqualTo("copyright_text"), "CopyrightText");
                Assert.That(Item.FeedItems, Is.EqualTo(999999), "FeedItems");
                Assert.That(Item.TranscriptionsEnabled, Is.False, "TranscriptionsEnabled");
                Assert.That(Item.TranscriptionLanguage, Is.EqualTo(TranscriptionLanguage.en_US), "TranscriptionLanguage");
                Assert.That(Item.ExternalSiteUrl, Is.EqualTo("external_site_url"), "ExternalSiteUrl");
                Assert.That(Item.Domain, Is.EqualTo("domain"), "Domain");
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
                Assert.That(json.Contains("\"subdomain\":"), Is.True, "Subdomain");
                Assert.That(json.Contains("\"category_id\":"), Is.True, "Category");
                Assert.That(json.Contains("\"title\":"), Is.True, "Title");
                Assert.That(json.Contains("\"subtitle\":"), Is.True, "Subtitle");
                Assert.That(json.Contains("\"description\":"), Is.True, "Description");
                Assert.That(json.Contains("\"intro_outro_files\":"), Is.True, "IntroOutroFiles");
                Assert.That(json.Contains("\"quality\":"), Is.True, "Quality");
                Assert.That(json.Contains("\"language\":"), Is.True, "Language");
                Assert.That(json.Contains("\"authors\":"), Is.True, "Authors");
                Assert.That(json.Contains("\"cover_image\":"), Is.True, "CoverImage");
                Assert.That(json.Contains("\"website_url\":"), Is.True, "WebsiteUrl");
                Assert.That(json.Contains("\"owner_email\":"), Is.True, "OwnerEmail");
                Assert.That(json.Contains("\"published_at\":"), Is.True, "PublishedAt");
                Assert.That(json.Contains("\"created_at\":"), Is.False, "CreatedAt");
                Assert.That(json.Contains("\"updated_at\":"), Is.False, "UpdatedAt");
                Assert.That(json.Contains("\"keywords\":"), Is.False, "Keywords");
                Assert.That(json.Contains("\"feeds\":"), Is.False, "Feeds");
                Assert.That(json.Contains("\"publication_type\":"), Is.True, "PublicationType");
                Assert.That(json.Contains("\"explicit\":"), Is.True, "Explicit");
                Assert.That(json.Contains("\"flattr_id\":"), Is.True, "FlattrId");
                Assert.That(json.Contains("\"twitter\":"), Is.True, "Twitter");
                Assert.That(json.Contains("\"facebook\":"), Is.True, "Facebook");
                Assert.That(json.Contains("\"itunes_id\":"), Is.False, "ItunesId");
                Assert.That(json.Contains("\"spotify_url\":"), Is.False, "SpotifyUrl");
                Assert.That(json.Contains("\"deezer_url\":"), Is.False, "DeezerUrl");
                Assert.That(json.Contains("\"alexa_url\":"), Is.False, "AlexaUrl");
                Assert.That(json.Contains("\"copyright_text\":"), Is.True, "CopyrightText");
                Assert.That(json.Contains("\"feed_items\":"), Is.True, "FeedItems");
                Assert.That(json.Contains("\"transcriptions_enabled\":"), Is.True, "TranscriptionsEnabled");
                Assert.That(json.Contains("\"transcription_language\":"), Is.True, "TranscriptionLanguage");
                Assert.That(json.Contains("\"external_site_url\":"), Is.True, "ExternalSiteUrl");
                Assert.That(json.Contains("\"domain\":"), Is.True, "Domain");
            });
        }

        [Test]
        public void Initialize_Constructor_1()
        {
            Podcast podcast = null;

            Assert.That(() => podcast = new Podcast(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(podcast.Id, Is.EqualTo(0), "Id");
                Assert.That(podcast.Subdomain, Is.Null, "Subdomain");
                Assert.That(podcast.Category, Is.EqualTo(PodcastCategory.Other), "Category");
                Assert.That(podcast.Title, Is.Null, "Title");
                Assert.That(podcast.Subtitle, Is.Null, "Subtitle");
                Assert.That(podcast.Description, Is.Null, "Description");
                Assert.That(podcast.IntroOutroFiles, Is.Null, "IntroOutroFiles");
                Assert.That(podcast.Quality, Is.EqualTo(PodcastQuality.High), "Quality");
                Assert.That(podcast.Language, Is.Null, "Language");
                Assert.That(podcast.Authors, Is.Null, "Authors");
                Assert.That(podcast.CoverImage, Is.Null, "CoverImage");
                Assert.That(podcast.WebsiteUrl, Is.Null, "WebsiteUrl");
                Assert.That(podcast.OwnerEmail, Is.Null, "OwnerEmail");
                Assert.That(podcast.PublishedAt, Is.EqualTo(DateTime.MinValue), "PublishedAt");
                Assert.That(podcast.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                Assert.That(podcast.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
                Assert.That(podcast.Keywords, Is.Null, "Keywords");
                Assert.That(podcast.Feeds, Is.Null, "Feeds");
                Assert.That(podcast.PublicationType, Is.EqualTo(PodcastPublicationType.Episodic), "PublicationType");
                Assert.That(podcast.Explicit, Is.False, "Explicit");
                Assert.That(podcast.FlattrId, Is.Null, "FlattrId");
                Assert.That(podcast.Twitter, Is.Null, "Twitter");
                Assert.That(podcast.Facebook, Is.Null, "Facebook");
                Assert.That(podcast.ItunesId, Is.Null, "ItunesId");
                Assert.That(podcast.SpotifyUrl, Is.Null, "SpotifyUrl");
                Assert.That(podcast.DeezerUrl, Is.Null, "DeezerUrl");
                Assert.That(podcast.AlexaUrl, Is.Null, "AlexaUrl");
                Assert.That(podcast.CopyrightText, Is.Null, "CopyrightText");
                Assert.That(podcast.FeedItems, Is.EqualTo(0), "FeedItems");
                Assert.That(podcast.TranscriptionsEnabled, Is.False, "TranscriptionsEnabled");
                Assert.That(podcast.TranscriptionLanguage, Is.Null, "TranscriptionLanguage");
                Assert.That(podcast.ExternalSiteUrl, Is.Null, "ExternalSiteUrl");
                Assert.That(podcast.Domain, Is.Null, "Domain");
            });
        }

        [Test]
        public void Initialize_Constructor_2(
            [Values(PodcastCategory.Podcasting, (PodcastCategory)100)] PodcastCategory category,
            [Values(PodcastQuality.SuperHigh, (PodcastQuality)100)] PodcastQuality quality)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (category == (PodcastCategory)100)
            {
                expectedException = typeof(InvalidEnumArgumentException);
                expectedParamName = nameof(category);
            }
            else if (quality == (PodcastQuality)100)
            {
                expectedException = typeof(InvalidEnumArgumentException);
                expectedParamName = nameof(quality);
            }

            if (expectedException == null)
            {
                Podcast podcast = null;

                Assert.That(() => podcast = new Podcast(category, quality), Throws.Nothing);
                Assert.Multiple(() =>
                {
                    Assert.That(podcast.Id, Is.EqualTo(0), "Id");
                    Assert.That(podcast.Subdomain, Is.Null, "Subdomain");
                    Assert.That(podcast.Category, Is.EqualTo(category), "Category");
                    Assert.That(podcast.Title, Is.Null, "Title");
                    Assert.That(podcast.Subtitle, Is.Null, "Subtitle");
                    Assert.That(podcast.Description, Is.Null, "Description");
                    Assert.That(podcast.IntroOutroFiles, Is.Null, "IntroOutroFiles");
                    Assert.That(podcast.Quality, Is.EqualTo(quality), "Quality");
                    Assert.That(podcast.Language, Is.Null, "Language");
                    Assert.That(podcast.Authors, Is.Null, "Authors");
                    Assert.That(podcast.CoverImage, Is.Null, "CoverImage");
                    Assert.That(podcast.WebsiteUrl, Is.Null, "WebsiteUrl");
                    Assert.That(podcast.OwnerEmail, Is.Null, "OwnerEmail");
                    Assert.That(podcast.PublishedAt, Is.EqualTo(DateTime.MinValue), "PublishedAt");
                    Assert.That(podcast.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                    Assert.That(podcast.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
                    Assert.That(podcast.Keywords, Is.Null, "Keywords");
                    Assert.That(podcast.Feeds, Is.Null, "Feeds");
                    Assert.That(podcast.PublicationType, Is.EqualTo(PodcastPublicationType.Episodic), "PublicationType");
                    Assert.That(podcast.Explicit, Is.False, "Explicit");
                    Assert.That(podcast.FlattrId, Is.Null, "FlattrId");
                    Assert.That(podcast.Twitter, Is.Null, "Twitter");
                    Assert.That(podcast.Facebook, Is.Null, "Facebook");
                    Assert.That(podcast.ItunesId, Is.Null, "ItunesId");
                    Assert.That(podcast.SpotifyUrl, Is.Null, "SpotifyUrl");
                    Assert.That(podcast.DeezerUrl, Is.Null, "DeezerUrl");
                    Assert.That(podcast.AlexaUrl, Is.Null, "AlexaUrl");
                    Assert.That(podcast.CopyrightText, Is.Null, "CopyrightText");
                    Assert.That(podcast.FeedItems, Is.EqualTo(0), "FeedItems");
                    Assert.That(podcast.TranscriptionsEnabled, Is.False, "TranscriptionsEnabled");
                    Assert.That(podcast.TranscriptionLanguage, Is.Null, "TranscriptionLanguage");
                    Assert.That(podcast.ExternalSiteUrl, Is.Null, "ExternalSiteUrl");
                    Assert.That(podcast.Domain, Is.Null, "Domain");
                });
            }
            else
            {
                Assert.That(() => new Podcast(category, quality), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }

        [Test]
        public void Initialize_Constructor_3(
            [Values(PodcastCategory.Podcasting, (PodcastCategory)100)] PodcastCategory category,
            [Values(PodcastQuality.SuperHigh, (PodcastQuality)100)] PodcastQuality quality,
            [Values("subdomain")] string subdomain,
            [Values("title")] string title,
            [Values("subtitle")] string subtitle,
            [Values("description")] string description,
            [Values(null)] List<ProductionFile> introOutroFiles,
            [Values(null)] PodcastLanguage? language,
            [Values("authors")] string authors,
            [Values("coverImage")] string coverImage,
            [Values("websiteUrl")] string websiteUrl,
            [Values("ownerEmail")] string ownerEmail,
            [Values(PodcastPublicationType.Serial)] PodcastPublicationType publicationType,
            [Values(false)] bool @explicit,
            [Values("flattrId")] string flattrId,
            [Values("twitter")] string twitter,
            [Values("facebook")] string facebook,
            [Values("copyrightText")] string copyrightText,
            [Values(0, 10, 1000000)] int feedItems,
            [Values(false)] bool transcriptionsEnabled,
            [Values(null)] TranscriptionLanguage? transcriptionLanguage,
            [Values("externalSiteUrl")] string externalSiteUrl,
            [Values("domain")] string domain)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (category == (PodcastCategory)100)
            {
                expectedException = typeof(InvalidEnumArgumentException);
                expectedParamName = nameof(category);
            }
            else if (quality == (PodcastQuality)100)
            {
                expectedException = typeof(InvalidEnumArgumentException);
                expectedParamName = nameof(quality);
            }
            else if (feedItems == 0 || feedItems == 1000000)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(feedItems);
            }

            if (expectedException == null)
            {
                Podcast podcast = null;

                Assert.That(() => podcast = new Podcast(
                    category,
                    quality,
                    subdomain,
                    title,
                    subtitle,
                    description,
                    introOutroFiles,
                    language,
                    authors,
                    coverImage,
                    websiteUrl,
                    ownerEmail,
                    publicationType,
                    @explicit,
                    flattrId,
                    twitter,
                    facebook,
                    copyrightText,
                    feedItems,
                    transcriptionsEnabled,
                    transcriptionLanguage,
                    externalSiteUrl,
                    domain), Throws.Nothing);

                Assert.Multiple(() =>
                {
                    Assert.That(podcast.Id, Is.EqualTo(0), "Id");
                    Assert.That(podcast.Subdomain, Is.EqualTo(subdomain), "Subdomain");
                    Assert.That(podcast.Category, Is.EqualTo(category), "Category");
                    Assert.That(podcast.Title, Is.EqualTo(title), "Title");
                    Assert.That(podcast.Subtitle, Is.EqualTo(subtitle), "Subtitle");
                    Assert.That(podcast.Description, Is.EqualTo(description), "Description");
                    Assert.That(podcast.IntroOutroFiles, Is.EqualTo(introOutroFiles), "IntroOutroFiles");
                    Assert.That(podcast.Quality, Is.EqualTo(quality), "Quality");
                    Assert.That(podcast.Language, Is.EqualTo(language), "Language");
                    Assert.That(podcast.Authors, Is.EqualTo(authors), "Authors");
                    Assert.That(podcast.CoverImage, Is.EqualTo(coverImage), "CoverImage");
                    Assert.That(podcast.WebsiteUrl, Is.EqualTo(websiteUrl), "WebsiteUrl");
                    Assert.That(podcast.OwnerEmail, Is.EqualTo(ownerEmail), "OwnerEmail");
                    Assert.That(podcast.PublishedAt, Is.EqualTo(DateTime.MinValue), "PublishedAt");
                    Assert.That(podcast.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                    Assert.That(podcast.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
                    Assert.That(podcast.Keywords, Is.Null, "Keywords");
                    Assert.That(podcast.Feeds, Is.Null, "Feeds");
                    Assert.That(podcast.PublicationType, Is.EqualTo(publicationType), "PublicationType");
                    Assert.That(podcast.Explicit, Is.EqualTo(@explicit), "Explicit");
                    Assert.That(podcast.FlattrId, Is.EqualTo(flattrId), "FlattrId");
                    Assert.That(podcast.Twitter, Is.EqualTo(twitter), "Twitter");
                    Assert.That(podcast.Facebook, Is.EqualTo(facebook), "Facebook");
                    Assert.That(podcast.ItunesId, Is.Null, "ItunesId");
                    Assert.That(podcast.SpotifyUrl, Is.Null, "SpotifyUrl");
                    Assert.That(podcast.DeezerUrl, Is.Null, "DeezerUrl");
                    Assert.That(podcast.AlexaUrl, Is.Null, "AlexaUrl");
                    Assert.That(podcast.CopyrightText, Is.EqualTo(copyrightText), "CopyrightText");
                    Assert.That(podcast.FeedItems, Is.EqualTo(feedItems), "FeedItems");
                    Assert.That(podcast.TranscriptionsEnabled, Is.EqualTo(transcriptionsEnabled), "TranscriptionsEnabled");
                    Assert.That(podcast.TranscriptionLanguage, Is.EqualTo(transcriptionLanguage), "TranscriptionLanguage");
                    Assert.That(podcast.ExternalSiteUrl, Is.EqualTo(externalSiteUrl), "ExternalSiteUrl");
                    Assert.That(podcast.Domain, Is.EqualTo(domain), "Domain");
                });
            }
            else
            {
                Assert.That(() => new Podcast(
                    category,
                    quality,
                    subdomain,
                    title,
                    subtitle,
                    description,
                    introOutroFiles,
                    language,
                    authors,
                    coverImage,
                    websiteUrl,
                    ownerEmail,
                    publicationType,
                    @explicit,
                    flattrId,
                    twitter,
                    facebook,
                    copyrightText,
                    feedItems,
                    transcriptionsEnabled,
                    transcriptionLanguage,
                    externalSiteUrl,
                    domain), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }
        #endregion
    }
}
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using PodigeeNet.Data;
using PodigeeNet.Rest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static NUnit.Framework.TestContext;

namespace PodigeeNet.IntegrationTests
{
    /// <summary>
    /// Provides a <see cref="PodigeeIntegrationTest"/> class.
    /// </summary>
    [TestFixture]
    public class PodigeeIntegrationTest
    {
        #region Public Constants
#if DEBUG
        private const int timeout = int.MaxValue;
#else
        private const int timeout = 5000;
#endif
        #endregion

        #region Private Fields
        private string _apiToken;
        private string _logFilePath;
        private string _uploadFilePath;
        private Podigee _podigee;

        private List<string> _executedTests = new List<string>();
        private List<string> _failedTests = new List<string>();

        private Podcast _podcast;
        private Contributor _contributor;
        private Episode _episode;
        private ChapterMark _chapterMark;
        private Upload _upload;
        private MediaClip _mediaClip;
        private Production _production;
        #endregion

        #region SetUp/TearDown
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _apiToken = Environment.GetEnvironmentVariable("PODIGEE_API_TOKEN");
            _uploadFilePath = Environment.GetEnvironmentVariable("PODIGEE_UPLOAD_FILE");
            _logFilePath = Environment.GetEnvironmentVariable("PODIGEE_LOG_FILE_PATH");

            if (!String.IsNullOrWhiteSpace(_apiToken))
            {
                _podigee = new Podigee(_apiToken);

                if (!String.IsNullOrWhiteSpace(_logFilePath))
                {
                    _podigee.RecieveResponse += Podigee_RecieveResponse;
                    _podigee.SendRequest += Podigee_SendRequest;
                }
            }
        }

        [SetUp]
        public void SetUp()
        {
            if (String.IsNullOrWhiteSpace(_apiToken))
            {
                Assert.Warn("Unable to run Test, as necessary Podigee api token is not available.");
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                _executedTests.Add(CurrentContext.Test.Name);
            }
            else if (CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                _failedTests.Add(CurrentContext.Test.Name);
            }
        }
        #endregion


        #region Tests - CreatePodcast
        [Test, Order(1), Timeout(timeout)]
        public void Invoke_CreatePodcast_Returns_Result()
        {
            var podcast = new Podcast(
                PodcastCategory.Other,
                PodcastQuality.High,
                "IntegrationTestPodcastSubdomain", // Darf keine leerzeichen enthalten
                "Integration Test Podcast Title",
                "Integration Test Podcast Subtitle",
                "Integration Test Podcast Description",
                null,
                PodcastLanguage.English,
                "Integration Test Podcast Authors",
                null,//CoverImage = "Integration Test Podcast Cover Image",
                null,//WebsiteUrl = "Integration Test Podcast Website Url",
                "Integration Test Podcast Owner Email",
                PodcastPublicationType.Serial,
                true,
                "Integration Test Podcast Flattr Id",
                "Integration Test Podcast Twitter",
                "Integration Test Podcast Facebook",
                "Integration Test Podcast Copyright text",
                123,
                true,
                TranscriptionLanguage.en_US,
                null,//ExternalSiteUrl = "Integration Test Podcast External Site Url",
                null//Domain = "Integration Test Podcast Domain"
                );

            Assert.That(() => _podcast = _podigee.CreatePodcast(podcast), Throws.Nothing);
            ComparePodcast(_podcast, podcast);
        }
        #endregion

        #region Tests - UpdatePodcast
        [Test, Order(2), Timeout(timeout)]
        public void Invoke_UpdatePodcast_Returns_Result()
        {
            IsDependentOn("Invoke_CreatePodcast_Returns_Result");

            var podcastUpdate = new Podcast
            {
                Id = _podcast.Id,
                Subdomain = _podcast.Subdomain + "update",
                Category = _podcast.Category,
                Title = _podcast.Title + " Update",
                Subtitle = _podcast.Subtitle + " Update",
                Description = _podcast.Description + " Update",
                IntroOutroFiles = _podcast.IntroOutroFiles,
                Quality = _podcast.Quality,
                Language = PodcastLanguage.German,
                Authors = _podcast.Authors + " Update",
                CoverImage = _podcast.CoverImage,
                WebsiteUrl = _podcast.WebsiteUrl,
                OwnerEmail = _podcast.OwnerEmail + " Update",
                PublishedAt = DateTime.Now.Date,
                CreatedAt = _podcast.CreatedAt,
                UpdatedAt = _podcast.UpdatedAt,
                Keywords = _podcast.Keywords,
                Feeds = _podcast.Feeds,
                PublicationType = PodcastPublicationType.Episodic,
                Explicit = false,
                FlattrId = _podcast.FlattrId + " Update",
                Twitter = _podcast.Twitter + " Update",
                Facebook = _podcast.Facebook + " Update",
                ItunesId = _podcast.ItunesId,
                SpotifyUrl = _podcast.SpotifyUrl,
                DeezerUrl = _podcast.DeezerUrl,
                AlexaUrl = _podcast.AlexaUrl,
                CopyrightText = _podcast.CopyrightText + " Update",
                FeedItems = 321,
                TranscriptionsEnabled = false,
                TranscriptionLanguage = TranscriptionLanguage.de_DE,
                ExternalSiteUrl = _podcast.ExternalSiteUrl,
                Domain = _podcast.Domain
            };

            Podcast podcast = null;

            Assert.That(() => podcast = _podigee.UpdatePodcast(podcastUpdate), Throws.Nothing);
            ComparePodcast(podcast, podcastUpdate);

            _podcast = podcast;
        }
        #endregion

        #region Tests - GetPodcast
        [Test, Order(3), Timeout(timeout)]
        public void Invoke_GetPodcast_Returns_Result()
        {
            IsDependentOn("Invoke_CreatePodcast_Returns_Result");

            Podcast podcast = null;

            Assert.That(() => podcast = _podigee.GetPodcast(_podcast.Id), Throws.Nothing);
            ComparePodcast(podcast, _podcast);
        }
        #endregion

        #region Tests - GetPodcasts
        [Test, Order(4), Timeout(timeout)]
        public void Invoke_GetPodcasts_Returns_Result()
        {
            IsDependentOn("Invoke_CreatePodcast_Returns_Result");

            List<Podcast> podcasts = null;
            Podcast podcast = null;

            Assert.That(() => podcasts = _podigee.GetPodcasts(), Throws.Nothing);
            Assert.That(() => podcast = podcasts.First(o => o.Id == _podcast.Id), Throws.Nothing);
            ComparePodcast(podcast, _podcast);
        }
        #endregion

        #region Compare Method - Podcast
        private void ComparePodcast(Podcast podcast1, Podcast podcast2)
        {
            Assert.That(podcast1, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(podcast1.Id, Is.GreaterThan(0), "Id");
                Assert.That(podcast1.Subdomain, Is.EqualTo(podcast2.Subdomain.ToLower()), "Subdomain");
                Assert.That(podcast1.Category, Is.EqualTo(podcast2.Category), "Category");
                Assert.That(podcast1.Title, Is.EqualTo(podcast2.Title), "Title");
                Assert.That(podcast1.Subtitle, Is.EqualTo(podcast2.Subtitle), "Subtitle");
                Assert.That(podcast1.Description, Is.EqualTo(podcast2.Description), "Description");
                Assert.That(podcast1.IntroOutroFiles.Count, Is.EqualTo(0), "IntroOutroFiles");
                Assert.That(podcast1.Quality, Is.EqualTo(podcast2.Quality), "Quality");
                Assert.That(podcast1.Language, Is.EqualTo(podcast2.Language), "Language");
                Assert.That(podcast1.Authors, Is.EqualTo(podcast2.Authors), "Authors");
                Assert.That(podcast1.CoverImage, Is.EqualTo(podcast2.CoverImage), "CoverImage");
                Assert.That(podcast1.WebsiteUrl, Is.EqualTo(podcast2.WebsiteUrl), "WebsiteUrl");
                Assert.That(podcast1.OwnerEmail, Is.EqualTo(podcast2.OwnerEmail), "OwnerEmail");
                Assert.That(podcast1.PublishedAt.Date, Is.EqualTo(podcast2.PublishedAt.Date), "PublishedAt");
                Assert.That(podcast1.CreatedAt.Date, Is.EqualTo(DateTime.Now.Date), "CreatedAt");
                Assert.That(podcast1.UpdatedAt.Date, Is.EqualTo(DateTime.Now.Date), "UpdatedAt");
                Assert.That(podcast1.Keywords.Count, Is.EqualTo(0), "Keywords");
                Assert.That(podcast1.Feeds.Count, Is.EqualTo(4), "Feeds");
                Assert.That(podcast1.PublicationType, Is.EqualTo(podcast2.PublicationType), "PublicationType");
                Assert.That(podcast1.Explicit, Is.EqualTo(podcast2.Explicit), "Explicit");
                Assert.That(podcast1.FlattrId, Is.EqualTo(podcast2.FlattrId), "FlattrId");
                Assert.That(podcast1.Twitter, Is.EqualTo(podcast2.Twitter), "Twitter");
                Assert.That(podcast1.Facebook, Is.EqualTo(podcast2.Facebook), "Facebook");
                Assert.That(podcast1.ItunesId, Is.EqualTo(podcast2.ItunesId), "ItunesId");
                Assert.That(podcast1.SpotifyUrl, Is.EqualTo(podcast2.SpotifyUrl), "SpotifyUrl");
                Assert.That(podcast1.DeezerUrl, Is.EqualTo(podcast2.DeezerUrl), "DeezerUrl");
                Assert.That(podcast1.AlexaUrl, Is.EqualTo(podcast2.AlexaUrl), "AlexaUrl");
                Assert.That(podcast1.CopyrightText, Is.EqualTo(podcast2.CopyrightText), "CopyrightText");
                Assert.That(podcast1.FeedItems, Is.EqualTo(podcast2.FeedItems), "FeedItems");
                Assert.That(podcast1.TranscriptionsEnabled, Is.EqualTo(podcast2.TranscriptionsEnabled), "TranscriptionsEnabled");
                Assert.That(podcast1.TranscriptionLanguage, Is.EqualTo(podcast2.TranscriptionLanguage), "TranscriptionLanguage");
                Assert.That(podcast1.ExternalSiteUrl, Is.EqualTo(podcast2.ExternalSiteUrl), "ExternalSiteUrl");
                Assert.That(podcast1.Domain, Is.EqualTo(podcast2.Domain), "Domain");
            });
        }
        #endregion


        #region Tests - CreateEpisode
        [Test, Order(5), Timeout(timeout)]
        public void Invoke_CreateEpisode_Returns_Result()
        {
            IsDependentOn("Invoke_CreatePodcast_Returns_Result");

            var episode = new Episode(
                _podcast.Id,
                Guid.NewGuid().ToString(),
                "Integration Test Episode Title",
                "Integration Test Episode Subtitle",
                "Integration Test Episode Description",
                "http://website.com/external_url",
                1,
                2,
                "Integration Test Episode ShowNotes",
                "Integration Test Episode Authors",
                true,
                null,//CoverImage = "Integration Test Episode CoverImage",
                null,//FacebookImage = "Integration Test Episode FacebookImage",
                EpisodePublicationType.Trailer);

            Assert.That(() => _episode = _podigee.CreateEpisode(episode), Throws.Nothing);
            CompareEpisode(_episode, episode);
        }
        #endregion

        #region Tests - UpdateEpisode
        [Test, Order(6), Timeout(timeout)]
        public void Invoke_UpdateEpisode_Returns_Result()
        {
            IsDependentOn("Invoke_CreateEpisode_Returns_Result");

            var episodeUpdate = new Episode
            {
                Id = _episode.Id,
                Guid = Guid.NewGuid().ToString(),
                PodcastId = _episode.PodcastId,
                ProductionId = _episode.ProductionId,
                Title = _episode.Title + " Update",
                Subtitle = _episode.Subtitle + " Update",
                Description = _episode.Description + " Update",
                Slug = _episode.Slug,
                ExternalUrl = _episode.ExternalUrl + "/update",
                Number = 3,
                Season = 4,
                Permalink = _episode.Permalink,
                PublishedAt = _episode.PublishedAt,
                CreatedAt = _episode.CreatedAt,
                UpdatedAt = _episode.UpdatedAt,
                Keywords = _episode.Keywords,
                ChapterMarks = _episode.ChapterMarks,
                ShowNotes = _episode.ShowNotes + " Update",
                Authors = _episode.Authors + " Update",
                Explicit = false,
                CoverImage = _episode.CoverImage,
                FacebookImage = _episode.FacebookImage,
                Transcription = _episode.Transcription,
                ContributorIds = _episode.ContributorIds,
                PublicationType = EpisodePublicationType.Bonus
            };

            Episode episode = null;

            Assert.That(() => episode = _podigee.UpdateEpisode(episodeUpdate), Throws.Nothing);
            CompareEpisode(episode, episodeUpdate);

            _episode = episode;
        }
        #endregion

        #region Tests - GetEpisode
        [Test, Order(7), Timeout(timeout)]
        public void Invoke_GetEpisode_Returns_Result()
        {
            IsDependentOn("Invoke_CreateEpisode_Returns_Result");

            Episode episode = null;

            Assert.That(() => episode = _podigee.GetEpisode(_episode.Id), Throws.Nothing);
            CompareEpisode(episode, _episode);
        }
        #endregion

        #region Tests - GetEpisodes
        [Test, Order(8), Timeout(timeout)]
        public void Invoke_GetEpisodes_Returns_Result()
        {
            IsDependentOn("Invoke_CreateEpisode_Returns_Result");

            List<Episode> episodes = null;
            Episode episode = null;

            Assert.That(() => episodes = _podigee.GetEpisodes(_episode.PodcastId), Throws.Nothing);
            Assert.That(() => episode = episodes.First(o => o.Id == _episode.Id), Throws.Nothing);
            CompareEpisode(episode, _episode);
        }
        #endregion

        #region Compare Method - Episode
        private void CompareEpisode(Episode episode1, Episode episode2)
        {
            Assert.That(episode1, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(episode1.Id, Is.GreaterThan(0), "Id");
                Assert.That(episode1.Guid, Is.EqualTo(episode2.Guid), "Guid");
                Assert.That(episode1.PodcastId, Is.EqualTo(episode2.PodcastId), "PodcastId");
                Assert.That(episode1.ProductionId, Is.EqualTo(episode2.ProductionId), "ProductionId");
                Assert.That(episode1.Title, Is.EqualTo(episode2.Title), "Title");
                Assert.That(episode1.Subtitle, Is.EqualTo(episode2.Subtitle), "Subtitle");
                Assert.That(episode1.Description, Is.EqualTo(episode2.Description), "Description");
                Assert.That(String.IsNullOrWhiteSpace(episode1.Slug), Is.False, "Slug");
                Assert.That(episode1.ExternalUrl, Is.EqualTo(episode2.ExternalUrl), "ExternalUrl");
                Assert.That(episode1.Number, Is.EqualTo(episode2.Number), "Number");
                Assert.That(episode1.Season, Is.EqualTo(episode2.Season), "Season");
                Assert.That(String.IsNullOrWhiteSpace(episode1.Permalink), Is.False, "Permalink");
                Assert.That(episode1.PublishedAt.Date, Is.EqualTo(episode2.PublishedAt.Date), "PublishedAt");
                Assert.That(episode1.CreatedAt.Date, Is.EqualTo(DateTime.Now.Date), "CreatedAt");
                Assert.That(episode1.UpdatedAt.Date, Is.EqualTo(DateTime.Now.Date), "UpdatedAt");
                Assert.That(episode1.Keywords.Count, Is.EqualTo(0), "Keywords");
                Assert.That(episode1.ChapterMarks.Count, Is.EqualTo(0), "ChapterMarks");
                Assert.That(episode1.ShowNotes, Is.EqualTo(episode2.ShowNotes), "ShowNotes");
                Assert.That(episode1.Authors, Is.EqualTo(episode2.Authors), "Authors");
                Assert.That(episode1.Explicit, Is.EqualTo(episode2.Explicit), "Explicit");
                Assert.That(episode1.CoverImage, Is.EqualTo(episode2.CoverImage), "CoverImage");
                Assert.That(episode1.FacebookImage, Is.EqualTo(episode2.FacebookImage), "FacebookImage");
                Assert.That(episode1.Transcription.Count, Is.EqualTo(0), "Transcription");
                Assert.That(episode1.ContributorIds.Count, Is.EqualTo(0), "ContributorIds");
                Assert.That(episode1.PublicationType, Is.EqualTo(episode2.PublicationType), "PublicationType");
            });
        }
        #endregion


        #region Tests - CreateContributor
        [Test, Order(9), Timeout(timeout)]
        public void Invoke_CreateContributor_Returns_Result()
        {
            IsDependentOn("Invoke_CreatePodcast_Returns_Result");

            var contributor = new Contributor(
                _podcast.Id,
                "Integration Test Contributor Name",
                "Integration Test Contributor Email",
                "Integration Test Contributor Biography",
                "Integration Test Contributor AvatarUrl");

            Assert.That(() => _contributor = _podigee.CreateContributor(contributor), Throws.Nothing);
            CompareContributor(_contributor, contributor);
        }
        #endregion

        #region Tests - UpdateContributor
        [Test, Order(10), Timeout(timeout)]
        public void Invoke_UpdateContributor_Returns_Result()
        {
            IsDependentOn("Invoke_CreateContributor_Returns_Result");

            var contributorUpdate = new Contributor
            {
                Id = _contributor.Id,
                PodcastId = _contributor.PodcastId,
                UserId = _contributor.UserId,
                Name = _contributor.Name + " Update",
                Email = _contributor.Email + " Update",
                Biography = _contributor.Biography + " Update",
                AvatarUrl = _contributor.AvatarUrl + " Update",
                Links = _contributor.Links,
                CreatedAt = _contributor.CreatedAt,
                UpdatedAt = _contributor.UpdatedAt,
            };

            Contributor contributor = null;

            Assert.That(() => contributor = _podigee.UpdateContributor(contributorUpdate), Throws.Nothing);
            CompareContributor(contributor, contributorUpdate);

            _contributor = contributor;
        }
        #endregion

        #region Tests - GetContributor
        [Test, Order(11), Timeout(timeout)]
        public void Invoke_GetContributor_Returns_Result()
        {
            IsDependentOn("Invoke_CreateContributor_Returns_Result");

            Contributor contributor = null;

            Assert.That(() => contributor = _podigee.GetContributor(_contributor.Id), Throws.Nothing);
            CompareContributor(contributor, _contributor);
        }
        #endregion

        #region Tests - GetContributors
        [Test, Order(12), Timeout(timeout)]
        public void Invoke_GetContributors_Returns_Result()
        {
            IsDependentOn("Invoke_CreateContributor_Returns_Result");

            List<Contributor> contributors = null;
            Contributor contributor = null;

            Assert.That(() => contributors = _podigee.GetContributors(_contributor.PodcastId), Throws.Nothing);
            Assert.That(() => contributor = contributors.First(o => o.Id == _contributor.Id), Throws.Nothing);
            CompareContributor(contributor, _contributor);
        }
        #endregion

        #region Tests - DeleteContributor
        [Test, Order(13), Timeout(timeout)]
        public void Invoke_DeleteContributor()
        {
            IsDependentOn("Invoke_CreateContributor_Returns_Result");
            Assert.That(() => _podigee.DeleteContributor(_contributor.Id), Throws.Nothing);
            _contributor = null;
        }
        #endregion

        #region Compare Method - Contributor
        private void CompareContributor(Contributor contributor1, Contributor contributor2)
        {
            Assert.That(contributor1, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(contributor1.Id, Is.GreaterThan(0), "Id");
                Assert.That(contributor1.PodcastId, Is.EqualTo(contributor2.PodcastId), "PodcastId");
                Assert.That(contributor1.UserId, Is.EqualTo(contributor2.UserId), "UserId");
                Assert.That(contributor1.Name, Is.EqualTo(contributor2.Name), "Name");
                Assert.That(contributor1.Email, Is.EqualTo(contributor2.Email), "Email");
                Assert.That(contributor1.Biography, Is.EqualTo(contributor2.Biography), "Biography");
                Assert.That(contributor1.AvatarUrl, Is.EqualTo(contributor2.AvatarUrl), "AvatarUrl");
                Assert.That(contributor1.Links.Count, Is.EqualTo(0), "Links");
                Assert.That(contributor1.CreatedAt.Date, Is.EqualTo(DateTime.Now.Date), "CreatedAt");
                Assert.That(contributor1.UpdatedAt.Date, Is.EqualTo(DateTime.Now.Date), "UpdatedAt");
            });
        }
        #endregion


        #region Tests - CreateChapterMark
        [Test, Order(14), Timeout(timeout)]
        public void Invoke_CreateChapterMark_Returns_Result()
        {
            IsDependentOn("Invoke_CreateEpisode_Returns_Result");

            var chapterMark = new ChapterMark(
                _episode.Id,
                "Integration Test ChapterMark Title",
                new TimeSpan(0, 1, 23),
                "Integration Test ChapterMark Url");

            Assert.That(() => _chapterMark = _podigee.CreateChapterMark(chapterMark), Throws.Nothing);
            CompareChapterMark(_chapterMark, chapterMark);
        }
        #endregion

        #region Tests - UpdateChapterMark
        [Test, Order(15), Timeout(timeout)]
        public void Invoke_UpdateChapterMark_Returns_Result()
        {
            IsDependentOn("Invoke_CreateChapterMark_Returns_Result");

            var chapterMarkUpdate = new ChapterMark
            {
                Id = _chapterMark.Id,
                EpisodeId = _chapterMark.EpisodeId,
                Title = _chapterMark.Title + " Update",
                StartTime = new TimeSpan(0, 1, 23),
                Url = _chapterMark.Url + " Update",
                CreatedAt = _chapterMark.CreatedAt,
                UpdatedAt = _chapterMark.UpdatedAt,
            };

            ChapterMark chapterMark = null;

            Assert.That(() => chapterMark = _podigee.UpdateChapterMark(chapterMarkUpdate), Throws.Nothing);
            CompareChapterMark(chapterMark, chapterMarkUpdate);

            _chapterMark = chapterMark;
        }
        #endregion

        #region Tests - DeleteChapterMark
        [Test, Order(16), Timeout(timeout)]
        public void Invoke_DeleteChapterMark()
        {
            IsDependentOn("Invoke_CreateChapterMark_Returns_Result");
            Assert.That(() => _podigee.DeleteChapterMark(_chapterMark.Id), Throws.Nothing);
            _chapterMark = null;
        }
        #endregion

        #region Compare Method - ChapterMark
        private void CompareChapterMark(ChapterMark chapterMark1, ChapterMark chapterMark2)
        {
            Assert.That(chapterMark1, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(chapterMark1.Id, Is.GreaterThan(0), "Id");
                Assert.That(chapterMark1.EpisodeId, Is.EqualTo(chapterMark2.EpisodeId), "EpisodeId");
                Assert.That(chapterMark1.Title, Is.EqualTo(chapterMark2.Title), "Title");
                Assert.That(chapterMark1.StartTime, Is.EqualTo(chapterMark2.StartTime), "StartTime");
                Assert.That(chapterMark1.Url, Is.EqualTo(chapterMark2.Url), "Url");
                Assert.That(chapterMark1.CreatedAt.Date, Is.EqualTo(DateTime.Now.Date), "CreatedAt");
                Assert.That(chapterMark1.UpdatedAt.Date, Is.EqualTo(DateTime.Now.Date), "UpdatedAt");
            });
        }
        #endregion


        #region Tests - CreateMediaClip
        [Test, Order(17), Timeout(timeout)]
        public void Invoke_CreateMediaClip_Returns_Result()
        {
            IsDependentOn("Invoke_CreateEpisode_Returns_Result");

            var mediaClip = new MediaClip(_episode.Id, FileFormat.Mp3, "Url");

            Assert.That(() => _mediaClip = _podigee.CreateMediaClip(mediaClip), Throws.Nothing);
            CompareMediaClip(_mediaClip, mediaClip);
        }
        #endregion

        #region Tests - GetMediaClip
        [Test, Order(18), Timeout(timeout)]
        public void Invoke_GetMediaClip_Returns_Result()
        {
            IsDependentOn("Invoke_CreateMediaClip_Returns_Result");

            MediaClip mediaClip = null;

            Assert.That(() => mediaClip = _podigee.GetMediaClip(_mediaClip.Id), Throws.Nothing);
            CompareMediaClip(mediaClip, _mediaClip);
        }
        #endregion

        #region Tests - GetMediaClips
        [Test, Order(19), Timeout(timeout)]
        public void Invoke_GetMediaClips_Returns_Result()
        {
            IsDependentOn("Invoke_CreateMediaClip_Returns_Result");

            List<MediaClip> mediaClips = null;
            MediaClip mediaClip = null;

            Assert.That(() => mediaClips = _podigee.GetMediaClips(_mediaClip.EpisodeId), Throws.Nothing);
            Assert.That(() => mediaClip = mediaClips.First(o => o.Id == _mediaClip.Id), Throws.Nothing);
            CompareMediaClip(mediaClip, _mediaClip);
        }
        #endregion

        #region Tests - DeleteMediaClip
        [Test, Order(20), Timeout(timeout)]
        public void Invoke_DeleteMediaClip()
        {
            IsDependentOn("Invoke_CreateMediaClip_Returns_Result");
            Assert.That(() => _podigee.DeleteMediaClip(_mediaClip.Id), Throws.Nothing);
            _mediaClip = null;
        }
        #endregion

        #region Compare Method - MediaClip
        private void CompareMediaClip(MediaClip mediaClip1, MediaClip mediaClip2)
        {
            Assert.That(mediaClip1, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(mediaClip1.Id, Is.GreaterThan(0), "Id");
                Assert.That(mediaClip1.EpisodeId, Is.EqualTo(mediaClip2.EpisodeId), "EpisodeId");
                Assert.That(mediaClip1.FileFormat, Is.EqualTo(mediaClip2.FileFormat), "FileFormat");
                Assert.That(mediaClip1.Url.Contains(mediaClip2.Url), Is.True, "Url");
                Assert.That(mediaClip1.CreatedAt.Date, Is.EqualTo(DateTime.Now.Date), "CreatedAt");
                Assert.That(mediaClip1.Size, Is.EqualTo(mediaClip2.Size), "Size");
                Assert.That(mediaClip1.Duration, Is.EqualTo(mediaClip2.Duration), "Duration");
            });
        }
        #endregion


        #region Tests - CreateProduction
        [Test, Order(21), Timeout(timeout)]
        public void Invoke_CreateProduction_Returns_Result()
        {
            IsDependentOn("Invoke_CreateEpisode_Returns_Result");

            Production production = new Production(_episode.Id);

            Assert.That(() => _production = _podigee.CreateProduction(production), Throws.Nothing);
            CompareProduction(_production, production);
        }
        #endregion

        #region Tests - GetProduction
        [Test, Order(22), Timeout(timeout)]
        public void Invoke_GetProduction_Returns_Result()
        {
            IsDependentOn("Invoke_CreateProduction_Returns_Result");

            Production production = null;

            Assert.That(() => production = _podigee.GetProduction(_production.Id), Throws.Nothing);
            CompareProduction(production, _production);
        }
        #endregion

        #region Tests - DeleteProduction
        [Test, Order(23), Timeout(timeout)]
        public void Invoke_DeleteProduction()
        {
            IsDependentOn("Invoke_CreateProduction_Returns_Result");
            Assert.That(() => _podigee.DeleteProduction(_production.Id), Throws.Nothing);
            _production = null;
        }
        #endregion

        #region Compare Method - Production
        private void CompareProduction(Production production1, Production production2)
        {
            Assert.That(production1, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(production1.Id, Is.GreaterThan(0), "Id");
                Assert.That(production1.EpisodeId, Is.EqualTo(production2.EpisodeId), "EpisodeId");
                Assert.That(production1.Files.Count, Is.EqualTo(0), "Files");
                Assert.That(production1.State, Is.EqualTo(production2.State), "State");
                Assert.That(production1.TranscriptionUrl, Is.EqualTo(production2.TranscriptionUrl), "TranscriptionUrl");
                Assert.That(production1.CreatedAt.Date, Is.EqualTo(DateTime.Now.Date), "CreatedAt");
                Assert.That(production1.UpdatedAt.Date, Is.EqualTo(DateTime.Now.Date), "UpdatedAt");
            });
        }
        #endregion


        #region Tests - UploadFile
        [Test, Order(24), Timeout(timeout)]
        public void Invoke_UploadFile()
        {
            IsDependentOn("Invoke_CreatePodcast_Returns_Result");

            if (String.IsNullOrWhiteSpace(_uploadFilePath))
            {
                Assert.Warn("Unable to run Test, as necessary upload file is not defined.");
            }

            Assert.That(() => _upload = _podigee.UploadFile(_uploadFilePath), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(_upload.UploadUrl, Is.Not.Null);
                Assert.That(_upload.ContentType, Is.Not.Null);
                Assert.That(_upload.FileUrl, Is.Not.Null);
            });
        }
        #endregion


        #region Tests - DeleteEpisode
        [Test, Order(25), Timeout(timeout)]
        public void Invoke_DeleteEpisode()
        {
            IsDependentOn("Invoke_CreateEpisode_Returns_Result");
            Assert.That(() => _podigee.DeleteEpisode(_episode.Id), Throws.Nothing);
            _episode = null;
        }
        #endregion

        #region Tests - DeletePodcast
        [Test, Order(26), Timeout(timeout)]
        public void Invoke_DeletePodcast()
        {
            IsDependentOn("Invoke_CreatePodcast_Returns_Result");
            Assert.That(() => _podigee.DeletePodcast(_podcast.Id), Throws.Nothing);
            _podcast = null;
        }
        #endregion


        #region Private Methods
        private void IsDependentOn(string test)
        {
            if (_failedTests.Any(o => o == test))
            {
                Assert.Ignore($"Unable to run Test, as dependent Test '{test}' failed.");
            }
            else if (!_executedTests.Any(o => o == test))
            {
                Assert.Ignore($"Unable to run Test, as dependent Test '{test}' was not executed.");
            }
        }
        #endregion

        #region Private Event Handler
        private void Podigee_SendRequest(object sender, RestRequestEventArgs e)
        {
            var sb = new StringBuilder()
                .AppendLine($"Method: {e.Request.Method}")
                .AppendLine($"Resource: {e.Request.Resource}")
                .AppendLine($"Parameters: {String.Join(Environment.NewLine, e.Request.Parameters)}")
                .AppendLine("----------------------------------------------------------------------------------------------------");

            File.AppendAllText(_logFilePath, sb.ToString());
        }

        private void Podigee_RecieveResponse(object sender, RestResponseEventArgs e)
        {
            var sb = new StringBuilder()
                .AppendLine($"ContentType: {e.Response.ContentType}")
                .AppendLine($"ContentLength: {e.Response.ContentLength}")
                .AppendLine($"ContentEncoding: {e.Response.ContentEncoding}")
                .AppendLine($"Content: {e.Response.Content}")
                .AppendLine($"ResponseUri: {e.Response.ResponseUri}")
                .AppendLine($"ResponseStatus: {e.Response.ResponseStatus}")
                .AppendLine($"StatusCode: {e.Response.StatusCode}")
                .AppendLine($"Server: {e.Response.Server}")
                .AppendLine($"ErrorException: {e.Response.ErrorException}")
                .AppendLine($"ErrorMessage: {e.Response.ErrorMessage}")
                .AppendLine("----------------------------------------------------------------------------------------------------");

            File.AppendAllText(_logFilePath, sb.ToString());
        }
        #endregion
    }
}
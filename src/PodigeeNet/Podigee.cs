using PodigeeNet.Data;
using PodigeeNet.Json;
using PodigeeNet.Rest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PodigeeNet
{
    /// <summary>
    /// Provides a <see cref="Podigee"/> class.
    /// </summary>
    public class Podigee
    {
        #region Public Events
        /// <summary>
        /// Occurs when the response has been received.
        /// </summary>
        public event EventHandler<RestResponseEventArgs> RecieveResponse;

        /// <summary>
        /// Occurs when the request has been send.
        /// </summary>
        public event EventHandler<RestRequestEventArgs> SendRequest;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the Podigee API Token.
        /// </summary>
        public string ApiToken { get; }

        /// <summary>
        /// Gets the Podigee base URL.
        /// </summary>
        public string BaseUrl { get; }
        #endregion

        #region Private Fields
        private readonly IRestClient _client;
        #endregion

        #region Private Enum
        private enum AuthenticatorType
        {
            None,
            Basic,
            OAuth2
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Podigee"/> class.
        /// </summary>
        /// <param name="apiToken">The Podigee API Token.</param>
        /// <exception cref="ArgumentException"><em>apiToken</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>apiToken</em> is <strong>null</strong>.</exception>
        public Podigee(string apiToken)
        {
            Precondition.IsNotNullOrWhiteSpace(apiToken, nameof(apiToken));

            ApiToken = apiToken;
            BaseUrl = "https://app.podigee.com/api/v1/";

            _client = new RestClient(BaseUrl);
            _client.AddHandler("application/json", NewtonsoftJsonSerializer.Default);
            _client.AddHandler("text/json", NewtonsoftJsonSerializer.Default);
            _client.AddHandler("text/x-json", NewtonsoftJsonSerializer.Default);
            _client.AddHandler("text/javascript", NewtonsoftJsonSerializer.Default);
            _client.AddHandler("*+json", NewtonsoftJsonSerializer.Default);
        }
        #endregion


        #region CreateChapterMark
        /// <summary>Creates a new chapter mark.</summary>
        /// <param name="chapterMark">A chapter mark to create.</param>
        /// <returns>The created chapter mark.</returns>
        /// <exception cref="ArgumentNullException"><em>chapterMark</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public ChapterMark CreateChapterMark(ChapterMark chapterMark)
        {
            return Task.Run(async () => await CreateChapterMarkAsync(chapterMark)).GetAwaiter().GetResult();
        }

        /// <summary>Creates a new chapter mark asynchronously.</summary>
        /// <param name="chapterMark">A chapter mark to create.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created chapter mark.</returns>
        /// <exception cref="ArgumentNullException"><em>chapterMark</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<ChapterMark> CreateChapterMarkAsync(ChapterMark chapterMark)
        {
            return CreateChapterMarkAsync(chapterMark, CancellationToken.None);
        }

        /// <summary>Creates a new chapter mark asynchronously.</summary>
        /// <param name="chapterMark">A chapter mark to create.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created chapter mark.</returns>
        /// <exception cref="ArgumentNullException"><em>chapterMark</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<ChapterMark> CreateChapterMarkAsync(ChapterMark chapterMark, CancellationToken cancellationToken)
        {
            Precondition.IsNotNull(chapterMark, nameof(chapterMark));

            var request = new Rest.RestRequest("chapter_marks", Method.POST);
            request.AddJsonBody(chapterMark);

            return await ExecuteRequestAsync<ChapterMark>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region DeleteChapterMark
        /// <summary>Deletes a chapter mark.</summary>
        /// <param name="chapterMarkId">A chapter mark ID.</param>
        /// <exception cref="ArgumentOutOfRangeException"><em>chapterMarkId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public void DeleteChapterMark(long chapterMarkId)
        {
            Task.Run(async () => await DeleteChapterMarkAsync(chapterMarkId)).GetAwaiter().GetResult();
        }

        /// <summary>Deletes a chapter mark asynchronously.</summary>
        /// <param name="chapterMarkId">A chapter mark ID.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>chapterMarkId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task DeleteChapterMarkAsync(long chapterMarkId)
        {
            return DeleteChapterMarkAsync(chapterMarkId, CancellationToken.None);
        }

        /// <summary>Deletes a chapter mark asynchronously.</summary>
        /// <param name="chapterMarkId">A chapter mark ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>chapterMarkId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task DeleteChapterMarkAsync(long chapterMarkId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(chapterMarkId, (long)0, nameof(chapterMarkId));

            var request = new Rest.RestRequest("chapter_marks/{chapterMarkId}", Method.DELETE);
            request.AddUrlSegment("chapterMarkId", chapterMarkId);

            await ExecuteRequestAsync<ChapterMark>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region UpdateChapterMark
        /// <summary>Updates a chapter mark.</summary>
        /// <param name="chapterMark">A chapter mark to update.</param>
        /// <returns>The updated chapter mark.</returns>
        /// <exception cref="ArgumentNullException"><em>chapterMark</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public ChapterMark UpdateChapterMark(ChapterMark chapterMark)
        {
            return Task.Run(async () => await UpdateChapterMarkAsync(chapterMark)).GetAwaiter().GetResult();
        }

        /// <summary>Updates a chapter mark asynchronously.</summary>
        /// <param name="chapterMark">A chapter mark to update.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the updated chapter mark.</returns>
        /// <exception cref="ArgumentNullException"><em>chapterMark</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<ChapterMark> UpdateChapterMarkAsync(ChapterMark chapterMark)
        {
            return UpdateChapterMarkAsync(chapterMark, CancellationToken.None);
        }

        /// <summary>Updates a chapter mark asynchronously.</summary>
        /// <param name="chapterMark">A chapter mark to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the updated chapter mark.</returns>
        /// <exception cref="ArgumentNullException"><em>chapterMark</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<ChapterMark> UpdateChapterMarkAsync(ChapterMark chapterMark, CancellationToken cancellationToken)
        {
            Precondition.IsNotNull(chapterMark, nameof(chapterMark));

            var request = new Rest.RestRequest("chapter_marks/{chapterMarkId}", Method.PUT);
            request.AddUrlSegment("chapterMarkId", chapterMark.Id);
            request.AddJsonBody(chapterMark);

            return await ExecuteRequestAsync<ChapterMark>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion


        #region CreateContributor
        /// <summary>Creates a new contributor.</summary>
        /// <param name="contributor">A contributor to create.</param>
        /// <returns>The created contributor.</returns>
        /// <exception cref="ArgumentNullException"><em>contributor</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Contributor CreateContributor(Contributor contributor)
        {
            return Task.Run(async () => await CreateContributorAsync(contributor)).GetAwaiter().GetResult();
        }

        /// <summary>Creates a new contributor asynchronously.</summary>
        /// <param name="contributor">A contributor to create.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created contributor.</returns>
        /// <exception cref="ArgumentNullException"><em>contributor</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<Contributor> CreateContributorAsync(Contributor contributor)
        {
            return CreateContributorAsync(contributor, CancellationToken.None);
        }

        /// <summary>Creates a new contributor asynchronously.</summary>
        /// <param name="contributor">A contributor to create.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created contributor.</returns>
        /// <exception cref="ArgumentNullException"><em>contributor</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<Contributor> CreateContributorAsync(Contributor contributor, CancellationToken cancellationToken)
        {
            Precondition.IsNotNull(contributor, nameof(contributor));

            var request = new Rest.RestRequest("contributors", Method.POST);
            request.AddJsonBody(contributor);

            return await ExecuteRequestAsync<Contributor>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region DeleteContributor
        /// <summary>Deletes a contributor.</summary>
        /// <param name="contributorId">A contributor ID.</param>
        /// <exception cref="ArgumentOutOfRangeException"><em>contributorId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public void DeleteContributor(long contributorId)
        {
            Task.Run(async () => await DeleteContributorAsync(contributorId)).GetAwaiter().GetResult();
        }

        /// <summary>Deletes a contributor asynchronously.</summary>
        /// <param name="contributorId">A contributor ID.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>contributorId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task DeleteContributorAsync(long contributorId)
        {
            return DeleteContributorAsync(contributorId, CancellationToken.None);
        }

        /// <summary>Deletes a contributor asynchronously.</summary>
        /// <param name="contributorId">A contributor ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>contributorId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task DeleteContributorAsync(long contributorId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(contributorId, (long)0, nameof(contributorId));

            var request = new Rest.RestRequest("contributors/{contributorId}", Method.DELETE);
            request.AddUrlSegment("contributorId", contributorId);

            await ExecuteRequestAsync<object>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region GetContributor
        /// <summary>Loads a contributor.</summary>
        /// <param name="contributorId">A contributor ID.</param>
        /// <returns>The contributor.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>contributorId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Contributor GetContributor(long contributorId)
        {
            return Task.Run(async () => await GetContributorAsync(contributorId)).GetAwaiter().GetResult();
        }

        /// <summary>Loads a contributor asynchronously.</summary>
        /// <param name="contributorId">A contributor ID.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the contributor.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>contributorId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<Contributor> GetContributorAsync(long contributorId)
        {
            return GetContributorAsync(contributorId, CancellationToken.None);
        }

        /// <summary>Loads a contributor asynchronously.</summary>
        /// <param name="contributorId">A contributor ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the contributor.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>contributorId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<Contributor> GetContributorAsync(long contributorId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(contributorId, (long)0, nameof(contributorId));

            var request = new Rest.RestRequest("contributors/{contributorId}", Method.GET);
            request.AddUrlSegment("contributorId", contributorId);

            return await ExecuteRequestAsync<Contributor>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region GetContributors
        /// <summary>Loads all contributors for a podcast.</summary>
        /// <param name="podcastId">A podcast ID.</param>
        /// <returns>A list of all contributors.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public List<Contributor> GetContributors(long podcastId)
        {
            return Task.Run(async () => await GetContributorsAsync(podcastId)).GetAwaiter().GetResult();
        }

        /// <summary>Loads all contributors for a podcast asynchronously.</summary>
        /// <param name="podcastId">A podcast ID.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains a list of all contributors.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<List<Contributor>> GetContributorsAsync(long podcastId)
        {
            return GetContributorsAsync(podcastId, CancellationToken.None);
        }

        /// <summary>Loads all contributors for a podcast asynchronously.</summary>
        /// <param name="podcastId">A podcast ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains a list of all contributors.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<List<Contributor>> GetContributorsAsync(long podcastId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(podcastId, (long)0, nameof(podcastId));

            var request = new Rest.RestRequest("contributors", Method.GET);
            request.AddQueryParameter("podcast_id", podcastId.ToString());

            return await ExecuteRequestAsync<List<Contributor>>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region UpdateContributor
        /// <summary>Updates a contributor.</summary>
        /// <param name="contributor">A contributor to update.</param>
        /// <returns>The updated contributor.</returns>
        /// <exception cref="ArgumentNullException"><em>contributor</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Contributor UpdateContributor(Contributor contributor)
        {
            return Task.Run(async () => await UpdateContributorAsync(contributor)).GetAwaiter().GetResult();
        }

        /// <summary>Updates a contributor asynchronously.</summary>
        /// <param name="contributor">A contributor to update.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the updated contributor.</returns>
        /// <exception cref="ArgumentNullException"><em>contributor</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<Contributor> UpdateContributorAsync(Contributor contributor)
        {
            return UpdateContributorAsync(contributor, CancellationToken.None);
        }

        /// <summary>Updates a contributor asynchronously.</summary>
        /// <param name="contributor">A contributor to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the updated contributor.</returns>
        /// <exception cref="ArgumentNullException"><em>contributor</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<Contributor> UpdateContributorAsync(Contributor contributor, CancellationToken cancellationToken)
        {
            Precondition.IsNotNull(contributor, nameof(contributor));

            var request = new Rest.RestRequest("contributors/{contributorId}", Method.PUT);
            request.AddUrlSegment("contributorId", contributor.Id);
            request.AddJsonBody(contributor);

            return await ExecuteRequestAsync<Contributor>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion


        #region CreateEpisode
        /// <summary>Creates a new episode.</summary>
        /// <param name="episode">A episode to create.</param>
        /// <returns>The created episode.</returns>
        /// <exception cref="ArgumentNullException"><em>episode</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Episode CreateEpisode(Episode episode)
        {
            return Task.Run(async () => await CreateEpisodeAsync(episode)).GetAwaiter().GetResult();
        }

        /// <summary>Creates a new episode asynchronously.</summary>
        /// <param name="episode">A episode to create.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created episode.</returns>
        /// <exception cref="ArgumentNullException"><em>episode</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<Episode> CreateEpisodeAsync(Episode episode)
        {
            return CreateEpisodeAsync(episode, CancellationToken.None);
        }

        /// <summary>Creates a new episode asynchronously.</summary>
        /// <param name="episode">A episode to create.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created episode.</returns>
        /// <exception cref="ArgumentNullException"><em>episode</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<Episode> CreateEpisodeAsync(Episode episode, CancellationToken cancellationToken)
        {
            Precondition.IsNotNull(episode, nameof(episode));

            var request = new Rest.RestRequest("episodes", Method.POST);
            request.AddJsonBody(episode);

            return await ExecuteRequestAsync<Episode>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region DeleteEpisode
        /// <summary>Deletes a episode.</summary>
        /// <param name="episodeId">A episode ID.</param>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public void DeleteEpisode(long episodeId)
        {
            Task.Run(async () => await DeleteEpisodeAsync(episodeId)).GetAwaiter().GetResult();
        }

        /// <summary>Deletes a episode asynchronously.</summary>
        /// <param name="episodeId">A episode ID.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task DeleteEpisodeAsync(long episodeId)
        {
            return DeleteEpisodeAsync(episodeId, CancellationToken.None);
        }

        /// <summary>Deletes a episode asynchronously.</summary>
        /// <param name="episodeId">A episode ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task DeleteEpisodeAsync(long episodeId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(episodeId, (long)0, nameof(episodeId));

            var request = new Rest.RestRequest("episodes/{episodeId}", Method.DELETE);
            request.AddUrlSegment("episodeId", episodeId);

            await ExecuteRequestAsync<ChapterMark>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region GetEpisode
        /// <summary>Loads a episode.</summary>
        /// <param name="episodeId">A episode ID.</param>
        /// <returns>The episode.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Episode GetEpisode(long episodeId)
        {
            return Task.Run(async () => await GetEpisodeAsync(episodeId)).GetAwaiter().GetResult();
        }

        /// <summary>Loads a episode asynchronously.</summary>
        /// <param name="episodeId">A episode ID.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the episode.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<Episode> GetEpisodeAsync(long episodeId)
        {
            return GetEpisodeAsync(episodeId, CancellationToken.None);
        }

        /// <summary>Loads a episode asynchronously.</summary>
        /// <param name="episodeId">A episode ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the episode.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<Episode> GetEpisodeAsync(long episodeId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(episodeId, (long)0, nameof(episodeId));

            var request = new Rest.RestRequest("episodes/{episodeId}", Method.GET);
            request.AddUrlSegment("episodeId", episodeId);

            return await ExecuteRequestAsync<Episode>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region GetEpisodes
        /// <summary>Loads all episodes or all episodes.</summary>
        /// <returns>A list of all episodes.</returns>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public List<Episode> GetEpisodes()
        {
            return Task.Run(async () => await GetEpisodesAsync()).GetAwaiter().GetResult();
        }

        /// <summary>Loads all episodes or all episodes asynchronously.</summary>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains a list of all episodes.</returns>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<List<Episode>> GetEpisodesAsync()
        {
            return GetEpisodesAsync(CancellationToken.None);
        }

        /// <summary>Loads all episodes or all episodes asynchronously.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains a list of all episodes.</returns>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<List<Episode>> GetEpisodesAsync(CancellationToken cancellationToken)
        {
            var request = new Rest.RestRequest("episodes", Method.GET);

            return await ExecuteRequestAsync<List<Episode>>(cancellationToken, request, AuthenticatorType.OAuth2);
        }

        /// <summary>Loads all episodes or all episodes for a podcast.</summary>
        /// <param name="podcastId">A podcast ID.</param>
        /// <returns>A list of all episodes for a podcast.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public List<Episode> GetEpisodes(long podcastId)
        {
            return Task.Run(async () => await GetEpisodesAsync(podcastId)).GetAwaiter().GetResult();
        }

        /// <summary>Loads all episodes or all episodes for a podcast asynchronously.</summary>
        /// <param name="podcastId">A podcast ID.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains a list of all episodes for a podcast.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<List<Episode>> GetEpisodesAsync(long podcastId)
        {
            return GetEpisodesAsync(podcastId, CancellationToken.None);
        }

        /// <summary>Loads all episodes or all episodes for a podcast asynchronously.</summary>
        /// <param name="podcastId">A podcast ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains a list of all episodes for a podcast.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<List<Episode>> GetEpisodesAsync(long podcastId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(podcastId, (long)0, nameof(podcastId));

            var request = new Rest.RestRequest("episodes", Method.GET);
            request.AddQueryParameter("podcast_id", podcastId.ToString());

            return await ExecuteRequestAsync<List<Episode>>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region UpdateEpisode
        /// <summary>Updates a episode.</summary>
        /// <param name="episode">A episode to update.</param>
        /// <returns>The updated episode.</returns>
        /// <exception cref="ArgumentNullException"><em>episode</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Episode UpdateEpisode(Episode episode)
        {
            return Task.Run(async () => await UpdateEpisodeAsync(episode)).GetAwaiter().GetResult();
        }

        /// <summary>Updates a episode asynchronously.</summary>
        /// <param name="episode">A episode to update.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the updated episode.</returns>
        /// <exception cref="ArgumentNullException"><em>episode</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<Episode> UpdateEpisodeAsync(Episode episode)
        {
            return UpdateEpisodeAsync(episode, CancellationToken.None);
        }

        /// <summary>Updates a episode asynchronously.</summary>
        /// <param name="episode">A episode to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the updated episode.</returns>
        /// <exception cref="ArgumentNullException"><em>episode</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<Episode> UpdateEpisodeAsync(Episode episode, CancellationToken cancellationToken)
        {
            Precondition.IsNotNull(episode, nameof(episode));

            var request = new Rest.RestRequest("/episodes/{episodeId}", Method.PUT);
            request.AddUrlSegment("episodeId", episode.Id);
            request.AddJsonBody(episode);

            return await ExecuteRequestAsync<Episode>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion


        #region CreateMediaClip
        /// <summary>Creates a new media clip.</summary>
        /// <param name="mediaClip">A media clip to create.</param>
        /// <returns>The created media clip.</returns>
        /// <exception cref="ArgumentNullException"><em>mediaClip</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public MediaClip CreateMediaClip(MediaClip mediaClip)
        {
            return Task.Run(async () => await CreateMediaClipAsync(mediaClip)).GetAwaiter().GetResult();
        }

        /// <summary>Creates a new media clip asynchronously.</summary>
        /// <param name="mediaClip">A media clip to create.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created media clip.</returns>
        /// <exception cref="ArgumentNullException"><em>mediaClip</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<MediaClip> CreateMediaClipAsync(MediaClip mediaClip)
        {
            return CreateMediaClipAsync(mediaClip, CancellationToken.None);
        }

        /// <summary>Creates a new media clip asynchronously.</summary>
        /// <param name="mediaClip">A media clip to create.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created media clip.</returns>
        /// <exception cref="ArgumentNullException"><em>mediaClip</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<MediaClip> CreateMediaClipAsync(MediaClip mediaClip, CancellationToken cancellationToken)
        {
            Precondition.IsNotNull(mediaClip, nameof(mediaClip));

            var request = new Rest.RestRequest("media_clips", Method.POST);
            request.AddJsonBody(mediaClip);

            return await ExecuteRequestAsync<MediaClip>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region DeleteMediaClip
        /// <summary>Deletes a media clip.</summary>
        /// <param name="mediaClipId">A media clip ID.</param>
        /// <exception cref="ArgumentOutOfRangeException"><em>mediaClipId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public void DeleteMediaClip(long mediaClipId)
        {
            Task.Run(async () => await DeleteMediaClipAsync(mediaClipId)).GetAwaiter().GetResult();
        }

        /// <summary>Deletes a media clip asynchronously.</summary>
        /// <param name="mediaClipId">A media clip ID.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>mediaClipId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task DeleteMediaClipAsync(long mediaClipId)
        {
            return DeleteMediaClipAsync(mediaClipId, CancellationToken.None);
        }

        /// <summary>Deletes a media clip asynchronously.</summary>
        /// <param name="mediaClipId">A media clip ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>mediaClipId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task DeleteMediaClipAsync(long mediaClipId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(mediaClipId, (long)0, nameof(mediaClipId));

            var request = new Rest.RestRequest("media_clips/{mediaClipId}", Method.DELETE);
            request.AddUrlSegment("mediaClipId", mediaClipId);

            await ExecuteRequestAsync<object>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region GetMediaClip
        /// <summary>Loads a media clip.</summary>
        /// <param name="mediaClipId">A media clip ID.</param>
        /// <returns>The media clip.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>mediaClipId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public MediaClip GetMediaClip(long mediaClipId)
        {
            return Task.Run(async () => await GetMediaClipAsync(mediaClipId)).GetAwaiter().GetResult();
        }

        /// <summary>Loads a media clip asynchronously.</summary>
        /// <param name="mediaClipId">A media clip ID.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the media clip.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>mediaClipId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<MediaClip> GetMediaClipAsync(long mediaClipId)
        {
            return GetMediaClipAsync(mediaClipId, CancellationToken.None);
        }

        /// <summary>Loads a media clip asynchronously.</summary>
        /// <param name="mediaClipId">A media clip ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the media clip.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>mediaClipId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<MediaClip> GetMediaClipAsync(long mediaClipId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(mediaClipId, (long)0, nameof(mediaClipId));

            var request = new Rest.RestRequest("media_clips/{mediaClipId}", Method.GET);
            request.AddUrlSegment("mediaClipId", mediaClipId);

            return await ExecuteRequestAsync<MediaClip>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region GetMediaClips
        /// <summary>Loads all media clips for a episode.</summary>
        /// <param name="episodeId">A episode ID.</param>
        /// <returns>A list of media clips.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public List<MediaClip> GetMediaClips(long episodeId)
        {
            return Task.Run(async () => await GetMediaClipsAsync(episodeId)).GetAwaiter().GetResult();
        }

        /// <summary>Loads all media clips for a episode asynchronously.</summary>
        /// <param name="episodeId">A episode ID.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains a list of media clips.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<List<MediaClip>> GetMediaClipsAsync(long episodeId)
        {
            return GetMediaClipsAsync(episodeId, CancellationToken.None);
        }

        /// <summary>Loads all media clips for a episode asynchronously.</summary>
        /// <param name="episodeId">A episode ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains a list of media clips.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<List<MediaClip>> GetMediaClipsAsync(long episodeId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(episodeId, (long)0, nameof(episodeId));

            var request = new Rest.RestRequest("media_clips", Method.GET);
            request.AddQueryParameter("episode_id", episodeId.ToString());

            return await ExecuteRequestAsync<List<MediaClip>>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion


        #region CreatePodcast
        /// <summary>Creates a new podcast.</summary>
        /// <param name="podcast">A podcast to create.</param>
        /// <returns>The created podcast.</returns>
        /// <exception cref="ArgumentNullException"><em>podcast</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Podcast CreatePodcast(Podcast podcast)
        {
            return Task.Run(async () => await CreatePodcastAsync(podcast)).GetAwaiter().GetResult();
        }

        /// <summary>Creates a new podcast asynchronously.</summary>
        /// <param name="podcast">A podcast to create.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created podcast.</returns>
        /// <exception cref="ArgumentNullException"><em>podcast</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<Podcast> CreatePodcastAsync(Podcast podcast)
        {
            return CreatePodcastAsync(podcast, CancellationToken.None);
        }

        /// <summary>Creates a new podcast asynchronously.</summary>
        /// <param name="podcast">A podcast to create.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created podcast.</returns>
        /// <exception cref="ArgumentNullException"><em>podcast</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<Podcast> CreatePodcastAsync(Podcast podcast, CancellationToken cancellationToken)
        {
            Precondition.IsNotNull(podcast, nameof(podcast));

            var request = new Rest.RestRequest("podcasts", Method.POST);
            request.AddJsonBody(podcast);

            return await ExecuteRequestAsync<Podcast>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region DeletePodcast
        /// <summary>Deletes a podcast.</summary>
        /// <param name="podcastId">A podcast ID.</param>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public void DeletePodcast(long podcastId)
        {
            Task.Run(async () => await DeletePodcastAsync(podcastId)).GetAwaiter().GetResult();
        }

        /// <summary>Deletes a podcast asynchronously.</summary>
        /// <param name="podcastId">A podcast ID.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task DeletePodcastAsync(long podcastId)
        {
            return DeletePodcastAsync(podcastId, CancellationToken.None);
        }

        /// <summary>Deletes a podcast asynchronously.</summary>
        /// <param name="podcastId">A podcast ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task DeletePodcastAsync(long podcastId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(podcastId, (long)0, nameof(podcastId));

            var request = new Rest.RestRequest("podcasts/{podcastId}", Method.DELETE);
            request.AddUrlSegment("podcastId", podcastId);

            await ExecuteRequestAsync<ChapterMark>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region GetPodcast
        /// <summary>Loads a podcast.</summary>
        /// <param name="podcastId">A podcast ID.</param>
        /// <returns>The podcast.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Podcast GetPodcast(long podcastId)
        {
            return Task.Run(async () => await GetPodcastAsync(podcastId)).GetAwaiter().GetResult();
        }

        /// <summary>Loads a podcast asynchronously.</summary>
        /// <param name="podcastId">A podcast ID.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the podcast.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<Podcast> GetPodcastAsync(long podcastId)
        {
            return GetPodcastAsync(podcastId, CancellationToken.None);
        }

        /// <summary>Loads a podcast asynchronously.</summary>
        /// <param name="podcastId">A podcast ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the podcast.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>podcastId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<Podcast> GetPodcastAsync(long podcastId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(podcastId, (long)0, nameof(podcastId));

            var request = new Rest.RestRequest("podcasts/{podcastId}", Method.GET);
            request.AddUrlSegment("podcastId", podcastId);

            return await ExecuteRequestAsync<Podcast>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region GetPodcasts
        /// <summary>Loads all podcasts.</summary>
        /// <returns>A list of podcasts.</returns>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public List<Podcast> GetPodcasts()
        {
            return Task.Run(async () => await GetPodcastsAsync()).GetAwaiter().GetResult();
        }

        /// <summary>Loads all podcasts asynchronously.</summary>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains a list of podcasts.</returns>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<List<Podcast>> GetPodcastsAsync()
        {
            return GetPodcastsAsync(CancellationToken.None);
        }

        /// <summary>Loads all podcasts asynchronously.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains a list of podcasts.</returns>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<List<Podcast>> GetPodcastsAsync(CancellationToken cancellationToken)
        {
            var request = new Rest.RestRequest("podcasts", Method.GET);

            return await ExecuteRequestAsync<List<Podcast>>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region UpdatePodcast
        /// <summary>Updates a podcast.</summary>
        /// <param name="podcast">A podcast to update.</param>
        /// <returns>The updated podcast.</returns>
        /// <exception cref="ArgumentNullException"><em>podcast</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Podcast UpdatePodcast(Podcast podcast)
        {
            return Task.Run(async () => await UpdatePodcastAsync(podcast)).GetAwaiter().GetResult();
        }

        /// <summary>Updates a podcast asynchronously.</summary>
        /// <param name="podcast">A podcast to update.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the updated podcast.</returns>
        /// <exception cref="ArgumentNullException"><em>podcast</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<Podcast> UpdatePodcastAsync(Podcast podcast)
        {
            return UpdatePodcastAsync(podcast, CancellationToken.None);
        }

        /// <summary>Updates a podcast asynchronously.</summary>
        /// <param name="podcast">A podcast to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the updated podcast.</returns>
        /// <exception cref="ArgumentNullException"><em>podcast</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<Podcast> UpdatePodcastAsync(Podcast podcast, CancellationToken cancellationToken)
        {
            Precondition.IsNotNull(podcast, nameof(podcast));

            var request = new Rest.RestRequest("podcasts/{podcastId}", Method.PUT);
            request.AddUrlSegment("podcastId", podcast.Id);
            request.AddJsonBody(podcast);

            return await ExecuteRequestAsync<Podcast>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion


        #region CreateProduction
        /// <summary>Creates a new production.</summary>
        /// <param name="production">A production to create.</param>
        /// <returns>The created production.</returns>
        /// <exception cref="ArgumentNullException"><em>production</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Production CreateProduction(Production production)
        {
            return Task.Run(async () => await CreateProductionAsync(production)).GetAwaiter().GetResult();
        }

        /// <summary>Creates a new production asynchronously.</summary>
        /// <param name="production">A production to create.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created production.</returns>
        /// <exception cref="ArgumentNullException"><em>production</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<Production> CreateProductionAsync(Production production)
        {
            return CreateProductionAsync(production, CancellationToken.None);
        }

        /// <summary>Creates a new production asynchronously.</summary>
        /// <param name="production">A production to create.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created production.</returns>
        /// <exception cref="ArgumentNullException"><em>production</em> is <strong>null</strong>.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<Production> CreateProductionAsync(Production production, CancellationToken cancellationToken)
        {
            Precondition.IsNotNull(production, nameof(production));

            var request = new Rest.RestRequest("productions", Method.POST);
            request.AddJsonBody(production);

            return await ExecuteRequestAsync<Production>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region DeleteProduction
        /// <summary>Deletes a production.</summary>
        /// <param name="productionId">A production ID.</param>
        /// <exception cref="ArgumentOutOfRangeException"><em>productionId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public void DeleteProduction(long productionId)
        {
            Task.Run(async () => await DeleteProductionAsync(productionId)).GetAwaiter().GetResult();
        }

        /// <summary>Deletes a production asynchronously.</summary>
        /// <param name="productionId">A production ID.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>productionId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task DeleteProductionAsync(long productionId)
        {
            return DeleteProductionAsync(productionId, CancellationToken.None);
        }

        /// <summary>Deletes a production asynchronously.</summary>
        /// <param name="productionId">A production ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>productionId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task DeleteProductionAsync(long productionId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(productionId, (long)0, nameof(productionId));

            var request = new Rest.RestRequest("productions/{productionId}", Method.DELETE);
            request.AddUrlSegment("productionId", productionId);

            await ExecuteRequestAsync<object>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region GetProduction
        /// <summary>Loads a production.</summary>
        /// <param name="productionId">A production ID.</param>
        /// <returns>The production.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>productionId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Production GetProduction(long productionId)
        {
            return Task.Run(async () => await GetProductionAsync(productionId)).GetAwaiter().GetResult();
        }

        /// <summary>Loads a production asynchronously.</summary>
        /// <param name="productionId">A production ID.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the production.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>productionId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<Production> GetProductionAsync(long productionId)
        {
            return GetProductionAsync(productionId, CancellationToken.None);
        }

        /// <summary>Loads a production asynchronously.</summary>
        /// <param name="productionId">A production ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the production.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><em>productionId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<Production> GetProductionAsync(long productionId, CancellationToken cancellationToken)
        {
            Precondition.IsGreater(productionId, (long)0, nameof(productionId));

            var request = new Rest.RestRequest("productions/{productionId}", Method.GET);
            request.AddUrlSegment("productionId", productionId);

            return await ExecuteRequestAsync<Production>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion


        #region CreateTranscription
        /// <summary>Imports a new transcription.</summary>
        /// <param name="fileUrl">A URL of the file to be converted. Currently supported formats
        /// are: docx, srt, vtt.</param>
        /// <param name="episodeId">A episode ID.</param>
        /// <returns>he created transcription import.</returns>
        /// <exception cref="ArgumentException"><em>fileUrl</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>fileUrl</em> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public TranscriptionImport CreateTranscription(string fileUrl, long episodeId)
        {
            return Task.Run(async () => await CreateTranscriptionAsync(fileUrl, episodeId)).GetAwaiter().GetResult();
        }

        /// <summary>Imports a new transcription asynchronously.</summary>
        /// <param name="fileUrl">A URL of the file to be converted. Currently supported formats
        /// are: docx, srt, vtt.</param>
        /// <param name="episodeId">A episode ID.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created transcription import.</returns>
        /// <exception cref="ArgumentException"><em>fileUrl</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>fileUrl</em> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<TranscriptionImport> CreateTranscriptionAsync(string fileUrl, long episodeId)
        {
            return CreateTranscriptionAsync(fileUrl, episodeId, CancellationToken.None);
        }

        /// <summary>Imports a new transcription asynchronously.</summary>
        /// <param name="fileUrl">A URL of the file to be converted. Currently supported formats
        /// are: docx, srt, vtt.</param>
        /// <param name="episodeId">A episode ID.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the created transcription import.</returns>
        /// <exception cref="ArgumentException"><em>fileUrl</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>fileUrl</em> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><em>episodeId</em> is less then 1.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<TranscriptionImport> CreateTranscriptionAsync(string fileUrl, long episodeId, CancellationToken cancellationToken)
        {
            Precondition.IsNotNullOrWhiteSpace(fileUrl, nameof(fileUrl));
            Precondition.IsGreater(episodeId, (long)0, nameof(episodeId));

            var request = new Rest.RestRequest("transcription_imports", Method.POST);
            request.AddQueryParameter("file_url", Uri.EscapeDataString(fileUrl));
            request.AddQueryParameter("episode_id", episodeId.ToString());

            return await ExecuteRequestAsync<TranscriptionImport>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion

        #region UploadFile
        /// <summary>Uploads a file.</summary>
        /// <param name="filename">Path of the file to be uploaded.</param>
        /// <returns>The uploaded file.</returns>
        /// <exception cref="ArgumentException"><em>filename</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>filename</em> is <strong>null</strong>.</exception>
        /// <exception cref="System.IO.FileNotFoundException"><em>filename</em> don't exists.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Upload UploadFile(string filename)
        {
            return Task.Run(async () => await UploadFileAsync(filename)).GetAwaiter().GetResult();
        }

        /// <summary>Uploads a file asynchronously.</summary>
        /// <param name="filename">Path of the file to be uploaded.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the uploaded file.</returns>
        /// <exception cref="ArgumentException"><em>filename</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>filename</em> is <strong>null</strong>.</exception>
        /// <exception cref="System.IO.FileNotFoundException"><em>filename</em> don't exists.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public Task<Upload> UploadFileAsync(string filename)
        {
            return UploadFileAsync(filename, CancellationToken.None);
        }

        /// <summary>Uploads a file asynchronously.</summary>
        /// <param name="filename">Path of the file to be uploaded.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the
        /// <em>TResult</em> parameter contains the uploaded file.</returns>
        /// <exception cref="ArgumentException"><em>filename</em> is empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><em>filename</em> is <strong>null</strong>.</exception>
        /// <exception cref="System.IO.FileNotFoundException"><em>filename</em> don't exists.</exception>
        /// <exception cref="PodigeeException">A server side error occurred.</exception>
        public async Task<Upload> UploadFileAsync(string filename, CancellationToken cancellationToken)
        {
            Precondition.FileExists(filename);

            var request = new Rest.RestRequest("uploads", Method.POST);
            request.AddQueryParameter("filename", Uri.EscapeDataString(filename));

            return await ExecuteRequestAsync<Upload>(cancellationToken, request, AuthenticatorType.OAuth2);
        }
        #endregion


        #region Protected Methods
        /// <summary>
        /// Raises the <see cref="RecieveResponse"/> event.
        /// </summary>
        /// <param name="response"></param>
        protected virtual void OnRecieveResponse(IRestResponse response)
        {
            RecieveResponse?.Invoke(this, new RestResponseEventArgs(response));
        }

        /// <summary>
        /// Raises the <see cref="SendRequest"/> event.
        /// </summary>
        /// <param name="request"></param>
        protected virtual void OnSendRequest(IRestRequest request)
        {
            SendRequest?.Invoke(this, new RestRequestEventArgs(request));
        }
        #endregion

        #region Private Methods
        private async Task<T> ExecuteRequestAsync<T>(
            CancellationToken cancellationToken,
            IRestRequest request,
            AuthenticatorType authenticatorType = AuthenticatorType.None)
        {
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddHeader("Token", ApiToken);

            OnSendRequest(request);

            var serializer = (NewtonsoftJsonSerializer)request.JsonSerializer;
            var response = await _client.ExecuteTaskAsync(request, cancellationToken).ConfigureAwait(false);
            var result = default(T);

            OnRecieveResponse(response);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = serializer.Deserialize<T>(response.Content);
            }
            else
            {
                var error = serializer.Deserialize<Error>(response.Content);
                throw new PodigeeException(error.Code, error.Message);
            }

            return result;
        }
        #endregion
    }
}
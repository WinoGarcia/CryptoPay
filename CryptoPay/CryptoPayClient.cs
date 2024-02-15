using System;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CryptoPay.Extensions;
using CryptoPay.Requests.Base;
using CryptoPay.Responses;

namespace CryptoPay;

/// <inheritdoc />
public sealed class CryptoPayClient : ICryptoPayClient
{
    #region Constructors

    /// <summary>
    /// Create <see cref="ICryptoPayClient" /> instance.
    /// </summary>
    /// <param name="token">Your application token from CryptoPay.</param>
    /// <param name="httpClient">Optional. <see cref="HttpClient" />.</param>
    /// <param name="apiUrl">
    /// Optional. Default value is <see cref="DefaultCryptoBotApiUrl" /> main api url.
    /// Test api url is <code>https://testnet-pay.crypt.bot/</code>.
    /// </param>
    /// <exception cref="ArgumentNullException">If token is null.</exception>
    public CryptoPayClient(
        string token,
        HttpClient httpClient = null,
        string apiUrl = default)
    {
        this.token = string.IsNullOrEmpty(token)
            ? throw new ArgumentNullException(nameof(token))
            : token;

        this.httpClient = httpClient ?? new HttpClient();
        this.cryptoBotApiUrl = apiUrl ?? DefaultCryptoBotApiUrl;
        this.AppId = GetApplicationId(this.token);
    }

    #endregion

    #region Public Methods

    /// <inheritdoc />
    public async Task<TResponse> MakeRequestAsync<TResponse>(
        IRequest<TResponse> request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var url = $"{this.cryptoBotApiUrl}api/{request.MethodName}";

        using var httpRequest = new HttpRequestMessage(request.Method, url)
        {
            Content = request.ToHttpContent()
        };

        httpRequest.Headers.Add("Crypto-Pay-API-Token", this.token);

        using var httpResponse = await SendRequestAsync(
                this.httpClient,
                httpRequest,
                cancellationToken)
            .ConfigureAwait(false);

        if (httpResponse.StatusCode != HttpStatusCode.OK)
        {
            await httpResponse
                .DeserializeContentAsync<ApiResponseWithError>(response =>
                        response.Ok == false,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        var apiResponse = await httpResponse
            .DeserializeContentAsync<ApiResponse<TResponse>>(response =>
                    response.Ok == false ||
                    response.Result is null,
                cancellationToken)
            .ConfigureAwait(false);

        return apiResponse.Result!;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async Task<HttpResponseMessage> SendRequestAsync(
            HttpClient httpClient,
            HttpRequestMessage httpRequest,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await httpClient
                    .SendAsync(httpRequest, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (TaskCanceledException exception)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }

                throw new Exception("Request timed out", exception);
            }
            catch (Exception exception)
            {
                throw new Exception(
                    "Exception during making request",
                    exception
                );
            }

            return httpResponse;
        }
    }

    #endregion

    #region Public Fields

    /// <summary>
    /// Crypto Bot Api Url.
    /// </summary>
    private static string DefaultCryptoBotApiUrl { get; } = "https://pay.crypt.bot/";

    /// <inheritdoc />
    public long AppId { get; init; }

    #endregion

    #region Private Methods

    private static long GetApplicationId(string token)
    {
        ReadOnlySpan<char> dataAsSpan = token;
        var endInd = token.IndexOf(":", StringComparison.Ordinal);
        return long.Parse(dataAsSpan.Slice(0, endInd));
    }

    #endregion

    #region Private Fields

    private readonly HttpClient httpClient;
    private readonly string cryptoBotApiUrl;
    private readonly string token;

    #endregion
}
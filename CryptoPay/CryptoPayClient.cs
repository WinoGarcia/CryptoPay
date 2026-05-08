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
    #region Private Fields

    private readonly HttpClient httpClient;

    #endregion

    #region Constructors

    /// <summary>
    /// Create <see cref="ICryptoPayClient" /> instance.
    /// </summary>
    /// <param name="httpClient">
    /// <see cref="HttpClient"/> pre-configured with <see cref="HttpClient.BaseAddress"/> and a <c>Crypto-Pay-API-Token</c> default request header.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="httpClient"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <see cref="HttpClient.BaseAddress"/> is not set or the <c>Crypto-Pay-API-Token</c> header is missing.
    /// </exception>
    public CryptoPayClient(HttpClient httpClient)
    {
        ArgumentNullException.ThrowIfNull(httpClient);

        if (httpClient.BaseAddress is null)
        {
            throw new ArgumentException(
                "HttpClient.BaseAddress must be configured before passing to CryptoPayClient.",
                nameof(httpClient));
        }

        if (!httpClient.DefaultRequestHeaders.Contains("Crypto-Pay-API-Token"))
        {
            throw new ArgumentException(
                "HttpClient must have the 'Crypto-Pay-API-Token' default request header set.",
                nameof(httpClient));
        }

        this.httpClient = httpClient;
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

        var url = $"{this.httpClient.BaseAddress}api/{request.MethodName}";

        using HttpRequestMessage httpRequest = new(request.Method, url);
        httpRequest.Content = request.ToHttpContent();

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
}
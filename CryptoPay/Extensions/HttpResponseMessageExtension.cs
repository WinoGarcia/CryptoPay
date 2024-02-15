using System;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using CryptoPay.Exceptions;
using CryptoPay.Responses;
using CryptoPay.Types;

namespace CryptoPay.Extensions;

/// <summary>
/// HttpResponseMessage extension class.
/// </summary>
public static class HttpResponseMessageExtensions
{
    private static async Task<T> DeserializeJsonFromStreamAsync<T>(this Stream stream, CancellationToken cancellationToken)
        where T : class
    {
        if (stream is null || !stream.CanRead)
        {
            return default;
        }

        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
        };

        return await JsonSerializer.DeserializeAsync<T>(stream, options, cancellationToken);
    }

    /// <summary>
    /// Deserialize body from HttpContent into <typeparamref name="T" />.
    /// </summary>
    /// <param name="httpResponse"><see cref="HttpResponseMessage" /> instance.</param>
    /// <param name="guard"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T">Type of the resulting object.</typeparam>
    /// <returns></returns>
    /// <exception cref="RequestException">
    /// Thrown when body in the response can not be deserialized into <typeparamref name="T" />.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static async Task<T> DeserializeContentAsync<T>(
        this HttpResponseMessage httpResponse,
        Func<T, bool> guard,
        CancellationToken cancellationToken)
        where T : class
    {
        Stream contentStream = null;

        if (httpResponse.Content is null)
        {
            throw new RequestException(
                "Response doesn't contain any content",
                null,
                httpResponse.StatusCode
            );
        }

        try
        {
            T deserializedObject;
            try
            {
                contentStream = await httpResponse.Content
                    .ReadAsStreamAsync(cancellationToken)
                    .ConfigureAwait(false);

                deserializedObject = await contentStream
                    .DeserializeJsonFromStreamAsync<T>(cancellationToken);
            }
            catch (Exception exception)
            {
                throw CreateRequestException(
                    httpResponse,
                    exception: exception);
            }

            if (deserializedObject is null)
            {
                throw CreateRequestException(
                    httpResponse,
                    message: "Required properties not found in response");
            }

            if (guard(deserializedObject))
            {
                throw CreateRequestException(
                    httpResponse,
                    (deserializedObject as ApiResponseWithError)?.Error);
            }

            return deserializedObject;
        }
        finally
        {
            if (contentStream is not null)
            {
                await contentStream
                    .DisposeAsync()
                    .ConfigureAwait(false);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static RequestException CreateRequestException(
        HttpResponseMessage httpResponse,
        Error error = default,
        string message = default,
        Exception exception = default
    ) =>
        exception is null
            ? new RequestException(
                message,
                error,
                httpResponse.StatusCode
            )
            : new RequestException(
                exception.Message,
                httpResponse.StatusCode,
                exception
            );
}
using System.Text.Json.Serialization;
using CryptoPay.Types;

namespace CryptoPay.Responses;

/// <summary>
/// Response with <see cref="Error"/>.
/// </summary>
internal sealed class ApiResponseWithError : IResponse
{
    /// <summary>
    /// Initializes an instance of <see cref="ApiResponseWithError" />
    /// </summary>
    /// <param name="error">Instanse of <see cref="Error"/>.</param>
    public ApiResponseWithError(Error error)
    {
        this.Ok = false;
        this.Error = error;
    }

    [JsonConstructor]
    private ApiResponseWithError() {}

    /// <inheritdoc cref="IResponse.Ok"/>
    [JsonRequired]
    public bool Ok { get; init; }

    /// <summary>
    /// Instance of <see cref="Error"/>.
    /// </summary>
    [JsonRequired]
    public Error Error { get; init; }
}
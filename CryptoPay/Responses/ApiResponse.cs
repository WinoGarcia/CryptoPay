using System.Text.Json.Serialization;

namespace CryptoPay.Responses;

/// <summary>
///     Represents bot API response
/// </summary>
/// <typeparam name="TResult">Expected type of operation result</typeparam>
internal sealed class ApiResponse<TResult> : IResponse<TResult>
{
    /// <summary>
    ///     Initializes an instance of <see cref="ApiResponse{TResult}" />
    /// </summary>
    /// <param name="ok">Indicating whether the request was successful</param>
    /// <param name="result">Result object</param>
    public ApiResponse(
        bool ok,
        TResult result)
    {
        this.Ok = ok;
        this.Result = result;
    }

    [JsonConstructor]
    private ApiResponse() {}

    /// <inheritdoc />
    public bool Ok { get; init; }

    /// <inheritdoc />
    public TResult Result { get; init; }
}
namespace CryptoPay.Responses;

/// <inheritdoc />
public interface IResponse<TResult> : IResponse
{
    /// <summary>
    /// Gets the result object.
    /// </summary>
    public TResult Result { get; init; }
}
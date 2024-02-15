using CryptoPay.Requests.Base;

namespace CryptoPay.Requests;

/// <summary>
/// Use this request to delete checks created by your app. Returns True on success.
/// </summary>
public sealed class DeleteCheckRequest : ParameterlessRequest<bool>
{
    #region Constructors

    /// <summary>
    /// Initializes a new request delete checks created by your app.
    /// </summary>
    /// <param name="checkId">Check ID to be deleted.</param>
    public DeleteCheckRequest(long checkId)
        : base("deleteCheck")
    {
        this.CheckId = checkId;
    }

    #endregion

    #region Public Fields

    /// <summary>
    /// Unique ID for this check.
    /// </summary>
    public long CheckId { get; private set; }

    #endregion
}
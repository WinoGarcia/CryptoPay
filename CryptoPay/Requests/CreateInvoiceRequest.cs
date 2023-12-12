using System.Text.Json.Serialization;
using CryptoPay.Requests.Base;
using CryptoPay.Types;

namespace CryptoPay.Requests;

/// <summary>
///     Use this class to create <see cref="Invoice"/> request.
/// </summary>
public sealed class CreateInvoiceRequest
    : ParameterlessRequest<Invoice>,
        IInvoice
{
    #region Constructors

    /// <summary>
    ///     Initializes a new request to create <see cref="Invoice"/>
    /// </summary>
    /// <param name="asset">Currency code. Supported assets: <see cref="Assets" />.</param>
    /// <param name="amount">Amount of the invoice in float. For example: 125.50</param>
    /// <param name="description">Optional. Description for the invoice. User will see this description when they pay the invoice. Up to 1024 characters.</param>
    /// <param name="hiddenMessage">Optional. Text of the message that will be shown to a user after the invoice is paid. Up to 2048 characters.</param>
    /// <param name="paidBtnName">Optional. Name of the button that will be shown to a user after the invoice is paid. <see cref="PaidButtonNames" /></param>
    /// <param name="paidBtnUrl">
    ///     Optional. Required if <see cref="PaidButtonNames">paidBtnName</see> is used. URL to be opened when the button is pressed.
    ///     You can set any success link (for example, a link to your bot). Starts with https or http.
    /// </param>
    /// <param name="payload">Optional.Any data you want to attach to the invoice (for example, user ID, payment ID, ect). Up to 4kb.</param>
    /// <param name="allowComments">Optional. Allow a user to add a comment to the payment. Default is true.</param>
    /// <param name="allowAnonymous">Optional. Allow a user to pay the invoice anonymously. Default is <c>true</c>.</param>
    /// <param name="expiresIn">You can set a payment time limit for the invoice in <b>seconds</b>. Values between 1-2678400 are accepted.</param>
    public CreateInvoiceRequest(
        Assets asset,
        double amount,
        string description = default,
        string hiddenMessage = default,
        PaidButtonNames? paidBtnName = default,
        string paidBtnUrl = default,
        string payload = default,
        bool allowComments = true,
        bool allowAnonymous = true,
        long expiresIn = default)
        : base("createInvoice")
    {
        this.Asset = asset;
        this.Amount = amount;
        this.Description = description;
        this.HiddenMessage = hiddenMessage;
        this.PaidBtnName = paidBtnName;
        this.PaidBtnUrl = paidBtnUrl;
        this.Payload = payload;
        this.AllowComments = allowComments;
        this.AllowAnonymous = allowAnonymous;
        this.ExpiresIn = expiresIn;
    }

    #endregion

    #region Public Fields

    /// <inheritdoc />
    [JsonRequired]
    public Assets Asset { get; set; }

    /// <inheritdoc />
    [JsonRequired]
    public double Amount { get; set; }

    /// <inheritdoc />
    public string Description { get; set; }

    /// <inheritdoc />
    public string HiddenMessage { get; set; }

    /// <inheritdoc />
    public PaidButtonNames? PaidBtnName { get; set; }

    /// <inheritdoc />
    public string PaidBtnUrl { get; set; }

    /// <inheritdoc />
    public string Payload { get; set; }

    /// <inheritdoc />
    public bool? AllowComments { get; set; }

    /// <summary>
    ///     Optional. Allow a user to pay the invoice anonymously. Default is true.
    /// </summary>
    public bool? AllowAnonymous { get; set; }

    /// <summary>
    ///     Optional. You can set a payment time limit for the invoice in seconds. Values between 1-2678400 are accepted.
    /// </summary>
    public long ExpiresIn { get; set; }

    #endregion
}
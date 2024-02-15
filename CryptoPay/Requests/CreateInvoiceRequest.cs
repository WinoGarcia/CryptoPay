using System.Collections.Generic;
using System.Text.Json.Serialization;
using CryptoPay.Requests.Base;
using CryptoPay.Types;

namespace CryptoPay.Requests;

/// <summary>
/// Use this class to create <see cref="Invoice"/> request.
/// </summary>
public sealed class CreateInvoiceRequest
    : ParameterlessRequest<Invoice>,
        IInvoice
{
    #region Constructors

    /// <summary>
    /// Initializes a new request to create <see cref="Invoice"/>
    /// </summary>
    /// <param name="amount">Amount of the invoice in float. For example: 125.50</param>
    /// <param name="currencyType">Optional. Type of the price, can be <see cref="CurrencyTypes.crypto"/> or <see cref="CurrencyTypes.fiat"/>. Defaults to crypto.</param>
    /// <param name="asset">Currency code. Supported assets: <see cref="Assets" />.</param>
    /// <param name="fiat">Optional. Required if currencyType is <see cref="CurrencyTypes.fiat"/>. Fiat currency code. Supported fiat currencies from <see cref="Assets"/></param>
    /// <param name="acceptedAssets">
    /// Optional. List of cryptocurrency alphabetic codes. Assets which can be used to pay the invoice.
    /// Available only if currencyType is <see cref="CurrencyTypes.fiat"/>. Supported assets from <see cref="Assets"/>.
    /// Defaults to all currencies.
    /// </param>
    /// <param name="description">Optional. Description for the invoice. User will see this description when they pay the invoice. Up to 1024 characters.</param>
    /// <param name="hiddenMessage">Optional. Text of the message that will be shown to a user after the invoice is paid. Up to 2048 characters.</param>
    /// <param name="paidBtnName">Optional. Name of the button that will be shown to a user after the invoice is paid. <see cref="PaidButtonNames" /></param>
    /// <param name="paidBtnUrl">
    /// Optional. Required if <see cref="PaidButtonNames">paidBtnName</see> is used. URL to be opened when the button is pressed.
    /// You can set any success link (for example, a link to your bot). Starts with https or http.
    /// </param>
    /// <param name="payload">Optional.Any data you want to attach to the invoice (for example, user ID, payment ID, ect). Up to 4kb.</param>
    /// <param name="allowComments">Optional. Allow a user to add a comment to the payment. Default is true.</param>
    /// <param name="allowAnonymous">Optional. Allow a user to pay the invoice anonymously. Default is <c>true</c>.</param>
    /// <param name="expiresIn">You can set a payment time limit for the invoice in <b>seconds</b>. Values between 1-2678400 are accepted.</param>
    public CreateInvoiceRequest(
        double amount,
        CurrencyTypes currencyType = CurrencyTypes.crypto,
        Assets? asset = default,
        Assets? fiat = default,
        IEnumerable<Assets> acceptedAssets = default,
        string description = default,
        string hiddenMessage = default,
        PaidButtonNames? paidBtnName = default,
        string paidBtnUrl = default,
        string payload = default,
        bool allowComments = true,
        bool allowAnonymous = true,
        int expiresIn = 2678400)
        : base("createInvoice")
    {
        this.CurrencyType = currencyType;
        this.Amount = amount;
        this.Asset = asset;
        this.Fiat = fiat;
        this.AcceptedAssets = acceptedAssets;
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
    public Assets? Asset { get; set; }

    /// <inheritdoc />
    public Assets? Fiat { get; set; }

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

    /// <inheritdoc />
    [JsonRequired]
    public CurrencyTypes CurrencyType { get; set; }

    /// <inheritdoc />
    public IEnumerable<Assets> AcceptedAssets { get; set; }

    /// <summary>
    /// Optional. Allow a user to pay the invoice anonymously. Default is true.
    /// </summary>
    public bool? AllowAnonymous { get; set; }

    /// <summary>
    /// Optional. You can set a payment time limit for the invoice in seconds. Values between 1-2678400 are accepted.
    /// </summary>
    public int ExpiresIn { get; set; }

    #endregion
}
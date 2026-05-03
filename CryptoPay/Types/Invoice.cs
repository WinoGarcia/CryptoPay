using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoPay.Types;

/// <inheritdoc />
public sealed class Invoice : IInvoice
{
    /// <summary>
    /// Unique ID for this invoice.
    /// </summary>
    [JsonRequired]
    public long InvoiceId { get; set; }

    /// <summary>
    /// Status of the invoice, can be either “active”, “paid” or “expired”.
    /// </summary>
    [JsonRequired]
    public Statuses Status { get; set; }

    /// <summary>
    /// Hash of the invoice.
    /// </summary>
    [JsonRequired]
    public string Hash { get; set; }

    /// <summary>
    /// URL should be presented to the user to pay the invoice.
    /// </summary>
    [Obsolete("The field PayUrl is now deprecated, use the new field BotInvoiceUrl instead")]
    public string PayUrl { get; set; }

    /// <summary>
    /// Date the invoice was created in ISO 8601 format.
    /// </summary>
    [JsonRequired]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// True, if the user can pay the invoice anonymously.
    /// </summary>
    public bool? AllowAnonymous { get; set; }

    /// <summary>
    /// Optional. Date the invoice expires in Unix time.
    /// </summary>
    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    /// Optional. Date the invoice was paid in Unix time.
    /// </summary>
    public DateTime? PaidAt { get; set; }

    /// <summary>
    /// True, if the invoice was paid anonymously.
    /// </summary>
    public bool? PaidAnonymously { get; set; }

    /// <summary>
    /// Optional. Comment to the payment from the user.
    /// </summary>
    public string Comment { get; set; }

    /// <inheritdoc />
    public string Asset { get; set; }

    /// <inheritdoc />
    [JsonRequired]
    public double Amount { get; set; }

    /// <inheritdoc />
    public string SwapTo { get; set; }

    /// <summary>
    /// Optional. For invoices with the <see cref="Statuses.paid"/> status, this flag indicates whether the swap was successful (only applicable if <see cref="SwapTo"/> is set).
    /// </summary>
    public bool? IsSwapped { get; set; }

    /// <summary>
    /// Optional. If <see cref="IsSwapped"/> is <see langword="true"/>, stores the unique identifier of the swap.
    /// </summary>
    public string SwappedUid { get; set; }

    /// <summary>
    /// Optional. If <see cref="IsSwapped"/> is <see langword="true"/>, stores the asset into which the swap was made.
    /// </summary>
    public string SwappedTo { get; set; }

    /// <summary>
    /// Optional. If <see cref="IsSwapped"/> is <see langword="true"/>, stores the exchange rate at which the swap was executed.
    /// </summary>
    public string SwappedRate { get; set; }

    /// <summary>
    /// Optional. If <see cref="IsSwapped"/> is <see langword="true"/>, stores the amount received as a result of the swap (in the <see cref="SwappedTo"/> asset).
    /// </summary>
    public string SwappedOutput { get; set; }

    /// <summary>
    /// Optional. If <see cref="IsSwapped"/> is <see langword="true"/>, stores the resulting swap amount in USD.
    /// </summary>
    public string SwappedUsdAmount { get; set; }

    /// <summary>
    /// Optional. If <see cref="IsSwapped"/> is <see langword="true"/>, stores the USD exchange rate of the currency from <see cref="SwappedTo"/>.
    /// </summary>
    public string SwappedUsdRate { get; set; }

    /// <inheritdoc />
    public string Description { get; set; }

    /// <inheritdoc />
    public bool? AllowComments { get; set; }

    /// <inheritdoc />
    public string HiddenMessage { get; set; }

    /// <inheritdoc />
    public string Payload { get; set; }

    /// <inheritdoc />
    public PaidButtonNames? PaidBtnName { get; set; }

    /// <inheritdoc />
    public string PaidBtnUrl { get; set; }

    /// <inheritdoc />
    public CurrencyTypes CurrencyType { get; set; }

    /// <inheritdoc />
    public IEnumerable<string> AcceptedAssets { get; set; }

    /// <summary>
    /// Optional. Amount of charged service fees.
    /// </summary>
    [Obsolete("The field Fee in the Webhook update payload is now deprecated, use the new field FeeAmount instead")]
    public string Fee { get; set; }

    /// <summary>
    /// Optional. Price of the asset in USD at the time the invoice was paid.
    /// </summary>
    [Obsolete("The field UsdRate in the Webhook update payload is now deprecated, use the new field PaidUsdRate instead")]
    public string UsdRate { get; set; }

    /// <summary>
    /// URL should be provided to the user to pay the invoice.
    /// </summary>
    [JsonRequired]
    public string BotInvoiceUrl { get; set; }

    /// <summary>
    /// Optional. Price of the asset in USD. Available only if status is <see cref="Statuses.paid"/>.
    /// </summary>
    public string PaidUsdRate { get; set; }

    /// <summary>
    /// Optional. Amount of service fees charged when the invoice was paid.
    /// Available only if status is <see cref="Statuses.paid"/>.
    /// </summary>
    public double FeeAmount { get; set; }

    /// <summary>
    /// Optional. Fiat currency code. Available only if the value of the field <see cref="CurrencyType"/> is <see cref="CurrencyTypes.fiat"/>.
    /// Currently one of fiat from assets.
    /// </summary>
    public string Fiat { get; set; }

    /// <summary>
    /// Optional. Cryptocurrency alphabetic code for which the invoice was paid.
    /// Available only if <see cref="CurrencyType"/> is <see cref="CurrencyTypes.fiat"/> and status is <see cref="Statuses.paid"/>.
    /// </summary>
    public string PaidAsset { get; set; }

    /// <summary>
    /// Optional. Amount of the invoice for which the invoice was paid.
    /// Available only if <see cref="CurrencyType"/> is <see cref="CurrencyTypes.fiat"/> and status is <see cref="Statuses.paid"/>.
    /// </summary>
    public string PaidAmount { get; set; }

    /// <summary>
    /// Optional. The rate of the paid_asset valued in the fiat currency.
    /// Available only if the value of the field <see cref="CurrencyType"/> is <see cref="CurrencyTypes.fiat"/> and the value of the field status is <see cref="Statuses.paid"/>.
    /// </summary>
    public string PaidFiatRate { get; set; }

    /// <summary>
    /// Optional. Asset of service fees charged when the invoice was paid.
    /// Available only if status is <see cref="Statuses.paid"/>.
    /// </summary>
    public string FeeAsset { get; set; }

    /// <summary>
    /// Use this URL to pay an invoice to the Telegram Mini App version.
    /// </summary>
    [JsonRequired]
    public string MiniAppInvoiceUrl { get; set; }

    /// <summary>
    /// Use this URL to pay an invoice to the Web version of Crypto Bot.
    /// </summary>
    [JsonRequired]
    public string WebAppInvoiceUrl { get; set; }
}
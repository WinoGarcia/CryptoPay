using System;
using System.Text.Json.Serialization;

namespace CryptoPay.Types;

/// <inheritdoc />
public sealed class Invoice : IInvoice
{
    /// <summary>
    ///     Unique ID for this invoice.
    /// </summary>
    [JsonRequired]
    public long InvoiceId { get; set; }

    /// <summary>
    ///     Status of the invoice, can be either “active”, “paid” or “expired”.
    /// </summary>
    [JsonRequired]
    public Statuses Status { get; set; }

    /// <summary>
    ///     Hash of the invoice.
    /// </summary>
    [JsonRequired]
    public string Hash { get; set; }

    /// <summary>
    ///     URL should be presented to the user to pay the invoice.
    /// </summary>
    [JsonRequired]
    public string PayUrl { get; set; }

    /// <summary>
    ///     Date the invoice was created in ISO 8601 format.
    /// </summary>
    [JsonRequired]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     True, if the user can pay the invoice anonymously.
    /// </summary>

    public bool? AllowAnonymous { get; set; }

    /// <summary>
    ///     Optional. Date the invoice expires in Unix time.
    /// </summary>

    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    ///     Optional. Date the invoice was paid in Unix time.
    /// </summary>

    public DateTime? PaidAt { get; set; }

    /// <summary>
    ///     True, if the invoice was paid anonymously.
    /// </summary>

    public bool? PaidAnonymously { get; set; }

    /// <summary>
    ///     Optional. Comment to the payment from the user.
    /// </summary>

    public string Comment { get; set; }

    /// <inheritdoc />
    [JsonRequired]
    public Assets Asset { get; set; }

    /// <inheritdoc />
    [JsonRequired]
    public double Amount { get; set; }

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

    /// <summary>
    ///     Optional. Amount of charged service fees.
    /// </summary>

    public string Fee { get; set; }

    /// <summary>
    ///     Optional. Price of the asset in USD at the time the invoice was paid.
    /// </summary>

    public string UsdRate { get; set; }
}
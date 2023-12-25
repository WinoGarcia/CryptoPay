using System.Collections.Generic;
using System.Text.Json.Serialization;
using CryptoPay.Requests.Base;
using CryptoPay.Types;

namespace CryptoPay.Requests;

/// <summary>
///     Use this class to get <see cref="Invoices"/> request.
/// </summary>
internal sealed class GetInvoicesRequest : ParameterlessRequest<Invoices>
{
    #region Constructors

    /// <summary>
    ///     Initializes a new request to get <see cref="Invoices"/>
    /// </summary>
    /// <param name="assets">Optional. Currency codes. Supported assets: <see cref="Assets" /></param>
    /// <param name="invoiceIds">Optional. Invoice IDs.</param>
    /// <param name="status">Optional. Status of invoices to be returned. Available statuses: <see cref="Statuses.active"/> and <see cref="Statuses.paid"/>. Defaults to all statuses.</param>
    /// <param name="offset">Optional. Offset needed to return a specific subset of invoices. Default is 0.</param>
    /// <param name="count">Optional. Number of invoices to be returned. Values between 1-1000 are accepted. Defaults to 100.</param>
    public GetInvoicesRequest(
        IEnumerable<Assets> assets = default,
        IEnumerable<long> invoiceIds = default,
        Statuses? status = default,
        int offset = 0,
        int count = 100)
        : base("getInvoices")
    {
        this.Assets = assets;
        this.InvoiceIds = invoiceIds;
        this.Status = status;
        this.Offset = offset;
        this.Count = count;
    }

    #endregion

    /// <summary>
    ///     Optional. Currency codes.
    ///     Supported assets: <see cref="Assets"/>.
    ///     Defaults to all assets.
    /// </summary>
    public IEnumerable<Assets> Assets { get; set; }

    /// <summary>
    ///     Optional. Invoice IDs.
    /// </summary>
    public IEnumerable<long> InvoiceIds { get; set; }

    /// <summary>
    ///     Optional. Status of invoices to be returned. Available statuses: <see cref="Statuses"/>.
    ///     Defaults to all statuses.
    /// </summary>
    public Statuses? Status { get; set; }

    /// <summary>
    ///     Optional. Offset needed to return a specific subset of invoices.
    ///     Default is 0.
    /// </summary>
    [JsonRequired]
    public int Offset { get; set; }

    /// <summary>
    ///     Optional. Number of invoices to be returned. Values between 1-1000 are accepted.
    ///     Defaults to 100.
    /// </summary>
    [JsonRequired]
    public int Count { get; set; }
}
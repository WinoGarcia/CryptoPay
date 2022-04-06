﻿using CryptoPay.Requests.Base;
using CryptoPay.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Requests;

/// <summary>
///     Use this class to get <see cref="Invoices"/> request.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetInvoicesRequest : ParameterlessRequest<Invoices>
{
    #region Constructors

    /// <summary>
    ///     Initializes a new request to get <see cref="Invoices"/>
    /// </summary>
    /// <param name="assets">Optional. Currency codes separated by comma. Supported assets: <see cref="Assets" /></param>
    /// <param name="invoiceIds">Optional. Invoice IDs separated by comma.</param>
    /// <param name="status">Optional. Status of invoices to be returned. Available statuses: “active” and “paid”. Defaults to all statuses.</param>
    /// <param name="offset">Optional. Offset needed to return a specific subset of invoices. Default is 0.</param>
    /// <param name="count">Optional. Number of invoices to be returned. Values between 1-1000 are accepted. Defaults to 100.</param>
    public GetInvoicesRequest(
        string assets = default,
        string invoiceIds = default,
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
    ///     Optional. Currency codes separated by comma.
    ///     Supported assets: <see cref="Assets"/>.
    ///     Defaults to all assets.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Assets { get; set; }

    /// <summary>
    ///     Optional. Invoice IDs separated by comma.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string InvoiceIds { get; set; }

    /// <summary>
    ///     Optional. Status of invoices to be returned. Available statuses: “active” and “paid”.
    ///     Defaults to all statuses.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Statuses? Status { get; set; }

    /// <summary>
    ///     Optional. Offset needed to return a specific subset of invoices.
    ///     Default is 0.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int Offset { get; set; }

    /// <summary>
    ///     Optional. Number of invoices to be returned. Values between 1-1000 are accepted.
    ///     Defaults to 100.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int Count { get; set; }
}
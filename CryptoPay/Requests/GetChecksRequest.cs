using System.Collections.Generic;
using CryptoPay.Requests.Base;
using CryptoPay.Types;

namespace CryptoPay.Requests;

/// <summary>
/// Use this request to get checks created by your app. On success, returns array of <see cref="Check"/>.
/// </summary>
public sealed class GetChecksRequest : ParameterlessRequest<Checks>
{
    #region Constructors

    /// <summary>
    /// Initializes a new request to get list of <see cref="Check"/>
    /// </summary>
    /// <param name="assets">Optional. Cryptocurrency alphabetic code. Supported assets: <see cref="Assets"/>. Defaults to all currencies.</param>
    /// <param name="checkIds">Optional. List of check IDs.</param>
    /// <param name="statuses">Optional. Status of check to be returned. Available statuses: <see cref="CheckStatus"/>. Defaults to all statuses.</param>
    /// <param name="offset">Optional. Offset needed to return a specific subset of check. Defaults to 0.</param>
    /// <param name="count">Optional. Number of check to be returned. Values between 1-1000 are accepted. Defaults to 100.</param>
    public GetChecksRequest(
        IEnumerable<Assets> assets = default,
        IEnumerable<long> checkIds = default,
        IEnumerable<Statuses> statuses = default,
        int offset = 0,
        int count = 100)
        : base("getChecks")
    {
        this.Assets = assets;
        this.CheckIds = checkIds;
        this.Statuses = statuses;
        this.Offset = offset;
        this.Count = count;
    }

    #endregion

    #region Public Fields

    /// <summary>
    /// Optional. Cryptocurrency alphabetic code. Supported crypto from <see cref="Assets"/>. Defaults to all currencies.
    /// </summary>
    public IEnumerable<Assets> Assets { get; private set; }

    /// <summary>
    /// Optional. List of check IDs.
    /// </summary>
    public IEnumerable<long> CheckIds { get; private set; }

    /// <summary>
    /// Optional. Offset needed to return a specific subset of check. Defaults to 0.
    /// </summary>
    public IEnumerable<Statuses> Statuses { get; private set; }

    /// <summary>
    /// Optional. Offset needed to return a specific subset of check. Defaults to 0.
    /// </summary>
    public int Offset { get; private set; }

    /// <summary>
    /// Optional. Number of check to be returned. Values between 1-1000 are accepted. Defaults to 100.
    /// </summary>
    public int Count { get; private set; }

    #endregion
}
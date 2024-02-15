using System.Collections.Generic;
using CryptoPay.Requests.Base;
using CryptoPay.Types;

namespace CryptoPay.Requests;

/// <summary>
///  Use this class to get list of <see cref="Transfer"/> request.
/// </summary>
public sealed class GetTransfersRequest : ParameterlessRequest<Transfers>
{
    #region Constructors

    /// <summary>
    /// Initializes a new request to get list of <see cref="Transfer"/>
    /// </summary>
    /// <param name="asset">Optional. Cryptocurrency alphabetic code. Supported crypto from <see cref="Assets"/>. Defaults to all currencies.</param>
    /// <param name="transferIds">Optional. List of transfer IDs.</param>
    /// <param name="offset">Optional. Offset needed to return a specific subset of transfers. Defaults to 0.</param>
    /// <param name="count">Optional. Number of transfers to be returned. Values between 1-1000 are accepted. Defaults to 100.</param>
    public GetTransfersRequest(
        IEnumerable<Assets> asset = default,
        IEnumerable<string> transferIds = default,
        int offset = 0,
        int count = 100)
        : base("getTransfers")
    {
        this.Asset = asset;
        this.TransferIds = transferIds;
        this.Offset = offset;
        this.Count = count;
    }

    #endregion

    #region Public Fields

    /// <summary>
    /// Optional. Cryptocurrency alphabetic code. Supported crypto from <see cref="Asset"/>. Defaults to all currencies.
    /// </summary>
    public IEnumerable<Assets> Asset { get; private set; }

    /// <summary>
    /// Optional. List of transfer IDs.
    /// </summary>
    public IEnumerable<string> TransferIds { get; private set; }

    /// <summary>
    /// Optional. Offset needed to return a specific subset of transfers. Defaults to 0.
    /// </summary>
    public int Offset { get; private set; }

    /// <summary>
    /// Optional. Number of transfers to be returned. Values between 1-1000 are accepted. Defaults to 100.
    /// </summary>
    public int Count { get; private set; }

    #endregion
}
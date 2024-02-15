using System;
using System.Text.Json.Serialization;

namespace CryptoPay.Types;

/// <inheritdoc />
public sealed class Transfer : ITransfer
{
    /// <summary>
    /// Unique ID for this transfer.
    /// </summary>
    [JsonRequired]
    public long TransferId { get; set; }

    /// <inheritdoc/>
    [JsonRequired]
    public long UserId { get; set; }

    /// <inheritdoc/>
    [JsonRequired]
    public Assets Asset { get; set; }

    /// <inheritdoc/>
    [JsonRequired]
    public double Amount { get; set; }

    /// <summary>
    /// Status of the transfer, can be “completed”.
    /// </summary>
    [JsonRequired]
    public TransferStatuses Status { get; set; }

    /// <summary>
    /// Date the transfer was completed in ISO 8601 format.
    /// </summary>
    [JsonRequired]
    public DateTime CompletedAt { get; set; }

    /// <inheritdoc/>

    public string Comment { get; set; }
}
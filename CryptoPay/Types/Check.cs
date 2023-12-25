using System;
using System.Text.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
///     This class have to manage checks by using the app.
/// </summary>
public sealed class Check
{
    #region Public Fields

    /// <summary>
    ///     Unique ID for this check.
    /// </summary>
    [JsonRequired]
    public long CheckId { get; set; }

    /// <summary>
    ///     Hash of the check.
    /// </summary>
    [JsonRequired]
    public string Hash { get; set; }

    /// <summary>
    ///     Cryptocurrency alphabetic code. Currently, can be one of <see cref="Assets"/>.
    /// </summary>
    [JsonRequired]
    public Assets Asset { get; set; }

    /// <summary>
    ///     Amount of the check in float.
    /// </summary>
    [JsonRequired]
    public double Amount { get; set; }

    /// <summary>
    ///     URL should be provided to the user to activate the check.
    /// </summary>
    [JsonRequired]
    public string BotCheckUrl { get; set; }

    /// <summary>
    ///     Status of the check, can be <see cref="CheckStatus.active"/> or <see cref="CheckStatus.activated"/>.
    /// </summary>
    [JsonRequired]
    public CheckStatus Status { get; set; }

    /// <summary>
    ///     Date the check was created in ISO 8601 format.
    /// </summary>
    [JsonRequired]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     Date the check was activated in ISO 8601 format.
    /// </summary>
    public DateTime ActivatedAt { get; set; }

    #endregion
}
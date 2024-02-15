using System.Text.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
/// Supported currencies.
/// </summary>
public sealed class Currency
{
    /// <summary>
    /// Is blockchain.
    /// </summary>
    [JsonRequired]
    public bool IsBlockchain { get; set; }

    /// <summary>
    /// Is stablecoin.
    /// </summary>
    [JsonRequired]
    // ReSharper disable once IdentifierTypo
    public bool IsStablecoin { get; set; }

    /// <summary>
    /// Ordinary currency.
    /// </summary>
    [JsonRequired]
    public bool IsFiat { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    [JsonRequired]
    public string Name { get; set; }

    /// <summary>
    /// Code.
    /// </summary>
    [JsonRequired]
    public string Code { get; set; }

    /// <summary>
    /// Url.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Number of decimal places. 
    /// </summary>
    [JsonRequired]
    public int Decimals { get; set; }
}
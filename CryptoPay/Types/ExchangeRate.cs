using System.Text.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
///     Exchange rates of supported currencies.
/// </summary>
public sealed class ExchangeRate
{
    /// <summary>
    ///     Is valid.
    /// </summary>
    [JsonRequired]
    public bool IsValid { get; set; }

    /// <summary>
    /// Suurce currency.
    /// </summary>
    [JsonRequired]
    public Assets Source { get; set; }

    /// <summary>
    ///     Target currency. 
    /// </summary>
    [JsonRequired]
    public Assets Target { get; set; }

    /// <summary>
    ///     Exchange rate.
    /// </summary>
    [JsonRequired]
    public double Rate { get; set; }
}
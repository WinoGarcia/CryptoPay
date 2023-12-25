using System.Text.Json.Serialization;

#pragma warning disable CS1591
namespace CryptoPay.Types;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
/// <summary>
///     Available crypto currencies.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Assets
{
    // Crypto
    BTC,
    TON,
    ETH,
    BNB,
    USDT,
    USDC,
    TRX,
    LTC,
    JET
}
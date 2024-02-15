using System.Text.Json.Serialization;

#pragma warning disable CS1591
namespace CryptoPay.Types;

/// <summary>
/// Type of the price, can be <see cref="CurrencyTypes.crypto"/> or <see cref="CurrencyTypes.fiat"/>.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CurrencyTypes
{
    crypto,
    fiat
}
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
    JET,
    
    //Fiat
    RUB = 100, // Russian ruble
    USD = 101, // Dollar USA
    EUR = 102, // Euro
    BYN = 103, // Belarusian ruble
    UAH = 104, // Ukrainian hryvnia
    GBP = 105, // Pound sterling
    CNY = 106, // Renminbi
    KZT = 107, // Kazakhstani tenge
    UZS = 108, // Uzbekistani som
    GEL = 109, // Georgian lari
    TRY = 110, // Turkish lira
    AMD = 111, // Armenian dram
    THB = 112, // Thai baht
    INR = 113, // Indian rupee
    BRL = 114, // Brazilian real
    IDR = 115, // Indonesian rupiah
    AZN = 116, // Azerbaijani manat
    AED = 117, // United Arab Emirates dirham
    PLN = 118, // Polish złoty
    ILS = 119 // Israeli new shekel
}
using System.Text.Json.Serialization;

#pragma warning disable CS1591
namespace CryptoPay.Types;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
/// <summary>
/// Available crypto and fiat currencies.
/// <remarks>
/// Given that the list of available currencies in the CryptoPay service frequently changes, the utilization of these Assets becomes less effective.
/// However, you can convert an <see cref="Assets"/> value into a string by using Assets.BTC.ToString(), or obtain an Assets value from a text string by using <see cref="AssetsHelper.TryParse"/></remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Assets
{
    /// <summary>
    /// Unknown asset
    /// </summary>
    /// <remarks>
    /// Due to the fact that the list of available currencies in the CryptoPay service is constantly changing, utilizing <see cref="Assets"/> becomes ineffective.
    /// However, you can utilize the <see cref="AssetsHelper.TryParse"/> method to convert a string value to <see cref="Assets"/>. If the specified string value does not correspond to any element in <see cref="Assets"/>, the method will revert to the default <see cref="Assets.Unknown"/>.
    /// </remarks>>
    Unknown = -1,

    // Crypto

    /// <summary>
    /// Bitcoin
    /// </summary>
    BTC = 0,

    /// <summary>
    /// TonCoin
    /// </summary>
    TON = 1,

    /// <summary>
    /// Ethereum
    /// </summary>
    ETH = 2,

    /// <summary>
    /// BNB Coin
    /// </summary>
    BNB = 3,

    /// <summary>
    /// Tether (USDT)
    /// </summary>
    USDT = 4,

    /// <summary>
    /// USD Coin
    /// </summary>
    USDC = 5,

    /// <summary>
    /// TRON (TRX)
    /// </summary>
    TRX = 6,

    /// <summary>
    /// Litecoin
    /// </summary>
    LTC = 7,

    /// <summary>
    /// Jetcoin
    /// </summary>
    JET = 8,

    /// <summary>
    /// Jetton GRAM from blockchain TON
    /// </summary>
    /// <seealso href="https://gramcoin.org/"/>
    GRAM = 9,

    // Fiat

    /// <summary>
    /// Russian ruble
    /// </summary>
    RUB = 100,

    /// <summary>
    /// Dollar USA
    /// </summary>
    USD = 101,

    /// <summary>
    /// Euro
    /// </summary>
    EUR = 102,

    /// <summary>
    /// Belarusian ruble
    /// </summary>
    BYN = 103,

    /// <summary>
    /// Ukrainian hryvnia
    /// </summary>
    UAH = 104,

    /// <summary>
    /// Pound sterling
    /// </summary>
    GBP = 105,

    /// <summary>
    /// Renminbi
    /// </summary>
    CNY = 106,

    /// <summary>
    /// Kazakhstani tenge
    /// </summary>
    KZT = 107,

    /// <summary>
    /// Uzbekistani som
    /// </summary>
    UZS = 108,

    /// <summary>
    /// Georgian lari
    /// </summary>
    GEL = 109,

    /// <summary>
    /// Turkish lira
    /// </summary>
    TRY = 110,

    /// <summary>
    /// Armenian dram
    /// </summary>
    AMD = 111,

    /// <summary>
    /// Thai baht
    /// </summary>
    THB = 112,

    /// <summary>
    /// Indian rupee
    /// </summary>
    INR = 113,

    /// <summary>
    /// Brazilian real
    /// </summary>
    BRL = 114,

    /// <summary>
    /// Indonesian rupiah
    /// </summary>
    IDR = 115,

    /// <summary>
    /// Azerbaijani manat
    /// </summary>
    AZN = 116,

    /// <summary>
    /// United Arab Emirates dirham 
    /// </summary>
    AED = 117,

    /// <summary>
    /// Polish złoty
    /// </summary>
    PLN = 118,

    /// <summary>
    /// Israeli new shekel
    /// </summary>
    ILS = 119,

    /// <summary>
    /// Kyrgyz som
    /// </summary>
    KGS = 120,

    /// <summary>
    /// Tajikistani somoni
    /// </summary>
    TJS = 121
}
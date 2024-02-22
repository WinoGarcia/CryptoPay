using System.Text.Json.Serialization;

#pragma warning disable CS1591
namespace CryptoPay.Types;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
/// <summary>
/// Available crypto and fiat currencies.
/// <remarks>
/// Given that the list of available currencies in the CryptoPay service frequently changes, the utilization of these Assets becomes less effective.
/// However, you can convert an Assets value into a string by using Assets.BTC.ToString(), or obtain an Assets value from a text string by using Enum.Parse(yourString)</remarks>
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
    Unknown = 0,

    // Crypto

    /// <summary>
    /// Bitcoin
    /// </summary>
    BTC = 1,

    /// <summary>
    /// TonCoin
    /// </summary>
    TON = 2,

    /// <summary>
    /// Ethereum
    /// </summary>
    ETH = 3,

    /// <summary>
    /// BNB Coin
    /// </summary>
    BNB = 4,

    /// <summary>
    /// Tether (USDT)
    /// </summary>
    USDT = 5,

    /// <summary>
    /// USD Coin
    /// </summary>
    USDC = 6,

    /// <summary>
    /// TRON (TRX)
    /// </summary>
    TRX = 7,

    /// <summary>
    /// Litecoin
    /// </summary>
    LTC = 8,

    /// <summary>
    /// Jetcoin
    /// </summary>
    JET = 9,

    /// <summary>
    /// Jetton GRAM from blockchain TON
    /// </summary>
    /// <seealso href="https://gramcoin.org/"/>
    GRAM = 1000,

    // Fiat

    /// <summary>
    /// Russian ruble
    /// </summary>
    RUB = 10000,

    /// <summary>
    /// Dollar USA
    /// </summary>
    USD = 10001,

    /// <summary>
    /// Euro
    /// </summary>
    EUR = 10002,

    /// <summary>
    /// Belarusian ruble
    /// </summary>
    BYN = 10003,

    /// <summary>
    /// Ukrainian hryvnia
    /// </summary>
    UAH = 10004,

    /// <summary>
    /// Pound sterling
    /// </summary>
    GBP = 10005,

    /// <summary>
    /// Renminbi
    /// </summary>
    CNY = 10006,

    /// <summary>
    /// Kazakhstani tenge
    /// </summary>
    KZT = 10007,

    /// <summary>
    /// Uzbekistani som
    /// </summary>
    UZS = 10008,

    /// <summary>
    /// Georgian lari
    /// </summary>
    GEL = 10009,

    /// <summary>
    /// Turkish lira
    /// </summary>
    TRY = 10010,

    /// <summary>
    /// Armenian dram
    /// </summary>
    AMD = 10011,

    /// <summary>
    /// Thai baht
    /// </summary>
    THB = 10012,

    /// <summary>
    /// Indian rupee
    /// </summary>
    INR = 10013,

    /// <summary>
    /// Brazilian real
    /// </summary>
    BRL = 10014,

    /// <summary>
    /// Indonesian rupiah
    /// </summary>
    IDR = 10015,

    /// <summary>
    /// Azerbaijani manat
    /// </summary>
    AZN = 10016,

    /// <summary>
    /// United Arab Emirates dirham 
    /// </summary>
    AED = 10017,

    /// <summary>
    /// Polish złoty
    /// </summary>
    PLN = 10018,

    /// <summary>
    /// Israeli new shekel
    /// </summary>
    ILS = 10019,

    /// <summary>
    /// Kyrgyz som
    /// </summary>
    KGS = 10020,

    /// <summary>
    /// Tajikistani somoni
    /// </summary>
    TJS = 10021
}
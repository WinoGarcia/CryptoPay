﻿using System.Text.Json.Serialization;

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

    /// <summary>
    /// Bitcoin
    /// </summary>
    BTC,

    /// <summary>
    /// TonCoin
    /// </summary>
    TON,

    /// <summary>
    /// Ethereum
    /// </summary>
    ETH,

    /// <summary>
    /// BNB Coin
    /// </summary>
    BNB,

    /// <summary>
    /// Tether (USDT)
    /// </summary>
    USDT,

    /// <summary>
    /// USD Coin
    /// </summary>
    USDC,

    /// <summary>
    /// TRON (TRX)
    /// </summary>
    TRX,

    /// <summary>
    /// Litecoin
    /// </summary>
    LTC,

    /// <summary>
    /// Jetcoin
    /// </summary>
    JET,

    /// <summary>
    /// Jetton GRAM from blockchain TON
    /// </summary>
    /// <seealso href="https://gramcoin.org/"/>
    GRAM,

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
    ILS = 119
}
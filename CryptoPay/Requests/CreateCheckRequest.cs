using System.Text.Json.Serialization;
using CryptoPay.Requests.Base;
using CryptoPay.Types;

namespace CryptoPay.Requests;

/// <summary>
/// Use this method to create a new check. On success, returns an object of the created <see cref="Check"/>.
/// </summary>
public sealed class CreateCheckRequest : ParameterlessRequest<Check>
{
    #region Constructors

    /// <summary>
    /// Initializes a new request to create <see cref="Check"/>
    /// </summary>
    /// <param name="asset">Cryptocurrency alphabetic code. Supported <see cref="Assets"/>.</param>
    /// <param name="amount">Amount of the invoice in float. For example: 125.50</param>
    public CreateCheckRequest(
        Assets asset,
        double amount)
        : base("createCheck")
    {
        this.Asset = asset;
        this.Amount = amount;
    }

    #endregion

    #region Public Fields

    /// <summary>
    /// Cryptocurrency alphabetic code. Supported <see cref="Assets"/>.
    /// </summary>
    [JsonRequired]
    public Assets Asset { get; set; }

    /// <summary>
    /// Amount of the invoice in float. For example: 125.50
    /// </summary>
    [JsonRequired]
    public double Amount { get; set; }

    #endregion
}
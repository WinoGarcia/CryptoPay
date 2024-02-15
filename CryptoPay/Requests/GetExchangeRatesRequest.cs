using System.Collections.Generic;
using CryptoPay.Requests.Base;
using CryptoPay.Types;

namespace CryptoPay.Requests;

/// <summary>
/// Use this class to get list of <see cref="ExchangeRate"/> request.
/// </summary>
internal sealed class GetExchangeRatesRequest : ParameterlessRequest<List<ExchangeRate>>
{
    /// <summary>
    /// Initializes a new request to get list of <see cref="ExchangeRate"/>
    /// </summary>
    public GetExchangeRatesRequest()
        : base("getExchangeRates") {}
}